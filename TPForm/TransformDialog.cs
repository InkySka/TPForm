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
            log = new StringBuilder();

            if (LoadedMeshesList.Items.Count != 0)
            {
                LoadedMeshesList.Items.Clear();
            }
            foreach (TPMesh m in Global.meshes)
            {
                /*FileInfo temp = new FileInfo(m.Filename);
                LoadedMeshesList.Items.Add(temp.Name);*/
                LoadedMeshesList.Items.Add(m);
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

        private void BApplyTransformations_Click(object sender, EventArgs e)
        {
            ConfirmationDialog confirm = new ConfirmationDialog();
            confirm.FormClosing += ConfirmationDialog_CloseHandler;

            confirm.ShowDialog();

            this.EditLog(confirm.DumpLog());

            if (confirm.DialogResult == DialogResult.OK)
            {
                Global.FillTransformationMatrix((double)XMove.Value, (double)YMove.Value, (double)ZMove.Value,
                    (double)XRot.Value,(double)YRot.Value,(double)ZRot.Value,
                    (double)XScale.Value, (double)YScale.Value, (double)ZScale.Value);

                foreach (TPMesh m in LoadedMeshesList.CheckedItems)
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

        private void LoadedMeshesList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (LoadedMeshesList.CheckedItems.Count > 0)
            {
                bApplyTransformations.Enabled = true;
            }
            else
            {
                bApplyTransformations.Enabled = false;
            }
        }
    }
}
