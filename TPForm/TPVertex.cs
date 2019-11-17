using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMeshEditor
{
    /// <summary>
    /// Defines a vertex.
    /// </summary>
    public class TPVertex : ILoggable, IByteArrayCapable, ITransformable
    {
        /// <summary>
        /// Initialises the vertex from a raw data array.
        /// </summary>
        /// <param name="_rawdata"></param>
        public TPVertex(List<byte> _rawdata)
        {
            if (_rawdata.Count() < DefaultSize)
            {
                throw new ArgumentException("The initialisation vector's size must be at least " + DefaultSize);
            }

            Unknown_Reserved = new List<byte>();
            log = new StringBuilder();

            Set(_rawdata);
        }

        /*DEPRECATED.
         * Use IndividualSet() instead.
         * 
         * public TPVertex(uint _sz, float _x, float _y, float _z,
            float _vt_u, float _vt_v,
            uint _ukn1, uint _ukn2, uint _transp, List<Data4Bytes> _ukn_res)
        {
            Set(_sz, _x, _y, _z, _vt_u, _vt_v, _ukn1, _ukn2, _transp);
            SetAdditionalData(_ukn_res);
        }*/

        private StringBuilder log;

        /// <summary>
        /// Default size, INCLUDING size counter, in BYTES.
        /// </summary>
        private static readonly uint DefaultSize = 36;

        public uint Size { get; private set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Vt_u { get; set; }
        public float Vt_v { get; set; }
        public float Unknown1 { get; set; }
        public float Unknown2 { get; set; }
        public uint Transparency { get; set; }

        /// <summary>
        /// Allows for future implementations of arbitrary sizes; should never be used during normal operations.
        /// </summary>
        /// <remarks>
        /// The class issues a warning when this is filled on initialisation.
        /// </remarks>
        public List<byte> Unknown_Reserved { get; set; }

        public void Set(List<byte> _rawdata)
        {
            IndividualSet(
                ((Data4Bytes)_rawdata.GetRange(0, 4)).ui,      //_sz
                ((Data4Bytes)_rawdata.GetRange(4, 4)).f,       //_x
                ((Data4Bytes)_rawdata.GetRange(8, 4)).f,     //_y
                ((Data4Bytes)_rawdata.GetRange(12, 4)).f,     //_z
                ((Data4Bytes)_rawdata.GetRange(16, 4)).f,   //_vt_u
                ((Data4Bytes)_rawdata.GetRange(20, 4)).f,       //_vt_v
                ((Data4Bytes)_rawdata.GetRange(24, 4)).f,     //_ukn1
                ((Data4Bytes)_rawdata.GetRange(28, 4)).f,     //_ukn2
                ((Data4Bytes)_rawdata.GetRange(32, 4)).ui    //_transp
                );

            if (_rawdata.Count > DefaultSize)
            {
                SetAdditionalData(_rawdata.Skip((int)DefaultSize).ToList());
            }
        }

        /// <summary>
        /// Used to initialise parameters individually.
        /// </summary>
        public void IndividualSet(uint _sz, float _x, float _y, float _z,
            float _vt_u, float _vt_v,
            float _ukn1, float _ukn2, uint _transp)
        {
            Size = _sz;
            X = _x;
            Y = _y;
            Z = _z;
            Vt_u = _vt_u;
            Vt_v = _vt_v;
            Unknown1 = _ukn1;
            Unknown2 = _ukn2;
            Transparency = _transp;
            if (Transparency != (uint)0xFFFFFFFF)
            {
                //log.AppendLine(new WarningString("Transparency is not 0xFFFFFFFF, is this correct? If you see this message for many files, there might be an error.", UrgencyLevel.Warning).ToString());
            }
        }

        public List<byte> Get()
        {
            List<byte> output = new List<byte>((int)Size + 4);

            output.AddRange(((Data4Bytes)Size).B);
            output.AddRange(((Data4Bytes)X).B);
            output.AddRange(((Data4Bytes)Y).B);
            output.AddRange(((Data4Bytes)Z).B);
            output.AddRange(((Data4Bytes)Vt_u).B);
            output.AddRange(((Data4Bytes)Vt_v).B);
            output.AddRange(((Data4Bytes)Unknown1).B);
            output.AddRange(((Data4Bytes)Unknown2).B);
            output.AddRange(((Data4Bytes)Transparency).B);
            output.AddRange(Unknown_Reserved);

            return output;
        }

        public void SetAdditionalData(List<byte> _ukn_res)
        {
            log.AppendLine(new WarningString("Initialised " + _ukn_res.Count + " bytes more than expected.", UrgencyLevel.Warning).ToString());
            Unknown_Reserved = _ukn_res;
        }

        public void Transform(float[,] _matrix)
        {
            float newX = _matrix[0,0] * X + _matrix[0,1] * Y + _matrix[0,2] * Z + _matrix[0,3];
            float newY = _matrix[1,0] * X + _matrix[1,1] * Y + _matrix[1,2] * Z + _matrix[1,3];
            float newZ = _matrix[2,0] * X + _matrix[2,1] * Y + _matrix[2,2] * Z + _matrix[2,3];

            X = newX;
            Y = newY;
            Z = newZ;
        }

        /// <summary>
        /// Returns the log without deleting it.
        /// </summary>
        /// <returns>Log as String.</returns>
        /// <remarks>Prefer DumpLog instead.</remarks>
        public string PeekLog()
        {
            return log.ToString();
        }

        /// <summary>
        /// Returns the log and deletes it (like flushing a stream).
        /// </summary>
        /// <returns>Log as String.</returns>
        /// <remarks>This function should be preferred to PeekLog.</remarks>
        public string DumpLog()
        {
            string output;
            output = PeekLog();
            log.Clear();

            return output;
        }
    }
}
