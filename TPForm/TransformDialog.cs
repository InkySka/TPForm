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
    public partial class TransformDialog : Form
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

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FilesInFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonApplyTransformations_Click(object sender, EventArgs e)
        {
            Global.transformatioMatrix[0, 0] = (float)XScale.Value;
            Global.transformatioMatrix[1, 0] = 0;
            Global.transformatioMatrix[2, 0] = 0;
            Global.transformatioMatrix[3, 0] = 0;

            Global.transformatioMatrix[0, 1] = 0;
            Global.transformatioMatrix[1, 1] = (float)YScale.Value;
            Global.transformatioMatrix[2, 1] = 0;
            Global.transformatioMatrix[3, 1] = 0;

            Global.transformatioMatrix[0, 2] = 0;
            Global.transformatioMatrix[1, 2] = 0;
            Global.transformatioMatrix[2, 2] = (float)ZScale.Value;
            Global.transformatioMatrix[3, 2] = 0;

            Global.transformatioMatrix[0, 3] = (float)XMove.Value;
            Global.transformatioMatrix[1, 3] = (float)YMove.Value;
            Global.transformatioMatrix[2, 3] = (float)ZMove.Value;
            Global.transformatioMatrix[3, 3] = 0;

            foreach(TPMesh m in Global.meshes)
            {
                m.Transform(Global.transformatioMatrix);
                m.Export();
            }

        }
    }
}
