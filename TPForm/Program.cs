using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPMeshEditor
{
    public static class Global
    {
        public static List<TPMesh> meshes = new List<TPMesh>();
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new MainForm();

            mainForm.ShowDialog();

            //Application.Run(mainForm);
        }
    }
}
