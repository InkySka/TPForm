using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMeshEditor
{
    public class TransformationMatrix
    {
        public TransformationMatrix(int _size)
            : this(_size, 1) { }
        public TransformationMatrix(int _rows, int _cols)
            : this(_rows, _cols, 1) { }
        public TransformationMatrix(int _rows, int _cols, int _layers)
        {
            if (_rows < 1 || _cols < 1 || _layers < 1)
                throw new ArgumentException("Matrix dimensions cannot be negative.");

            Matrix = new double[_rows, _cols, _layers];
        }

        public double[,,] Matrix { get; private set; }

        public double[,] GetNthLayer(int _layer)
        {
            double[,] output = new double[Rows, Cols];
            CopyFromLayer(output, this.Matrix, _layer);
            return output;
        }
        public int Rank
        {
            get
            {
                return Matrix.Rank;
            }
        }
        public int Rows
        {
            get
            {
                return Matrix.GetLength(0);
            }
        }

        public int Cols
        {
            get
            {
                if (Matrix.Rank > 1)
                    return Matrix.GetLength(1);
                else return 0;
            }
        }

        public int Layers
        {
            get
            {
                if (Matrix.Rank > 2)
                    return Matrix.GetLength(2);
                else return 0;
            }
        }

        public void importMatrix(double[,] _matr)
        {
            CopyIntoLayer(Matrix, _matr, 0);
        }
        public void importMatrix(double[,,] _matr)
        {
            Matrix = _matr;
        }

        /// <summary>
        /// Set <see cref="Matrix"/> to the Identity matrix.
        /// </summary>
        /// <returns>0 upon success; -1 if the matrix is not square.</returns>
        public int ResetToIdentity()
        {
            if (Rows != Cols)
                return -1;
            for (int i = 0; i < Rows; ++i)
            {
                for (int j = 0; j < Cols; ++j)
                {
                    for (int k = 0; k < Layers; ++k)
                    {
                        if (i == j)
                        {
                            Matrix[i, j, k] = 1;
                        }
                        else Matrix[i, j, k] = 0;
                    }
                }
            }

            return 0;
        }

        public static double[,] GetTransformationMatrix(double XMove, double YMove, double ZMove,
            double XRotate, double YRotate, double ZRotate, double XScale, double YScale, double ZScale)
        {
            double[,] output = new double[4, 4];
            /*
             *  [                                    cos(beta)*cos(\),                                   -cos(beta)*Math.Sin(gamma),             Math.Sin(beta)]
             *  [ cos(alpha)*sin(gamma) + cos(gamma)*sin(alpha)*sin(beta), cos(alpha)*cos(gamma) - sin(alpha)*sin(beta)*sin(gamma), -cos(beta)*sin(alpha)]
             *  [ sin(alpha)*sin(gamma) - cos(alpha)*cos(gamma)*sin(beta), cos(gamma)*sin(alpha) + cos(alpha)*sin(beta)*sin(gamma),  cos(alpha)*cos(beta)]
             *
             * 
             */
            output[0, 0] = (XScale * Math.Cos(YRotate) * Math.Cos(ZRotate));
            output[1, 0] = (Math.Cos(XRotate) * Math.Sin(ZRotate) + Math.Cos(ZRotate) * Math.Sin(XRotate) * Math.Sin(YRotate));
            output[2, 0] = (Math.Sin(XRotate) * Math.Sin(ZRotate) - Math.Cos(XRotate) * Math.Cos(ZRotate) * Math.Sin(YRotate));
            output[3, 0] = 0;

            output[0, 1] = (-Math.Cos(YRotate) * Math.Sin(ZRotate));
            output[1, 1] = (YScale * (Math.Cos(XRotate) * Math.Cos(ZRotate) - Math.Sin(XRotate) * Math.Sin(YRotate) * Math.Sin(ZRotate)));
            output[2, 1] = (Math.Cos(ZRotate) * Math.Sin(XRotate) + Math.Cos(XRotate) * Math.Sin(YRotate) * Math.Sin(ZRotate));
            output[3, 1] = 0;

            output[0, 2] = Math.Sin(YRotate);
            output[1, 2] = (-Math.Cos(YRotate) * Math.Sin(XRotate));
            output[2, 2] = (ZScale * Math.Cos(XRotate) * Math.Cos(YRotate));
            output[3, 2] = 0;

            output[0, 3] = XMove;
            output[1, 3] = YMove;
            output[2, 3] = ZMove;
            output[3, 3] = 0;

            return output;
        }
        public static double[,,] GetInterpolatedTransformationMatrix(double XMoveStart, double YMoveStart, double ZMoveStart, double XMoveEnd, double YMoveEnd, double ZMoveEnd,
            double XRotateStart, double YRotateStart, double ZRotateStart, double XRotateEnd, double YRotateEnd, double ZRotateEnd,
            double XScaleStart, double YScaleStart, double ZScaleStart, double XScaleEnd, double YScaleEnd, double ZScaleEnd, int interpolationValues)
        {
            double[,,] output = new double[4, 4, interpolationValues];

            for (int i = 0; i < interpolationValues; ++i)
            {
                double[,] temp = new double[4, 4];
                temp = GetTransformationMatrix(
                    (XMoveStart + i * (XMoveEnd - XMoveStart) / interpolationValues),
                    (YMoveStart + i * (YMoveEnd - YMoveStart) / interpolationValues),
                    (ZMoveStart + i * (ZMoveEnd - ZMoveStart) / interpolationValues),
                    (XRotateStart + i * (XRotateEnd - XRotateStart) / interpolationValues),
                    (YRotateStart + i * (YRotateEnd - YRotateStart) / interpolationValues),
                    (ZRotateStart + i * (ZRotateEnd - ZRotateStart) / interpolationValues),
                    (XScaleStart + i * (XScaleEnd - XScaleStart) / interpolationValues),
                    (YScaleStart + i * (YScaleEnd - YScaleStart) / interpolationValues),
                    (ZScaleStart + i * (ZScaleEnd - ZScaleStart) / interpolationValues));
                CopyIntoLayer(output, temp, i);
            }
            return output;
        }

        private static void CopyIntoLayer(double[,,] _destination, double[,] _source, int _layer)
        {
            if (_source.GetLength(0) != _destination.GetLength(0) || _source.GetLength(1) != _destination.GetLength(1))
                throw new RankException("Rows and columns are not equal to the current matrix.");
            if (_layer > _destination.GetLength(2))
                throw new RankException("Desired layer exceeds the maximum layer count.");

            for (int i = 0; i < _source.GetLength(0); ++i)
            {
                for (int j = 0; j < _source.GetLength(1); ++j)
                {
                    _destination[i, j, _layer] = _source[i, j];
                }
            }
        }

        private static void CopyFromLayer(double[,] _destination, double[,,] _source, int _layer)
        {
            if (_source.GetLength(0) != _destination.GetLength(0) || _source.GetLength(1) != _destination.GetLength(1))
                throw new RankException("Rows and columns are not equal to the current matrix.");
            if (_layer > _source.GetLength(2))
                throw new RankException("Desired layer exceeds the maximum layer count.");

            for (int i = 0; i < _source.GetLength(0); ++i)
            {
                for (int j = 0; j < _source.GetLength(1); ++j)
                {
                    _destination[i, j] = _source[i, j, _layer];
                }
            }
        }
    }
}
