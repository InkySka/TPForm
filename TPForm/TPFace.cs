using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMeshEditor
{
    public class TPFace : ILoggable, IByteArrayCapable
    {
        private StringBuilder log;

        /// <summary>
        /// Default size, INCLUDING size counter, in BYTES.
        /// </summary>
        private static readonly uint DefaultSize = 12;

        /*
         * DEPRECATED. I will just leave this here for people to see. Mistakes have been made.
         * Never tested, probably not working. Just too ridiculous.
         * Just initialise the class and use the Set() function.
        public TPFace(uint _sz, short _v1, short _v2, short _v3, short _mid, List<Data4Bytes> _ukn_res)
            : this(new List<Data4Bytes>(new List<Data4Bytes> { _sz, new short[]{ _v1, _v2 }, new short[] { _v3, _mid } }).Concat(_ukn_res).ToList())
        { }
        */

        public TPFace(List<byte> _rawdata)
        {
            if (_rawdata.Count() < DefaultSize)
            {
                throw new ArgumentException("The initialisation vector's size must be of at least " + DefaultSize);
            }

            Unknown_Reserved = new List<byte>();
            log = new StringBuilder();

            Set(_rawdata);
        }

        public void Set(List<byte> _rawdata)
        {
            /*
             * Using BitConverter is even longer.
             * Essentially we convert 4-byte arrays to Data4Bytes,
             * and then extract the things we require.
             */
            IndividualSet(
                ((Data4Bytes)_rawdata.GetRange(0, 4)).ui,       //_sz
                ((Data4Bytes)_rawdata.GetRange(4, 4)).S[0],     //_v1
                ((Data4Bytes)_rawdata.GetRange(4, 4)).S[1],     //_v2
                ((Data4Bytes)_rawdata.GetRange(8, 4)).S[0],     //_v3
                ((Data4Bytes)_rawdata.GetRange(8, 4)).S[1]);    //_mid

            if (_rawdata.Count > DefaultSize)
            {
                SetAdditionalData(_rawdata.Skip((int)DefaultSize).ToList());
            }
        }

        public void IndividualSet(uint _sz, short _v1, short _v2, short _v3, short _mid)
        {
            Size = _sz;
            V1 = _v1;
            V2 = _v2;
            V3 = _v3;
            MId = _mid;
        }

        public void SetAdditionalData(List<byte> _ukn_res)
        {
            log.AppendLine(new WarningString("Initialised " + _ukn_res.Count + " bytes more than expected.", UrgencyLevel.Warning).ToString());
            Unknown_Reserved = _ukn_res;
        }

        public List<byte> Get()
        {
            List<byte> output = new List<byte>((int)Size + 4 + Unknown_Reserved.Count);

            short[] t1 = { V1, V2 };
            short[] t2 = { V3, MId };
            output.AddRange(((Data4Bytes)Size).B);
            output.AddRange(((Data4Bytes)t1).B);
            output.AddRange(((Data4Bytes)t2).B);
            output.AddRange(Unknown_Reserved);

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
        public List<byte> Unknown_Reserved { get; private set; }
    }
}
