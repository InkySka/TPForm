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
    public partial class MeshDetailsWindow : Form, ILoggable
    {
        public MeshDetailsWindow()
        {
            InitializeComponent();
            log = new StringBuilder();

            MeshSelector.BeginUpdate();
            foreach (TPMesh m in Global.meshes)
            {
                ListViewItem temp = new ListViewItem(m);
                temp.Tag = m;
                MeshSelector.Items.Add((TPMesh)temp.Tag);
            }
            MeshSelector.EndUpdate();
        }

        private StringBuilder log;

        public delegate void logChangedDel(string str);
        public event logChangedDel LogChangedEvent;

        private void EditLog(string logEntry)
        {
            this.log.AppendLine(logEntry);
            this.LogChangedEvent.Invoke(this.DumpLog());
        }

        private void SubComponent_LogChangedHandler(string changedLog)
        {
            EditLog(changedLog);
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

        private void MeshSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            meshComponentsView.Nodes.Clear();

            if (Global.meshes[MeshSelector.SelectedIndex].ModelCount > 0)
            {
                meshComponentsView.Nodes.Add("Models");
                meshComponentsView.Nodes[0].Tag = Global.meshes[MeshSelector.SelectedIndex].Models;

                foreach (TPModel m in Global.meshes[MeshSelector.SelectedIndex].Models)
                {
                    TreeNode temp = new TreeNode(m);
                    temp.Tag = m;
                    meshComponentsView.Nodes[0].Nodes.Add(temp);
                }

                for (int i = 0; i < Global.meshes[MeshSelector.SelectedIndex].Models.Count; ++i)
                {
                    TreeNode temp;
                    if (Global.meshes[MeshSelector.SelectedIndex].Models[i].VertexCount > 0)
                    {
                        temp = new TreeNode("Vertices");
                        temp.Tag = Global.meshes[MeshSelector.SelectedIndex].Models[i].Vertices;
                        meshComponentsView.Nodes[0].Nodes[i].Nodes.Add(temp);
                    }
                    if (Global.meshes[MeshSelector.SelectedIndex].Models[i].FaceCount > 0)
                    {
                        temp = new TreeNode("Faces");
                        temp.Tag = Global.meshes[MeshSelector.SelectedIndex].Models[i].Faces;
                        meshComponentsView.Nodes[0].Nodes[i].Nodes.Add(temp);
                    }
                    if (Global.meshes[MeshSelector.SelectedIndex].Models[i].AnimationFrameCount > 0)
                    {
                        temp = new TreeNode("Animation frames");
                        temp.Tag = Global.meshes[MeshSelector.SelectedIndex].Models[i].AnimationFrames;
                        meshComponentsView.Nodes[0].Nodes[i].Nodes.Add(temp);
                    }
                }
            }

            if (Global.meshes[MeshSelector.SelectedIndex].MaterialCount > 0)
            {
                TreeNode tempMat = new TreeNode("Materials");
                tempMat.Tag = Global.meshes[MeshSelector.SelectedIndex].Materials;
                meshComponentsView.Nodes.Add(tempMat);
            }
        }

        private void BOpenTransformationDialog_MouseClick(object sender, MouseEventArgs e)
        {
            TransformDialog transformDialog = new TransformDialog();
            transformDialog.LogChangedEvent += this.SubComponent_LogChangedHandler;

            transformDialog.Show();
        }

        /// <summary>
        /// Fills the List tree.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MeshComponentsView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            /*  
             *  Models
             *  | Model 0
             *  | | Vertices
             *  | | Faces
             *  ...
             *  Materials
             *  | Material 0
             *  ...
             */
            if (meshComponentsView.SelectedNode.Tag == Global.meshes[MeshSelector.SelectedIndex].Models)
            {
                dataView.Clear();
                dataView.BeginUpdate();
                dataView.Columns.Add("ID");
                dataView.Columns.Add("Size");
                dataView.Columns.Add("Vertex count");
                dataView.Columns.Add("Face count");
                dataView.Columns.Add("Animation frame count");
                dataView.EndUpdate();

                List<TPModel> modelList = Global.meshes[MeshSelector.SelectedIndex].Models;

                dataView.BeginUpdate();
                for (int i = 0; i < modelList.Count; ++i)
                {
                    List<string> values = new List<string>();

                    values.Add(i.ToString());
                    values.Add(modelList[i].Size.ToString());
                    values.Add(modelList[i].VertexCount.ToString());
                    values.Add(modelList[i].FaceCount.ToString());
                    values.Add(modelList[i].AnimationFrameCount.ToString());

                    ListViewItem temp = new ListViewItem(values.ToArray());
                    temp.Tag = Global.meshes[MeshSelector.SelectedIndex].Models;
                    dataView.Items.Add(temp);
                }
                dataView.EndUpdate();
            }
            else if (meshComponentsView.SelectedNode.Text == "Vertices")
            {
                int tempModelNum = meshComponentsView.SelectedNode.Parent.Index;

                dataView.Clear();
                dataView.BeginUpdate();
                dataView.Columns.Add("Vertex number");
                dataView.Columns.Add("Size");
                dataView.Columns.Add("X");
                dataView.Columns.Add("Y");
                dataView.Columns.Add("Z");
                dataView.Columns.Add("VT_U");
                dataView.Columns.Add("VT_V");
                dataView.Columns.Add("Unknown1");
                dataView.Columns.Add("Unknown2");
                dataView.Columns.Add("Transparency");
                dataView.EndUpdate();

                List<TPVertex> vertList = Global.meshes[MeshSelector.SelectedIndex].Models[tempModelNum].Vertices;

                dataView.BeginUpdate();
                for (int i = 0; i < vertList.Count; ++i)
                {
                    List<string> values = new List<string>();

                    values.Add(i.ToString());
                    values.Add(vertList[i].Size.ToString());
                    values.Add(vertList[i].X.ToString());
                    values.Add(vertList[i].Y.ToString());
                    values.Add(vertList[i].Z.ToString());
                    values.Add(vertList[i].Vt_u.ToString());
                    values.Add(vertList[i].Vt_v.ToString());
                    values.Add(vertList[i].Unknown1.ToString());
                    values.Add(vertList[i].Unknown2.ToString());
                    values.Add(vertList[i].Transparency.ToString());

                    ListViewItem temp = new ListViewItem(values.ToArray());
                    temp.Tag = Global.meshes[MeshSelector.SelectedIndex].Models[tempModelNum].Vertices;
                    dataView.Items.Add(temp);
                }
                dataView.EndUpdate();

                /*foreach (ListView.ColumnHeaderCollection c in dataView.Columns)
                {
                    c.Add("TEST");
                }*/

                //foreach(TPVertex v in ((TPModel)meshComponentsView.SelectedNode.Parent).Vertices)
            } //endif vertices
            else if (meshComponentsView.SelectedNode.Text == "Faces")
            {
                int tempModelNum = meshComponentsView.SelectedNode.Parent.Index;

                dataView.Clear();
                dataView.BeginUpdate();
                dataView.Columns.Add("Face number");
                dataView.Columns.Add("Size");
                dataView.Columns.Add("V1");
                dataView.Columns.Add("V2");
                dataView.Columns.Add("V3");
                dataView.Columns.Add("Material");
                dataView.EndUpdate();

                List<TPFace> faceList = Global.meshes[MeshSelector.SelectedIndex].Models[tempModelNum].Faces;

                dataView.BeginUpdate();
                for (int i = 0; i < faceList.Count; ++i)
                {
                    List<string> values = new List<string>();

                    values.Add(i.ToString());
                    values.Add(faceList[i].Size.ToString());
                    values.Add(faceList[i].V1.ToString());
                    values.Add(faceList[i].V2.ToString());
                    values.Add(faceList[i].V3.ToString());
                    values.Add(faceList[i].MId.ToString());

                    ListViewItem temp = new ListViewItem(values.ToArray());
                    temp.Tag = Global.meshes[MeshSelector.SelectedIndex].Models[tempModelNum].Faces;
                    dataView.Items.Add(temp);
                }
                dataView.EndUpdate();
            } //endif faces
            else if (meshComponentsView.SelectedNode.Text == "Animation frames")
            {
                int tempModelNum = meshComponentsView.SelectedNode.Parent.Index;

                dataView.Clear();
                dataView.BeginUpdate();
                dataView.Columns.Add("ID");
                dataView.Columns.Add("Size");
                dataView.Columns.Add("DEV_Count");
                dataView.Columns.Add("DEV_DivResult");
                dataView.EndUpdate();

                List<TPAnimFrame> animFrameList = Global.meshes[MeshSelector.SelectedIndex].Models[tempModelNum].AnimationFrames;

                dataView.BeginUpdate();
                for (int i = 0; i < animFrameList.Count; ++i)
                {
                    List<string> values = new List<string>();

                    values.Add(i.ToString());
                    values.Add(animFrameList[i].Size.ToString());
                    values.Add(animFrameList[i].DEV_Amt.ToString());
                    values.Add(animFrameList[i].DEV_Div.ToString());

                    ListViewItem temp = new ListViewItem(values.ToArray());
                    temp.Tag = Global.meshes[MeshSelector.SelectedIndex].Models[tempModelNum].AnimationFrames;
                    dataView.Items.Add(temp);
                }
                dataView.EndUpdate();
            }
            else if (meshComponentsView.SelectedNode.Tag == Global.meshes[MeshSelector.SelectedIndex].Materials)
            {
                int tempMaterialNum = meshComponentsView.SelectedNode.Index;

                dataView.Clear();
                dataView.BeginUpdate();
                dataView.Columns.Add("ID");
                dataView.Columns.Add("Size");
                dataView.Columns.Add("String length");
                dataView.Columns.Add("Texture name");
                for (int i = 0; i < Global.DefaultMaterialDataSize; ++i)
                {
                    dataView.Columns.Add("Data" + i);
                }
                dataView.EndUpdate();

                List<TPMaterial> materialList = Global.meshes[MeshSelector.SelectedIndex].Materials;

                dataView.BeginUpdate();
                for (int i = 0; i < materialList.Count; ++i)
                {
                    List<string> values = new List<string>();

                    values.Add(i.ToString());
                    values.Add(materialList[i].Size.ToString());
                    values.Add(materialList[i].TextureNameLength.ToString());
                    values.Add(materialList[i].TextureName.ToString());
                    for (int j = 0; j < Global.DefaultMaterialDataSize; ++j)
                    {
                        values.Add(materialList[i].Unknown[j].f.ToString());
                    }

                    ListViewItem temp = new ListViewItem(values.ToArray());
                    temp.Tag = Global.meshes[MeshSelector.SelectedIndex].Materials;
                    dataView.Items.Add(temp);
                }
                dataView.EndUpdate();

            }//endif

        }
    }
}
