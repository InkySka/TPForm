using System.IO;
using System.Text;
using System.Collections.Generic;

namespace TPMeshEditor
{
    /// <summary>
    /// Class that holds the current directory and provides the list of files to work on.
    /// </summary>
    /// <remarks>
    /// Initialised on startup, globally available within assembly.
    /// Actually more similar to a struct, using properties more than usual rather than methods.
    /// </remarks>
    internal static class FileOperations
    {
        /// <summary>
        /// Internal log file.
        /// </summary>
        private static StringBuilder log = new StringBuilder();

        /// <summary>
        /// Input directory; accessed through property.
        /// </summary>
        private static string inputDirectory;

        /// <summary>
        /// Input directory; accessed through property.
        /// </summary>
        private static string outputDirectory;

        /// <summary>
        /// Initialises the class with all the information the programme needs.
        /// </summary>
        static FileOperations()
        {
            FileFormats = new List<string> { ".mdb" };
            Files = new List<string>();

            inputDirectory = Directory.GetCurrentDirectory() + "/INPUT";
            outputDirectory = Directory.GetCurrentDirectory() + "/OUTPUT";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                log.AppendLine("Created input directory: " + inputDirectory);
            }
            else
                log.AppendLine("Found input directory: " + inputDirectory);


            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
                log.AppendLine("Created output directory: " + outputDirectory);
            }
            else
                log.AppendLine("Found output directory: " + outputDirectory);

            FillFileList();
        }
        /// <summary>
        /// File formats that need to be discovered by the programme.
        /// </summary>
        /// <remarks>
        /// Initialised in the default parameterless constructor. 
        /// Not meant to be modified by the user.
        /// </remarks>
        public static List<string> FileFormats { get; }

        /// <summary>
        /// Current input directory.
        /// </summary>
        public static string InputDirectory
        {
            get { return inputDirectory; }
            set
            {
                inputDirectory = value;
                Files.Clear();
                FillFileList();
            }
        }

        /// <summary>
        /// Current output directory.
        /// </summary>
        public static string OutputDirectory
        {
            get { return outputDirectory; }
            set
            {
                outputDirectory = value;
            }
        }

        /// <summary>
        /// Correct-format files currently in the directory.
        /// </summary>
        public static List<string> Files { get; private set; }

        /// <summary>
        /// Returns the log without deleting it.
        /// </summary>
        /// <returns>Log as String.</returns>
        /// <remarks>Prefer DumpLog instead.</remarks>
        public static string PeekLog()
        {
            return log.ToString();
        }

        /// <summary>
        /// Returns the log and deletes it (like flushing a stream).
        /// </summary>
        /// <returns>Log as String.</returns>
        /// <remarks>This function should be preferred to PeekLog.</remarks>
        public static string DumpLog()
        {
            string output;
            output = PeekLog();
            log.Clear();

            return output;
        }

        /// <summary>
        /// Fills file list.
        /// </summary>
        /// <remarks>Use this and not FindFiles directly.</remarks>
        private static void FillFileList()
        {
            log.AppendLine("Searching in folder: " + inputDirectory);
            foreach (string ff in FileFormats)
            {
                Files.AddRange(FindFiles(ff));
                log.AppendLine("Found " + Files.Count + " files with extension " + ff);
            }
        }

        /// <summary>
        /// Internal functions that finds all files with the desired extension. Do not use directly.
        /// </summary>
        /// <param name="extension">The extension to look for.</param>
        /// <returns>list of files with the correct extension.</returns>
        /// <remarks>Only for internal use; should only read from - and write to - internal variables.
        /// Used during initialisation to fill the file list.</remarks>
        private static List<string> FindFiles(string extension)
        {
            List<string> output = new List<string>();

            foreach (string f in Directory.GetFiles(InputDirectory))
            {
                FileInfo file = new FileInfo(f);
                if (file.Extension == extension)
                    output.Add(file.Name);
            }
            return output;
        }
    }
}