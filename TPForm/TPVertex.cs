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
    public class TPVertex : ILoggable, ISettable
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
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
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
                ((Data4Bytes)_rawdata.GetRange(24, 4)).ui,     //_ukn1
                ((Data4Bytes)_rawdata.GetRange(28, 4)).ui,     //_ukn2
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
            uint _ukn1, uint _ukn2, uint _transp)
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
                log.AppendLine(new WarningString("Transparency is not 0xFFFFFFFF, is this correct? If you see this message for many files, there might be an error.", UrgencyLevel.Warning).ToString());
            }
        }

        public void SetAdditionalData(List<byte> _ukn_res)
        {
            log.AppendLine(new WarningString("Initialised " + _ukn_res.Count + " bytes more than expected.", UrgencyLevel.Warning).ToString());
            Unknown_Reserved = _ukn_res;
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
