
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Reflection;
using System.ComponentModel;
using ACT.Core.Interfaces.Common;
using ACT.Core.Interfaces.Security;
using ACT.Core.Interfaces.DataAccess;
using ACT.Core.Interfaces;
using ACT.Core;
using ACT.Core.Enums;
using ACT.Core.Extensions.CodeGenerator;


namespace IVolt.Kinguin.API.LocalDB.StoredProcedures
{
    public class BulkDatabaseProcedureData
    {
        public string ProcName;
        public Dictionary<string, System.Data.IDataParameter> Params = new Dictionary<string, System.Data.IDataParameter>();
        public static List<bool> EXEC_sp_EXEC_BULK_Procedures(List<BulkDatabaseProcedureData> Params, string Conn = "")
        {
            List<bool> _TmpReturn = new List<bool>();
            using (var DataAccess = ACT.Core.CurrentCore<I_DataAccess>.GetCurrent())
            {
                if (Conn == "")
                {
                    DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
                }
                else
                {
                    DataAccess.Open(Conn);
                }
                List<System.Data.IDataParameter> _Params = new List<System.Data.IDataParameter>();
                foreach (var data in Params)
                {
                    _Params.Clear();
                    foreach (var param in data.Params)
                    {
                        _Params.Add(new System.Data.SqlClient.SqlParameter(param.Key, param.Value.Value));
                    }
                    var _Result = DataAccess.RunCommand("[dbo]." + data.ProcName, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.StoredProcedure);
                    if (_Result.Exceptions[0] == null)
                    {
                        _TmpReturn.Add(true);
                    }
                }
            }
            return _TmpReturn;
        }
    }
}
