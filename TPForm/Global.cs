using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMeshEditor
{

    public static class Global
    {
        public static readonly uint DefaultMaterialDataSize = 18;

        public static List<TPMesh> meshes = new List<TPMesh>();
        public static float[,] transformationMatrix = new float[4, 4];
        public static double ToRadians(double deg)
        {
            return Math.PI * deg / 180.0;
        }
        public static void FillTransformationMatrix(double XMove, double YMove, double ZMove,
            double XRotate, double YRotate, double ZRotate, double XScale, double YScale, double ZScale)
        {
            transformationMatrix[0, 0] = (float)XScale;

            transformationMatrix[1, 0] = 0;
            transformationMatrix[2, 0] = 0;
            transformationMatrix[3, 0] = 0;

            transformationMatrix[0, 1] = 0;
            transformationMatrix[1, 1] = (float)YScale;
            transformationMatrix[2, 1] = 0;
            transformationMatrix[3, 1] = 0;

            transformationMatrix[0, 2] = 0;
            transformationMatrix[1, 2] = 0;
            transformationMatrix[2, 2] = (float)ZScale;
            transformationMatrix[3, 2] = 0;

            transformationMatrix[0, 3] = (float)XMove;
            transformationMatrix[1, 3] = (float)YMove;
            transformationMatrix[2, 3] = (float)ZMove;
            transformationMatrix[3, 3] = 0;
        }
    }
}
