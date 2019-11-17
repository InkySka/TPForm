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
                MeshSelector.Items.Add(m);
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
            meshComponentsView.Nodes.Add("Models");
            foreach (TPModel m in ((TPMesh)MeshSelector.SelectedItem).Models)
            {
                meshComponentsView.Nodes[0].Nodes.Add(m);
            }
            for(int i = 0; i < meshComponentsView.Nodes[0].Nodes.Count; ++i)
            {
                meshComponentsView.Nodes[0].Nodes[i].Nodes.Add("Vertices");
                meshComponentsView.Nodes[0].Nodes[i].Nodes.Add("Faces");
            }

            meshComponentsView.Nodes.Add("Materials");
            foreach (TPMaterial m in ((TPMesh)MeshSelector.SelectedItem).Materials)
            {
                meshComponentsView.Nodes[1].Nodes.Add(m);
            }
        }

        private void BOpenTransformationDialog_MouseClick(object sender, MouseEventArgs e)
        {
            TransformDialog transformDialog = new TransformDialog();
            transformDialog.LogChangedEvent += this.SubComponent_LogChangedHandler;

            transformDialog.Show();
        }

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
            if(meshComponentsView.SelectedNode.Text == "Vertices")
            {
                dataView.Clear();
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

                int tempModelNum = meshComponentsView.SelectedNode.Parent.Index;

                for(int i = 0; i < ((TPMesh)MeshSelector.SelectedItem).Models[tempModelNum].Vertices.Count; ++i)
                {
                    List<string> values = new List<string>();

                    values.Add(i.ToString());
                    values.Add(((TPMesh)MeshSelector.SelectedItem).Models[tempModelNum].Vertices[i].Size.ToString());
                    values.Add(((TPMesh)MeshSelector.SelectedItem).Models[tempModelNum].Vertices[i].X.ToString());
                    values.Add(((TPMesh)MeshSelector.SelectedItem).Models[tempModelNum].Vertices[i].Y.ToString());
                    values.Add(((TPMesh)MeshSelector.SelectedItem).Models[tempModelNum].Vertices[i].Z.ToString());
                    values.Add(((TPMesh)MeshSelector.SelectedItem).Models[tempModelNum].Vertices[i].Vt_u.ToString());
                    values.Add(((TPMesh)MeshSelector.SelectedItem).Models[tempModelNum].Vertices[i].Vt_v.ToString());
                    values.Add(((TPMesh)MeshSelector.SelectedItem).Models[tempModelNum].Vertices[i].Unknown1.ToString());
                    values.Add(((TPMesh)MeshSelector.SelectedItem).Models[tempModelNum].Vertices[i].Unknown2.ToString());
                    values.Add(((TPMesh)MeshSelector.SelectedItem).Models[tempModelNum].Vertices[i].Transparency.ToString());

                    ListViewItem temp = new ListViewItem(values.ToArray());
                    dataView.Items.Add(temp);
                }

                /*foreach (ListView.ColumnHeaderCollection c in dataView.Columns)
                {
                    c.Add("TEST");
                }*/

                //foreach(TPVertex v in ((TPModel)meshComponentsView.SelectedNode.Parent).Vertices)
            }
        }
    }
}
