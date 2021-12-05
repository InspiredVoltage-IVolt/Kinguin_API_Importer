
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
/// Execute PROC_PRODUCTS_SEARCH_BY_KINGUINID
/// </summary>
/// <returns>I_QueryResult</returns>


namespace IVolt.Kinguin.API.LocalDB.PROC.PRODUCTS.SEARCH.BY.KINGUINID
{
public static class Execute {
public static I_QueryResult Proc(string @KinguinProductID_VALUE, string Conn = "")
{
	using(var DataAccess = CurrentCore<I_DataAccess>.GetCurrent()){
	if (Conn == "") {
	DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
	 } 
	 else 
 	 { 
		DataAccess.Open(Conn);
}
	List<System.Data.IDataParameter> _Params = new List<System.Data.IDataParameter>();
	#region Param Values
	if (@KinguinProductID_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@KinguinProductID", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@KinguinProductID", @KinguinProductID_VALUE));
	}
	#endregion
	var _Result = DataAccess.RunCommand("[dbo].PROC_PRODUCTS_SEARCH_BY_KINGUINID", _Params, true, System.Data.CommandType.StoredProcedure);
	return _Result;
}}}

}
