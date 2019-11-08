using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace TPMeshEditor
{
    /// <summary>
    /// Represents 4 bytes of data, like a C/C++ union.
    /// </summary>
    /// <remarks>
    /// Properties are used to access byte and short arrays to avoid size mismatch.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct Data4Bytes
    {
        [FieldOffset(0)] public float f;
        [FieldOffset(0)] public int i;
        [FieldOffset(0)] public uint ui;

        [FieldOffset(0)] private byte b0;
        [FieldOffset(1)] private byte b1;
        [FieldOffset(2)] private byte b2;
        [FieldOffset(3)] private byte b3;

        [FieldOffset(0)] private short s0;
        [FieldOffset(2)] private short s1;

        public byte[] B
        {
            get
            {
                return new byte[4] { b0, b1, b2, b3 };
            }
            set
            {
                if (value.Count() != 4)
                {
                    throw new ArgumentException("Size of byte array must be 4.");
                }
                b0 = value[0];
                b1 = value[1];
                b2 = value[2];
                b3 = value[3];
            }
        }
        public short[] S
        {
            get
            {
                return new short[2] { s0, s1 };
            }
            set
            {
                if (value.Count() != 2)
                {
                    throw new ArgumentException("Size of short array must be 2.");
                }
                s0 = value[0];
                s1 = value[1];
            }
        }
    }

    internal partial class TPMesh
    {
        public int debugLevel = 0;
        private class TPModel
        {
            /// <summary>
            /// Main constructor.
            /// </summary>
            /// <param name="_rawdata">
            /// Supply data from ModelSize to the last animation frame byte.
            /// </param>
            TPModel(List<Data4Bytes> _rawdata)
            {
                if (_rawdata.Count() < 1 || _rawdata.Count() < _rawdata[0].ui + 4)
                {
                    throw new ArgumentException("Incorrect initialisation array size.");
                }

                Size = _rawdata[0].ui;
                ID = _rawdata[1].ui;
                VertexCount = _rawdata[2].ui;

                //should allow for vertex size that is more than 32 bytes.
                for (uint i = 0; i < VertexCount; ++i)
                {

                }

            }

            private List<TPVertex> vertices;
            private List<TPFace> faces;

            public uint Size
            {
                get;
                private set;
            }
            public uint ID
            {
                get;
                private set;
            }
            public uint VertexCount
            {
                get;
                private set;
            }
            public uint FaceCount
            {
                get;
                private set;
            }
            public uint AnimationFrameCount
            {
                get;
                private set;
            }
        }

        private class TPVertex
        {
            private StringBuilder log;

            /// <summary>
            /// Default size, INCLUDING size counter.
            /// </summary>
            private static readonly uint DefaultSize = 9;

            /// <summary>
            /// Initialises the vertex from a raw data array.
            /// </summary>
            /// <param name="_rawdata"></param>
            TPVertex(List<Data4Bytes> _rawdata)
            {
                if (_rawdata.Count() < DefaultSize)
                {
                    throw new ArgumentException("The initialisation vector's size must be at least " + DefaultSize);
                }

                Unknown_Reserved = new List<Data4Bytes>();
                log = new StringBuilder();

                Set(
                    _rawdata[0].ui,
                    _rawdata[1].f,
                    _rawdata[2].f,
                    _rawdata[3].f,
                    _rawdata[4].f,
                    _rawdata[5].f,
                    _rawdata[6].ui,
                    _rawdata[7].ui,
                    _rawdata[8].ui
                    );

                if (_rawdata.Count > DefaultSize)
                {
                    SetAdditionalData(_rawdata.GetRange((int)DefaultSize, _rawdata.Count));
                }
            }
            
            TPVertex(uint _sz, float _x, float _y, float _z,
                float _vt_u, float _vt_v,
                uint _ukn1, uint _ukn2, uint _transp, List<Data4Bytes> _ukn_res)
            {
                Set(_sz, _x, _y, _z, _vt_u, _vt_v, _ukn1, _ukn2, _transp);
                SetAdditionalData(_ukn_res);
            }

            public void Set(uint _sz, float _x, float _y, float _z,
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
            }

            public void SetAdditionalData(List<Data4Bytes> _ukn_res)
            {
                log.AppendLine(new WarningString("Initialised " + _ukn_res.Count + " bytes more than expected.", UrgencyLevel.warning).ToString());
                Unknown_Reserved = _ukn_res;
            }

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
            public List<Data4Bytes> Unknown_Reserved { get; set; }
        }

        private class TPFace
        {
            private StringBuilder log;

            /// <summary>
            /// Default size, INCLUDING size counter.
            /// </summary>
            private static readonly uint DefaultSize = 3;
            TPFace(List<Data4Bytes> _rawdata)
            {
                if (_rawdata.Count() < DefaultSize)
                {
                    throw new ArgumentException("The initialisation vector's size must be of at least " + DefaultSize);
                }

                Unknown_Reserved = new List<Data4Bytes>();
                log = new StringBuilder();

                Set(
                    _rawdata[0].ui,
                    _rawdata[1].S[0],
                    _rawdata[1].S[1],
                    _rawdata[2].S[0],
                    _rawdata[2].S[1]
                    );

                if (_rawdata.Count > DefaultSize)
                {
                    SetAdditionalData(_rawdata.GetRange((int)DefaultSize, _rawdata.Count));
                }
                else Unknown_Reserved = null;
            }

            TPFace(uint _sz, short _v1, short _v2, short _v3, short _mid, List<Data4Bytes> _ukn_res)
            {
                Set(_sz, _v1, _v2, _v3, _mid);
                SetAdditionalData(_ukn_res);
            }

            public void Set(uint _sz, short _v1, short _v2, short _v3, short _mid)
            {
                Size = _sz;
                V1 = _v1;
                V2 = _v2;
                V3 = _v3;
                MId = _mid;
            }

            public void SetAdditionalData(List<Data4Bytes> _ukn_res)
            {
                log.AppendLine(new WarningString("Initialised " + _ukn_res.Count + " bytes more than expected.", UrgencyLevel.warning).ToString());
                Unknown_Reserved = _ukn_res;
            }

            //Vertices IDs.
            public uint Size { get; private set; }
            public short V1 { get; set; }
            public short V2 { get; set; }
            public short V3 { get; set; }

            //Material ID.
            public short MId { get; set; }

            /// <summary>
            /// Allows for future implementations of arbitrary sizes; should never be used during normal operations.
            /// </summary>
            /// <remarks>
            /// The class issues a warning when this is filled on initialisation.
            /// </remarks>
            public List<Data4Bytes> Unknown_Reserved { get; set; }
        }
    }
}