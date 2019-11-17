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

namespace TPMeshEditor
{
    public partial class TransformDialog : Form, ILoggable
    {
        public TransformDialog()
        {
            InitializeComponent();

            if (LoadedMeshesList.Items.Count != 0)
            {
                LoadedMeshesList.Items.Clear();
            }
            foreach (TPMesh m in Global.meshes)
            {
                FileInfo temp = new FileInfo(m.Filename);
                LoadedMeshesList.Items.Add(temp.Name);
            }
        }
        
        private StringBuilder log;

        public delegate void logChangedDel(string str);
        public event logChangedDel LogChangedEvent;

        private void EditLog(string logEntry)
        {
            this.log.AppendLine(logEntry);
            this.LogChangedEvent.Invoke(this.DumpLog());
        }

        public string PeekLog()
        {
            return log.ToString();
        }

        public string DumpLog()
        {
            string output = this.PeekLog();
            this.log = null;
            return output;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FilesInFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConfirmationDialog_CloseHandler(object sender, EventArgs e)
        {
            
        }

        private void ButtonApplyTransformations_Click(object sender, EventArgs e)
        {
            ConfirmationDialog confirm = new ConfirmationDialog();
            confirm.FormClosing += ConfirmationDialog_CloseHandler;

            confirm.ShowDialog();

            this.EditLog(confirm.DumpLog());

            if (confirm.DialogResult == DialogResult.OK)
            {
                Global.transformationMatrix[0, 0] = (float)XScale.Value;
                Global.transformationMatrix[1, 0] = 0;
                Global.transformationMatrix[2, 0] = 0;
                Global.transformationMatrix[3, 0] = 0;

                Global.transformationMatrix[0, 1] = 0;
                Global.transformationMatrix[1, 1] = (float)YScale.Value;
                Global.transformationMatrix[2, 1] = 0;
                Global.transformationMatrix[3, 1] = 0;

                Global.transformationMatrix[0, 2] = 0;
                Global.transformationMatrix[1, 2] = 0;
                Global.transformationMatrix[2, 2] = (float)ZScale.Value;
                Global.transformationMatrix[3, 2] = 0;

                Global.transformationMatrix[0, 3] = (float)XMove.Value;
                Global.transformationMatrix[1, 3] = (float)YMove.Value;
                Global.transformationMatrix[2, 3] = (float)ZMove.Value;
                Global.transformationMatrix[3, 3] = 0;

                foreach (TPMesh m in Global.meshes)
                {
                    m.Transform(Global.transformationMatrix);
                    m.Export();
                }
            }
        }

        private void TransformDialog_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void TransformDialog_Click(object sender, EventArgs e)
        {

        }
    }
}
