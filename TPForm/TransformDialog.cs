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
        private bool doInterpolation = false;

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
                foreach (int i in LoadedMeshesList.CheckedIndices)
                {
                    for(int j = 0; j < Global.meshes[i].Models.Count; ++j)
                    {
                        TransformationMatrix tmat = new TransformationMatrix(4, 4);
                        if (!doInterpolation)
                        {
                            tmat.importMatrix(TransformationMatrix.GetTransformationMatrix((double)XMove.Value, (double)YMove.Value, (double)ZMove.Value,
                                Global.ToRadians((double)XRot.Value), Global.ToRadians((double)YRot.Value), Global.ToRadians((double)ZRot.Value),
                                (double)XScale.Value, (double)YScale.Value, (double)ZScale.Value));
                        }
                        else
                        {
                            tmat.importMatrix(TransformationMatrix.GetInterpolatedTransformationMatrix(
                                (double)XMove.Value, (double)YMove.Value, (double)ZMove.Value, (double)XMoveEnd.Value, (double)YMoveEnd.Value, (double)ZMoveEnd.Value,
                                 Global.ToRadians((double)XRot.Value), Global.ToRadians((double)YRot.Value), Global.ToRadians((double)ZRot.Value), Global.ToRadians((double)XRotEnd.Value), Global.ToRadians((double)YRotEnd.Value), Global.ToRadians((double)ZRotEnd.Value),
                                (double)XScale.Value, (double)YScale.Value, (double)ZScale.Value, (double)XScaleEnd.Value, (double)YScaleEnd.Value, (double)ZScaleEnd.Value,
                                (int)Global.meshes[i].Models[j].VertexCount));
                            //this.EditLog("Vertex count: " + (int)Global.meshes[i].Models[j].VertexCount);
                        }
                        
                        Global.meshes[i].Models[j].Transform(tmat);
                    }
                    Global.meshes[i].Export();
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

        private void BInterpolate_Click(object sender, EventArgs e)
        {
            doInterpolation = !doInterpolation;
            moveEndGroup.Enabled = !moveEndGroup.Enabled;
            scaleEndGroup.Enabled = !scaleEndGroup.Enabled;
            rotateEndGroup.Enabled = !rotateEndGroup.Enabled;
        }

        private void NumericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}
