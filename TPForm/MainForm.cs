using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace TPMeshEditor
{
    public partial class MainForm : Form
    {
        private int selectedItemsCounter = 0;
        public MainForm()
        {
            InitializeComponent();

            PopulateFileList();
            UpdateSelectedFileCount();
            string tempLog = FileOperations.DumpLog();
            WriteLog(tempLog);
        }

        private void PopulateFileList()
        {
            if (fileList.Items.Count != 0)
            {
                fileList.Items.Clear();
            }
            foreach (string fn in FileOperations.Files)
            {
                fileList.Items.Add(fn);
            }
            selectedItemsCounter = 0;
            FilesInFolder.Text = FileOperations.InputDirectory;
            UpdateSelectedFileCount();
        }


        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void WriteLog(string input)
        {
            this.log.AppendText(input);
            this.log.AppendText(Environment.NewLine);
        }

        private void UpdateSelectedFileCount()
        {
            selectedItemsCount.Text = ("Checked items: " + selectedItemsCounter);
        }



        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        /// <summary>
        /// Function to open Folder Select dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog tempDialog = new FolderBrowserDialog())
            {

                //tempDialog.RootFolder = Environment.SpecialFolder.Programs;
                //tempDialog.SelectedPath = FileOperations.InputDirectory;

                DialogResult result = tempDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(tempDialog.SelectedPath))
                {
                    WriteLog("Changing folder to " + tempDialog.SelectedPath);
                    FilesInFolder.Text = "Parsing files...";
                    selectedItemsCount.Text = "Please wait...";
                    FileOperations.InputDirectory = tempDialog.SelectedPath;
                    WriteLog(FileOperations.DumpLog());
                }
            }
            PopulateFileList();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void FileList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            selectedItemsCounter = fileList.CheckedItems.Count;

            UpdateSelectedFileCount();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            Global.meshes.Clear();
            //List<string> filesToConvert = fileList.CheckedItems.;
            foreach (ListViewItem s in fileList.CheckedItems)
            {
                WriteLog(FileOperations.InputDirectory + "/" + s.Text); 
                TPMesh temp = new TPMesh(FileOperations.InputDirectory + "/" + s.Text);
                Global.meshes.Add(temp);
                WriteLog(temp.PeekLog());
            }

            WriteLog("MESHES NOW IN MESH LIST: " + Global.meshes.Count);

            foreach (TPMesh m in Global.meshes)
            {
                m.Export();
                WriteLog("Exported " + m.OutputFilename);
            }
        }
    }
}
