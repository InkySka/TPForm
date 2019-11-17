using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPMeshEditor
{
    public partial class ConfirmationDialog : Form, ILoggable
    {
        public ConfirmationDialog()
        {
            InitializeComponent();
        }

        private string log;

        public string PeekLog()
        {
            return this.log;
        }

        public string DumpLog()
        {
            string output = this.PeekLog();
            log = null;
            return output;
        }
        /*private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }*/

        private void b_OK_TextChanged(object sender, EventArgs e)
        {

        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            log = "Transformation applied.";
            this.Dispose();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            log = "Transformation canceled.";
            this.Dispose();
        }
    }
}
