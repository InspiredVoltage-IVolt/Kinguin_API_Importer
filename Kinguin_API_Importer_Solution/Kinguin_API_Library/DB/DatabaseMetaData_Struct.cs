using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IVolt.Kinguin.API.DB
{
	public class DatabaseMetaData_Struct
    {
        public string TableName { get; set; }
        public string V1 { get; set; }
        public string V2 { get; set; }
        public string KProductID { get; set; }
        public string FilePath { get; set; }

        public int  i1 { get; set; }
        public int i2 { get; set; }

        public DatabaseMetaData_Struct ()
        {
	        TableName = null;
	        V1 = "";
	        V2 = "";
	        KProductID = "";
	        FilePath = "";
        }
    }
}
