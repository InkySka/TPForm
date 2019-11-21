using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TPMeshEditor
{
    public class TPMesh : ILoggable
    {
        public TPMesh(string _filename)
        {
            log = new StringBuilder();
            Models = new List<TPModel>();
            Header = new List<Data4Bytes>();
            OtherData = new List<byte>();
            Materials = new List<TPMaterial>();

            Filename = _filename;
            FileInfo temp = new FileInfo(_filename);

            // ...output_directory/TPF_filename.mdb
            OutputFilename = FileOperations.OutputDirectory + "/" + temp.Name;

            OriginalFileSize = (new FileInfo(_filename).Length);

            Import();
        }

        public int debugLevel = 0;
        private StringBuilder log;
        public List<TPModel> Models { get; private set; }
        public List<Data4Bytes> Header { get; private set; }
        public List<TPMaterial> Materials { get; private set; }
        public List<byte> OtherData { get; private set; }

        public string Filename { get; private set; }
        public string OutputFilename { get; private set; }

        public long OriginalFileSize { get; }
        public uint Size
        {
            get { return Header[0].ui; }
            private set 
            {
                this.Header[0] = value;
                this.Header[2] = value - 12;
            }
        }
        public uint ModelCount
        {
            get { return Header[3].ui; }
            private set { Header[3] = value; }
        }
        public uint MaterialCount { get; private set; }

        /// <summary>
        /// Import from <see cref="Filename"/>.
        /// </summary>
        /// <remarks>
        /// It doesn't really make sense to allow re-initialisation.
        /// Hence, this function is called only upon initialisation.
        /// </remarks>
        private void Import()
        {
            using (FileStream fs = new FileStream(Filename, FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    /*
                     * DO KEEP IN MIND THAT THE COUNTERS HERE REFER TO BYTES.
                     */

                    List<Data4Bytes> tempHeader = new List<Data4Bytes>();

                    tempHeader.AddRange(Data4Bytes.GenerateFromByteArray(reader.ReadBytes(16)));

                    Header = tempHeader;

                    uint remainingDataSize = (uint)OriginalFileSize; // Will be decreased later.

                    /*
                     * Currently at 16 bytes = 4 words, next thing to read is the model size data.
                     * This has to be performed as many times as there are models.
                     * Every model has to be supplied with data that ranges from its size counter
                     * (inclusive) to the last animation frame byte (inclusive).
                     * The model initialisation process takes care of making sense of the data.
                     * What matters now is getting after the last model correctly and parsing the
                     * Material data; after that, there is no known data structure, so everthing
                     * is going into the Unknown list.
                     */

                    uint currentPositionInData = 16;
                    remainingDataSize -= (currentPositionInData - 4);
                    for (uint i = 0; i < ModelCount; ++i)
                    {
                        uint tempsize = ((Data4Bytes)(reader.ReadBytes(4))).ui;
                        TPModel temp;

                        //Size + 4 because we also want to supply the model size.
                        List<byte> tempList = new List<byte>((int)tempsize + 4);

                        tempList.InsertRange(0, ((Data4Bytes)tempsize).B);
                        tempList.InsertRange(4, reader.ReadBytes((int)tempsize).ToList());

                        temp = new TPModel(tempList);
                        Models.Add(temp);
                        if (temp.PeekLog() != String.Empty)
                        {
                            log.AppendLine("--- Model " + i + " ---");
                            log.AppendLine(temp.DumpLog());
                        }

                        currentPositionInData += tempsize + 4;
                        remainingDataSize -= (tempsize - 4);
                    }

                    log.AppendLine("Added " + ModelCount + " model(s).");

                    /* 
                     * We will now import material data in a similar fashion.
                     */
                    MaterialCount = ((Data4Bytes)(reader.ReadBytes(4))).ui;
                    currentPositionInData += 4;

                    for (uint i = 0; i < MaterialCount; ++i)
                    {
                        uint tempsize = ((Data4Bytes)(reader.ReadBytes(4))).ui;
                        TPMaterial temp;

                        //Size + 4 because we also want to supply the material size.
                        List<byte> tempList = new List<byte>((int)tempsize + 4);

                        tempList.InsertRange(0, ((Data4Bytes)tempsize).B);
                        tempList.InsertRange(4, reader.ReadBytes((int)tempsize).ToList());

                        temp = new TPMaterial(tempList);
                        Materials.Add(temp);
                        if (temp.PeekLog() != String.Empty)
                        {
                            log.AppendLine("--- Material " + i + " ---");
                            log.AppendLine(temp.DumpLog());
                        }

                        currentPositionInData += tempsize + 4;
                        remainingDataSize -= (tempsize - 4);
                    }

                    log.AppendLine("Added " + MaterialCount + " material(s).");

                    OtherData.Capacity = (int)remainingDataSize;
                    OtherData = reader.ReadBytes((int)remainingDataSize).ToList();
                }
            }
        }

        public void Export()
        {
            List<byte> output = new List<byte>((int)Size + 4);

            foreach (Data4Bytes d in Header)
            {
                output.AddRange(d.B);
            }

            foreach (TPModel m in Models)
            {
                output.AddRange(m.Get());
            }

            output.AddRange(((Data4Bytes)MaterialCount).B);

            foreach (TPMaterial m in Materials)
            {
                output.AddRange(m.Get());
            }

            output.AddRange(OtherData);

            FileInfo outputFile = new FileInfo(OutputFilename);

            if (outputFile.Exists)
                outputFile.Delete();

            using (FileStream fs = new FileStream(outputFile.FullName, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    foreach (byte b in output)
                    {
                        writer.Write(b);
                    }
                }
            }
        }

        //public void Transform(float[,] _matrix)

        public void Transform(TransformationMatrix _matrix)
        {
            if (_matrix.Rank != 3)
            {
                throw new ArgumentException("Transformation matrix must be three-dimensional.");
            }
            foreach (TPModel m in Models)
            {
                m.Transform(_matrix);
            }
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

        public static implicit operator string(TPMesh m)
        {
            FileInfo temp = new FileInfo(m.Filename);
            return temp.Name;
        }

        public override string ToString()
        {
            FileInfo temp = new FileInfo(this.Filename);
            return temp.Name;
        }
    }
}
