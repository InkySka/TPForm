using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMeshEditor
{
    public class TPMaterial : ILoggable, IByteArrayCapable
    {
        public TPMaterial(List<byte> _rawdata)
        {
            this.log = new StringBuilder();
            Unknown = new List<Data4Bytes>((int)DefaultDataSizeExcludingtextureName);
            Unknown_Reserved = new List<byte>();

            Set(_rawdata);
        }

        private StringBuilder log;

        // Size(4 bytes) + String_Length(4 bytes) + string(n bytes) + 72 bytes
        static readonly private uint DefaultDataSizeExcludingtextureName = 80;
        public uint Size { get; private set; }
        public uint TextureNameLength { get; private set; }
        public string TextureName 
        { 
            get
            {
                StringBuilder output = new StringBuilder();
                foreach(byte b in textureName)
                {
                    output.Append((char)b);
                }
                return output.ToString();
            }
            private set
            {
                List<byte> output = new List<byte>();
                List<char> inputString = value.ToList();

                for(int i = 0; i < inputString.Count; i += 2)
                {
                    Data4Bytes temp = inputString.GetRange(i, 2);
                    output.AddRange(temp.B);
                }
                textureName = output;
            }
        }
        //public uint ID { get; private set; } not managed by the class itself, will implement later.
        /// <summary>
        /// Used to mantain compatibility with the 8-bit byte system.
        /// </summary>
        private List<byte> textureName;
        List<Data4Bytes> Unknown;
        List<byte> Unknown_Reserved;

        public void Set(List<byte> _rawdata)
        {
            Size = ((Data4Bytes)(_rawdata.GetRange(0, 4))).ui;
            TextureNameLength = ((Data4Bytes)(_rawdata.GetRange(4, 4))).ui;

            textureName = _rawdata.GetRange(8, (int)TextureNameLength);

            Unknown = Data4Bytes.GenerateFromByteArray(_rawdata.GetRange(8 + (int)TextureNameLength, (int)DefaultDataSizeExcludingtextureName - 8));

            if (_rawdata.Count > DefaultDataSizeExcludingtextureName + TextureNameLength)
            {
                this.log.AppendLine(new WarningString("Found more data (" + _rawdata.Count + " bytes, expected " + DefaultDataSizeExcludingtextureName + TextureNameLength + " bytes).",UrgencyLevel.Warning).ToString());
                Unknown_Reserved = _rawdata.Skip((int)DefaultDataSizeExcludingtextureName + (int)TextureNameLength).ToList();
            }
        }

        public List<byte> Get()
        {
            List<byte> output = new List<byte>((int)Size + 4);

            output.AddRange(((Data4Bytes)Size).B);
            foreach(Data4Bytes d in Data4Bytes.GenerateFromCharArray(TextureName.ToArray()))
            {
                output.AddRange(d.B);
            }
            foreach(Data4Bytes d in Unknown)
            {
                output.AddRange(d.B);
            }
            output.AddRange(Unknown_Reserved);

            return output;
        }

        public string PeekLog()
        {
            return this.log.ToString();
        }

        public string DumpLog()
        {
            string output = this.PeekLog();
            this.log.Clear();
            return output;
        }

        public static implicit operator string(TPMaterial m)
        {
            return m.TextureName;
        }

        public override string ToString()
        {
            return this.TextureName;
        }


    }
}

