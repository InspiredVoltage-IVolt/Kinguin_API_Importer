
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
/// <summary>
/// Execute PROC_PRODUCT_ADD_UPDATE_META_DATA
/// </summary>
/// <returns>I_QueryResult</returns>


namespace IVolt.Kinguin.API.LocalDB.PROC.PRODUCT.ADD.UPDATE.META.DATA
{
    public static class Execute
    {
        public static I_QueryResult Proc(string Conn = "")
        {
            using (var DataAccess = CurrentCore<I_DataAccess>.GetCurrent())
            {
                if (Conn == "")
                {
                    DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
                }
                else
                {
                    DataAccess.Open(Conn);
                }
                DataAccess.SetCommandTimeout(1200);
                List<System.Data.IDataParameter> _Params = new List<System.Data.IDataParameter>();
                #region Param Values
                #endregion
                var _Result = DataAccess.RunCommand("[dbo].PROC_PRODUCT_ADD_UPDATE_META_DATA", _Params, true, System.Data.CommandType.StoredProcedure);
                return _Result;
            }
        }
    }

}
