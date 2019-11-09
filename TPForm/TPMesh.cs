using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TPMeshEditor
{
    public class TPMesh : ILoggable, ITransformable
    {
        public TPMesh(string _filename)
        {
            log = new StringBuilder();
            models = new List<TPModel>();
            header = new List<Data4Bytes>();
            otherData = new List<byte>();

            Filename = _filename;
            FileInfo temp = new FileInfo(_filename);

            // ...output_directory/TPF_filename.mdb
            OutputFilename = FileOperations.OutputDirectory + "/" + temp.Name;

            TotalFileSize = (new FileInfo(_filename).Length);

            Import();
        }

        public int debugLevel = 0;
        private StringBuilder log;
        private List<TPModel> models;
        private List<Data4Bytes> header;
        private List<byte> otherData;

        public string Filename { get; private set; }
        public string OutputFilename { get; private set; }

        public long TotalFileSize { get; }
        public uint Size
        {
            get { return header[0].ui; }
        }
        public uint ModelCount
        {
            get { return header[3].ui; }
        }

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

                    header = tempHeader;

                    uint remainingDataSize = (uint)TotalFileSize; // Will be decreased later.

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
                        models.Add(temp);
                        if (temp.PeekLog() != null)
                        {
                            log.AppendLine("Model " + i + ": " + temp.DumpLog());
                        }

                        currentPositionInData += tempsize + 4;
                        remainingDataSize -= (tempsize - 4);
                    }
                    otherData.Capacity = (int)remainingDataSize;
                    otherData = reader.ReadBytes((int)remainingDataSize).ToList();
                }
            }
        }

        public void Export()
        {
            List<byte> output = new List<byte>((int)Size + 4);

            foreach (Data4Bytes d in header)
            {
                output.AddRange(d.B);
            }

            foreach (TPModel m in models)
            {
                output.AddRange(m.Get());
            }

            output.AddRange(otherData);

            using (FileStream fs = new FileStream(OutputFilename, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    foreach(byte b in output)
                    {
                        writer.Write(b);
                    }
                }
            }
        }

        public void Transform(float[,] _matrix)
        {
            if(_matrix.Rank != 2)
            {
                throw new ArgumentException("Transformation matrix must be two-dimensional.");
            }
            foreach (TPModel m in models)
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
            return m.Filename;
        }
    }
}
