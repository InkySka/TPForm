using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TPMeshEditor
{
    /// <summary>
    /// Interface that defines functions to read logs.
    /// </summary>
    interface ILoggable
    {
        /// <summary>
        /// Returns the log without deleting it.
        /// </summary>
        /// <returns>Log as String.</returns>
        /// <remarks>Prefer DumpLog instead.</remarks>
        string PeekLog();

        /// <summary>
        /// Returns the log and deletes it (like flushing a stream).
        /// </summary>
        /// <returns>Log as String.</returns>
        /// <remarks>This function should be preferred to PeekLog.</remarks>
        string DumpLog();
    }

    /// <summary>
    /// Interface for classes that can be initialised and set with an array of bytes.
    /// </summary>
    interface IByteArrayCapable
    {
        void Set(List<byte> _rawdata);
        List<byte> Get();
    }

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

        public static implicit operator Data4Bytes(float _val)
        {
            Data4Bytes obj = new Data4Bytes();
            obj.f = _val;
            return obj;
        }
        public static implicit operator Data4Bytes(int _val)
        {
            Data4Bytes obj = new Data4Bytes();
            obj.i = _val;
            return obj;
        }
        public static implicit operator Data4Bytes(uint _val)
        {
            Data4Bytes obj = new Data4Bytes();
            obj.ui = _val;
            return obj;
        }
        public static implicit operator Data4Bytes(byte[] _val)
        {
            Data4Bytes obj = new Data4Bytes();
            obj.B = _val;
            return obj;
        }
        public static implicit operator Data4Bytes(short[] _val)
        {
            Data4Bytes obj = new Data4Bytes();
            obj.S = _val;
            return obj;
        }
        public static implicit operator Data4Bytes(List<byte> _val)
        {
            return (Data4Bytes)(_val.ToArray());
        }
        public static implicit operator Data4Bytes(List<short> _val)
        {
            return (Data4Bytes)(_val.ToArray());
        }

        /*public Data4Bytes(float _f) : this()
        {
            f = _f;
        }*/

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

        /// <summary>
        /// Generates a <see cref="Data4Bytes"/> List from a byte array.
        /// </summary>
        /// <param name="_bl">Byte array</param>
        /// <returns>List of <see cref="Data4Bytes"/></returns>
        public static List<Data4Bytes> GenerateFromByteArray(byte[] _bl)
        {
            return GenerateFromByteArray(new List<byte>(_bl));
        }

        /// <summary>
        /// Generates a <see cref="Data4Bytes"/> List from a byte List.
        /// </summary>
        /// <param name="_bl">Byte List</param>
        /// <returns>List of <see cref="Data4Bytes"/></returns>
        public static List<Data4Bytes> GenerateFromByteArray(List<byte> _bl)
        {
            if (_bl.Count % 4 != 0)
                throw new ArgumentException("Size of byte array must be a multiple of four.");

            List<Data4Bytes> output = new List<Data4Bytes>(_bl.Count / 4);

            for (int i = 0; i < _bl.Count / 4; ++i)
            {
                Data4Bytes temp = _bl.GetRange(i * 4, 4);
                output.Add(temp);
            }

            return output;
        }
    }

    /// <summary>
    /// Used in <see cref="WarningString"/> to handle different urgency levels.
    /// </summary>
    public enum UrgencyLevel
    {
        Warning,
        Error,
        Normal
    };

    /// <summary>
    /// Uses <see cref="UrgencyLevel"/> and a string to differentiate between a normal log message and warning/errors.
    /// </summary>
    public class WarningString
    {
        private string message;
        UrgencyLevel urgencyLevel;

        /// <summary>
        /// Represent a debug message.
        /// </summary>
        /// <param name="_msg">Message to store.</param>
        /// <param name="_ulvl">Urgency level.</param>
        public WarningString(string _msg, UrgencyLevel _ulvl)
        {
            message = _msg;
            urgencyLevel = _ulvl;
        }

        public override string ToString()
        {
            string output = null;

            switch (urgencyLevel)
            {
                case UrgencyLevel.Warning:
                    {
                        output = "[WARNING] ";
                        break;
                    }
                case UrgencyLevel.Error:
                    {
                        output = "[ERROR] ";
                        break;
                    }
                case UrgencyLevel.Normal:
                    {
                        break;
                    }
                default:
                    {
                        output = "[?] ";
                        break;
                    }
            }
            output += (message);
            return output;
        }
    }
}