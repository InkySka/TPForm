using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

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
        private class TPModel
        {
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
            /// <summary>
            /// Initialises the vertex from a raw data array.
            /// </summary>
            /// <param name="_rawdata"></param>
            TPVertex(Data4Bytes[] _rawdata)
            {
                if (_rawdata.Count() != 8)
                {
                    throw new ArgumentException("The initialisation vector's size must be 8.");
                }

                Set(
                    _rawdata[0].f,
                    _rawdata[1].f,
                    _rawdata[2].f,
                    _rawdata[3].f,
                    _rawdata[4].f,
                    _rawdata[5].ui,
                    _rawdata[6].ui,
                    _rawdata[7].ui
                    );
            }
            /// <summary>
            /// Initialises the vertex from single values. Calls an internal setup function.
            /// </summary>
            /// <param name="_x"></param>
            /// <param name="_y"></param>
            /// <param name="_z"></param>
            /// <param name="_vt_u"></param>
            /// <param name="_vt_v"></param>
            /// <param name="_ukn1"></param>
            /// <param name="_ukn2"></param>
            /// <param name="_transp"></param>
            TPVertex(float _x, float _y, float _z,
                float _vt_u, float _vt_v,
                uint _ukn1, uint _ukn2, uint _transp)
            {
                Set(_x, _y, _z, _vt_u, _vt_v, _ukn1, _ukn2, _transp);
            }

            public void Set(float _x, float _y, float _z,
                float _vt_u, float _vt_v,
                uint _ukn1, uint _ukn2, uint _transp)
            {
                X = _x;
                Y = _y;
                Z = _z;
                Vt_u = _vt_u;
                Vt_v = _vt_v;
                Unknown1 = _ukn1;
                Unknown2 = _ukn2;
                Transparency = _transp;
            }

            float X { get; set; }
            float Y { get; set; }
            float Z { get; set; }
            float Vt_u { get; set; }
            float Vt_v { get; set; }
            uint Unknown1 { get; set; }
            uint Unknown2 { get; set; }
            uint Transparency { get; set; }
        }

        private class TPFace
        {
            TPFace(Data4Bytes[] _rawdata)
            {
                if (_rawdata.Count() != 2)
                {
                    throw new ArgumentException("The initialisation vector's size must be 2.");
                }

                Set(
                    _rawdata[0].S[0],
                    _rawdata[0].S[1],
                    _rawdata[1].S[0],
                    _rawdata[1].S[1]
                    );
            }

            TPFace(short _v1, short _v2, short _v3, short _mid)
            {
                Set(_v1, _v2, _v3, _mid);
            }

            public void Set(short _v1, short _v2, short _v3, short _mid)
            {
                V1 = _v1;
                V2 = _v2;
                V3 = _v3;
                MId = _mid;
            }
            //Vertices IDs.
            short V1 { get; set; }
            short V2 { get; set; }
            short V3 { get; set; }

            //Material ID.
            short MId { get; set; }
        }
    }
}
