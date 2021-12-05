
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
    

namespace IVolt.Kinguin.API.LocalDB
{
	public class KinguinProduct_To_Publishers_CoreClass : ACT.Plugins.ACT_Core, ACT.Core.Interfaces.DataAccess.I_DataObject 
	{
	#region Private Fields

	private string _LocalConnectionString = "";

		private int? __ID;
		private string __ID_Description = "";
		private int? __KinguinProduct_ID;
		private string __KinguinProduct_ID_Description = "";
		private int? __Publishers_ID;
		private string __Publishers_ID_Description = "";

	#endregion 
	#region Public Properties

	public virtual string LocalConnectionString { get { return _LocalConnectionString; } set { _LocalConnectionString = value; } }

	public virtual string PrimaryKey { get { return "ID"; } }		public virtual int? ID
		{
			get { return __ID; }
			set { __ID = value; }
		}

		public virtual string ID_Description
		{
			get { return __ID_Description; }
			set { __ID_Description = value; }
		}

		public virtual int? KinguinProduct_ID
		{
			get { return __KinguinProduct_ID; }
			set { __KinguinProduct_ID = value; }
		}

		public virtual string KinguinProduct_ID_Description
		{
			get { return __KinguinProduct_ID_Description; }
			set { __KinguinProduct_ID_Description = value; }
		}

		public virtual int? Publishers_ID
		{
			get { return __Publishers_ID; }
			set { __Publishers_ID = value; }
		}

		public virtual string Publishers_ID_Description
		{
			get { return __Publishers_ID_Description; }
			set { __Publishers_ID_Description = value; }
		}


	#endregion 


public static ACT.Core.Interfaces.DataAccess.I_DataAccess GetDataAccess()
{
	using( var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){ 
	DataAccess.Open(GenericStaticClass.DatabaseConnectionString);

	return DataAccess;}
}
	#region Public Child Tables


	#endregion 

	#region Public Parent Tables


	public KinguinProduct Get_KinguinProduct() { 

		KinguinProduct _TmpReturn = null;
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
		_Params.Add(new System.Data.SqlClient.SqlParameter("KinguinProduct_IDParam", this.ReturnProperty("KinguinProduct_ID")));
		var SQL = "Select top 1 KinguinProduct.ID From KinguinProduct Where ID = @KinguinProduct_IDParam";
		var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);

		if (Result.Tables[0].Rows.Count == 1)
		{
			_TmpReturn = new KinguinProduct((int?)Result.Tables[0].Rows[0]["ID"]);
		}

	return _TmpReturn;
}}
	public Publishers Get_Publishers() { 

		Publishers _TmpReturn = null;
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
		_Params.Add(new System.Data.SqlClient.SqlParameter("Publishers_IDParam", this.ReturnProperty("Publishers_ID")));
		var SQL = "Select top 1 Publishers.ID From Publishers Where ID = @Publishers_IDParam";
		var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);

		if (Result.Tables[0].Rows.Count == 1)
		{
			_TmpReturn = new Publishers((int?)Result.Tables[0].Rows[0]["ID"]);
		}

	return _TmpReturn;
}}
	#endregion 
	
		public KinguinProduct_To_Publishers_CoreClass(string localConnectionString = ""){ LocalConnectionString = localConnectionString; }


		public KinguinProduct_To_Publishers_CoreClass(int? ID, string localConnectionString = "") 
		{
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		if (localConnectionString == "") {

			DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		}
		else { 
		LocalConnectionString = localConnectionString;
			DataAccess.Open(localConnectionString);
		}

		List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
		_Params.Add(new System.Data.SqlClient.SqlParameter("IDParam", ID));
		var SQL = "Select * From KinguinProduct_To_Publishers Where [ID] = @IDParam";

		var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);

		if (Result.Tables[0].Rows.Count == 1) {
			for(int x = 0; x < Result.Tables[0].Columns.Count; x++) {
			if (Result.Tables[0].Rows[0][x] != DBNull.Value)
			  {
			this.SetProperty(Result.Tables[0].Columns[x].ColumnName.ToCSharpFriendlyName(), Result.Tables[0].Rows[0][x]);
}
			}
		}}

		}

	#region Public Static Search Methods

		public static List<KinguinProduct_To_Publishers> GetKinguinProduct_To_Publishers(I_DbWhereStatement Where, string sql = "", string LocalConnectionString = "")
		{
		List<KinguinProduct_To_Publishers> _TmpReturn = new List<KinguinProduct_To_Publishers>();
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		if (LocalConnectionString == "") {

			DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		}

		else { 

			DataAccess.Open(LocalConnectionString);
		}

		string _Where = DataAccess.GenerateWhereStatement(Where, sql);
		var _Params = DataAccess.GenerateWhereStatementParameters(Where);
		var QR = DataAccess.RunCommand("Select [ID] From KinguinProduct_To_Publishers Where " + _Where, _Params, true, System.Data.CommandType.Text);
		if (QR.Tables[0].Rows.Count > 0)
		{
		    foreach (System.Data.DataRow r in QR.Tables[0].Rows)
		    {
		        _TmpReturn.Add(new KinguinProduct_To_Publishers((int?)r["ID"]));
		    }
		}
return _TmpReturn;
		}}

public static List<KinguinProduct_To_Publishers> Search(string FieldName, string SearchText, bool UseContains = false, string LocalConnectionString = "")
{
List<KinguinProduct_To_Publishers> _TmpReturn = new List<KinguinProduct_To_Publishers>();
using (var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){

		if (LocalConnectionString == "") {

			DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		}

		else { 

			DataAccess.Open(LocalConnectionString);
		}

List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
_Params.Add(new System.Data.SqlClient.SqlParameter("SearchParam", SearchText));
var SQL = "";
if (UseContains == true) { 
SQL = SQL + "Select KinguinProduct_To_Publishers.ID From KinguinProduct_To_Publishers Where [" + FieldName + "] like '%' + @SearchParam + '%'";
} 
else { 
SQL = SQL + "Select KinguinProduct_To_Publishers.ID From KinguinProduct_To_Publishers Where [" + FieldName + "] = @SearchParam";
}

var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
if (Result.Tables[0].Rows.Count > 0)
{
for (int x = 0; x < Result.Tables[0].Rows.Count; x++)
{
if (Result.Tables[0].Rows[x][0] != DBNull.Value)
{
_TmpReturn.Add(new KinguinProduct_To_Publishers((int)Result.Tables[0].Rows[x]["ID"]));
}
}
}}
return _TmpReturn;
}

public static System.Data.DataTable Search(string FieldName, string SearchText, string OrderByStatement, int Start, int Increment, bool UseContains = false, string LocalConnectionString = "")
{
using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		if (LocalConnectionString == "") {

			DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		}

		else { 

			DataAccess.Open(LocalConnectionString);
		}

List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
_Params.Add(new System.Data.SqlClient.SqlParameter("SearchParam", SearchText));
var SQL = "";
if (UseContains == true) { 
SQL = SQL + "Select * From ( Select *, ROW_NUMBER() Over(order by " + OrderByStatement + ") as RowNum From KinguinProduct_To_Publishers Where [" + FieldName + "] like '%' + @SearchParam + '%') as T Where T.RowNum > " + (Start-1).ToString() + " AND T.RowNum < " + (Start + Increment).ToString();
} 
else { 
SQL = SQL + "Select * From ( Select *, ROW_NUMBER() Over(order by " + OrderByStatement + ") as RowNum From KinguinProduct_To_Publishers Where [" + FieldName + "] = @SearchParam) as T Where T.RowNum > " + (Start-1).ToString() + " AND T.RowNum < " + (Start + Increment).ToString();
}

var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
return Result.Tables[0];
}

}

public static List<KinguinProduct_To_Publishers> Search(Dictionary<string,string> FieldValues, string LocalConnectionString = "")
{
List<KinguinProduct_To_Publishers> _TmpReturn = new List<KinguinProduct_To_Publishers>();
using (var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){

		if (LocalConnectionString == "") {

			DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		}

		else { 

			DataAccess.Open(LocalConnectionString);
		}

List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
foreach(var skey in FieldValues.Keys) { _Params.Add(new System.Data.SqlClient.SqlParameter(skey, FieldValues[skey]));
 } 
var SQL = "";
SQL = SQL + "Select KinguinProduct_To_Publishers.ID From KinguinProduct_To_Publishers where ";
foreach (var skey in FieldValues.Keys)
{
SQL = SQL + "[" + skey + "] = @" + skey + " AND ";
}
SQL = SQL.Substring(0, SQL.LastIndexOf("AND"));


var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
if (Result.Tables[0].Rows.Count > 0)
{
for (int x = 0; x < Result.Tables[0].Rows.Count; x++)
{
if (Result.Tables[0].Rows[x][0] != DBNull.Value)
{
_TmpReturn.Add(new KinguinProduct_To_Publishers((int)Result.Tables[0].Rows[x]["ID"]));
}
}
}}
return _TmpReturn;
}

public static System.Data.DataTable Search(string FieldName, string SearchText, string OrderByStatement, bool UseContains = false, string LocalConnectionString = "")
{
using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		if (LocalConnectionString == "") {

			DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		}

		else { 

			DataAccess.Open(LocalConnectionString);
		}

List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
_Params.Add(new System.Data.SqlClient.SqlParameter("SearchParam", SearchText));
var SQL = "";
if (UseContains == true) { 
SQL = SQL + "Select * From KinguinProduct_To_Publishers Where [" + FieldName + "] like '%' + @SearchParam + '%'";} 
else { 
SQL = SQL + "Select * From KinguinProduct_To_Publishers Where [" + FieldName + "] = @SearchParam";}

var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
return Result.Tables[0];
}

}


	#endregion

	public string Export(string Format)
	{
	    if (Format.ToLower() == "xml")
	    {
	        System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(this.GetType() );
	        System.IO.StringWriter _Output = new System.IO.StringWriter();
	        x.Serialize(_Output, this);
	        return _Output.ToString();
	    }
	    else if (Format.ToLower() == "json")
	    {
	        return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
	    }
	
	    return "";
	}
public virtual I_QueryResult Create()
	{
using (var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){ 
		if (LocalConnectionString == "") {

			DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		}

		else { 

			DataAccess.Open(LocalConnectionString);
		}


List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
string SQLInsertFields = "";
string SQLValues = "";
if (this.ID != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("ID_Param", this.ID));
SQLInsertFields += "[ID], ";
SQLValues += "@ID_Param, ";
}
if (this.KinguinProduct_ID != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("KinguinProduct_ID_Param", this.KinguinProduct_ID));
SQLInsertFields += "[KinguinProduct_ID], ";
SQLValues += "@KinguinProduct_ID_Param, ";
}
if (this.Publishers_ID != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Publishers_ID_Param", this.Publishers_ID));
SQLInsertFields += "[Publishers_ID], ";
SQLValues += "@Publishers_ID_Param, ";
}
SQLInsertFields = SQLInsertFields.TrimEnd(", ".ToCharArray());
SQLValues = SQLValues.TrimEnd(", ".ToCharArray());
string _SQL = "Insert Into [KinguinProduct_To_Publishers] ( " + SQLInsertFields + ") Values (" + SQLValues + ")";
var _TmpReturn = DataAccess.RunCommand(_SQL, _Params.ToList<System.Data.IDataParameter>(), false, System.Data.CommandType.Text);

return _TmpReturn;
	}
}
public virtual I_QueryResult Update()
{
using (var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){ 
		if (LocalConnectionString == "") {

			DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		}

		else { 

			DataAccess.Open(LocalConnectionString);
		}


List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
string SQLInsertFields = "";
string SQLValues = "";
if (this.ID != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("ID_Param", this.ID));
SQLValues += "[ID] = @ID_Param AND ";
}
if (this.KinguinProduct_ID != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("KinguinProduct_ID_Param", this.KinguinProduct_ID));
SQLInsertFields += "[KinguinProduct_ID] = @KinguinProduct_ID_Param, ";
}
if (this.Publishers_ID != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Publishers_ID_Param", this.Publishers_ID));
SQLInsertFields += "[Publishers_ID] = @Publishers_ID_Param, ";
}
SQLInsertFields = SQLInsertFields.TrimEnd(", ".ToCharArray());
SQLValues = SQLValues.TrimEnd("AND ".ToCharArray());
string _SQL = "Update [KinguinProduct_To_Publishers] set " + SQLInsertFields + " Where " + SQLValues;
var _TmpReturn = DataAccess.RunCommand(_SQL, _Params.ToList<System.Data.IDataParameter>(), false, System.Data.CommandType.Text);

return _TmpReturn;
	}
}
public virtual void Delete()
{
using (var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){ 
		if (LocalConnectionString == "") {

			DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		}

		else { 

			DataAccess.Open(LocalConnectionString);
		}


List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
string SQLValues = "";
if (this.ID != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("ID_Param", this.ID));
SQLValues += "[ID] = @ID_Param AND ";
}
if (this.KinguinProduct_ID != null){ 
}
if (this.Publishers_ID != null){ 
}
SQLValues = SQLValues.TrimEnd("AND ".ToCharArray());
string _SQL = "Delete From [KinguinProduct_To_Publishers] Where " + SQLValues;
DataAccess.RunCommand(_SQL, _Params.ToList<System.Data.IDataParameter>(), false, System.Data.CommandType.Text);
}}

	}
}