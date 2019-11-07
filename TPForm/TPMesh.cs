using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMeshEditor
{
    internal partial class TPMesh
    {
        TPMesh(Data4Bytes[] _rawdata)
        {

        }

        private List<TPModel> models;


        private uint[] header;

        public uint ModelCount
        {
            get { return header[3]; }
        }
    }
}
