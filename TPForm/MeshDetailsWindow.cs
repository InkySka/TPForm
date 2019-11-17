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
    }
}
