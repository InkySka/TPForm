using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TPMeshEditor
{

    public static class Global
    {
        public static readonly uint DefaultMaterialDataSize = 18;

        public static List<TPMesh> meshes = new List<TPMesh>();
        public static float[,] transformationMatrix = new float[4, 4];
        public static double ToRadians(double deg)
        {
            return Math.PI * deg / 180.0;
        }
        
    }
}
