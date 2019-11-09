using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMeshEditor
{
    public class TPAnimFrame : ILoggable, IByteArrayCapable
    {
        private StringBuilder log;

        /// <summary>
        /// Default size, INCLUDING size counter.
        /// </summary>
        private static readonly uint DefaultSize = 0;

        public TPAnimFrame(List<byte> _rawdata)
        {
            Unknown = new List<byte>();
            log = new StringBuilder();

            Set(_rawdata);
        }

        public void Set(List<byte> _rawdata)
        {
            if (_rawdata.Count > 0)
            {
                Size = ((Data4Bytes)_rawdata.GetRange(0, 4)).ui;
                Unknown = _rawdata.Skip(4).ToList();
            }
        }

        public void SetAdditionalData(List<Data4Bytes> _ukn_res)
        {

        }

        public List<byte> Get()
        {
            List<byte> output = new List<byte>((int)Size + 4);

            output.AddRange(((Data4Bytes)Size).B);

            output.AddRange(Unknown);

            return output;
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

        public List<byte> Unknown;

        public uint Size { get; private set; }
    }
}
