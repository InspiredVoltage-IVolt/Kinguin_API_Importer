
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
	public class API_Execution_Result_Details_CoreClass : ACT.Plugins.ACT_Core, ACT.Core.Interfaces.DataAccess.I_DataObject 
	{
	#region Private Fields

	private string _LocalConnectionString = "";

		private Guid? __ID;
		private string __ID_Description = "";
		private Guid? __API_Execution_ID;
		private string __API_Execution_ID_Description = "";
		private string __Saved_File_FullPath;
		private string __Saved_File_FullPath_Description = "";
		private string __RAW_Return_Headers;
		private string __RAW_Return_Headers_Description = "";
		private string __RAW_Return_Body;
		private string __RAW_Return_Body_Description = "";
		private string __JSON_OBJECT;
		private string __JSON_OBJECT_Description = "";
		private int? __JSON_INT;
		private string __JSON_INT_Description = "";
		private string __Comments;
		private string __Comments_Description = "";
		private bool? __Success;
		private string __Success_Description = "";
		private DateTime? __DateAdded;
		private string __DateAdded_Description = "";
		private DateTime? __DateModified;
		private string __DateModified_Description = "";

	#endregion 
	#region Public Properties

	public virtual string LocalConnectionString { get { return _LocalConnectionString; } set { _LocalConnectionString = value; } }

	public virtual string PrimaryKey { get { return "ID"; } }		public virtual Guid? ID
		{
			get { return __ID; }
			set { __ID = value; }
		}

		public virtual string ID_Description
		{
			get { return __ID_Description; }
			set { __ID_Description = value; }
		}

		public virtual Guid? API_Execution_ID
		{
			get { return __API_Execution_ID; }
			set { __API_Execution_ID = value; }
		}

		public virtual string API_Execution_ID_Description
		{
			get { return __API_Execution_ID_Description; }
			set { __API_Execution_ID_Description = value; }
		}

		public virtual string Saved_File_FullPath
		{
			get { return __Saved_File_FullPath; }
			set { __Saved_File_FullPath = value; }
		}

		public virtual string Saved_File_FullPath_Description
		{
			get { return __Saved_File_FullPath_Description; }
			set { __Saved_File_FullPath_Description = value; }
		}

		public virtual string RAW_Return_Headers
		{
			get { return __RAW_Return_Headers; }
			set { __RAW_Return_Headers = value; }
		}

		public virtual string RAW_Return_Headers_Description
		{
			get { return __RAW_Return_Headers_Description; }
			set { __RAW_Return_Headers_Description = value; }
		}

		public virtual string RAW_Return_Body
		{
			get { return __RAW_Return_Body; }
			set { __RAW_Return_Body = value; }
		}

		public virtual string RAW_Return_Body_Description
		{
			get { return __RAW_Return_Body_Description; }
			set { __RAW_Return_Body_Description = value; }
		}

		public virtual string JSON_OBJECT
		{
			get { return __JSON_OBJECT; }
			set { __JSON_OBJECT = value; }
		}

		public virtual string JSON_OBJECT_Description
		{
			get { return __JSON_OBJECT_Description; }
			set { __JSON_OBJECT_Description = value; }
		}

		public virtual int? JSON_INT
		{
			get { return __JSON_INT; }
			set { __JSON_INT = value; }
		}

		public virtual string JSON_INT_Description
		{
			get { return __JSON_INT_Description; }
			set { __JSON_INT_Description = value; }
		}

		public virtual string Comments
		{
			get { return __Comments; }
			set { __Comments = value; }
		}

		public virtual string Comments_Description
		{
			get { return __Comments_Description; }
			set { __Comments_Description = value; }
		}

		public virtual bool? Success
		{
			get { return __Success; }
			set { __Success = value; }
		}

		public virtual string Success_Description
		{
			get { return __Success_Description; }
			set { __Success_Description = value; }
		}

		public virtual DateTime? DateAdded
		{
			get { return __DateAdded; }
			set { __DateAdded = value; }
		}

		public virtual string DateAdded_Description
		{
			get { return __DateAdded_Description; }
			set { __DateAdded_Description = value; }
		}

		public virtual DateTime? DateModified
		{
			get { return __DateModified; }
			set { __DateModified = value; }
		}

		public virtual string DateModified_Description
		{
			get { return __DateModified_Description; }
			set { __DateModified_Description = value; }
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


	#endregion 
	
		public API_Execution_Result_Details_CoreClass(string localConnectionString = ""){ LocalConnectionString = localConnectionString; }


		public API_Execution_Result_Details_CoreClass(Guid? ID, string localConnectionString = "") 
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
		var SQL = "Select * From API_Execution_Result_Details Where [ID] = @IDParam";

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

		public static List<API_Execution_Result_Details> GetAPI_Execution_Result_Details(I_DbWhereStatement Where, string sql = "", string LocalConnectionString = "")
		{
		List<API_Execution_Result_Details> _TmpReturn = new List<API_Execution_Result_Details>();
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		if (LocalConnectionString == "") {

			DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		}

		else { 

			DataAccess.Open(LocalConnectionString);
		}

		string _Where = DataAccess.GenerateWhereStatement(Where, sql);
		var _Params = DataAccess.GenerateWhereStatementParameters(Where);
		var QR = DataAccess.RunCommand("Select [ID] From API_Execution_Result_Details Where " + _Where, _Params, true, System.Data.CommandType.Text);
		if (QR.Tables[0].Rows.Count > 0)
		{
		    foreach (System.Data.DataRow r in QR.Tables[0].Rows)
		    {
		        _TmpReturn.Add(new API_Execution_Result_Details((Guid?)r["ID"]));
		    }
		}
return _TmpReturn;
		}}

public static List<API_Execution_Result_Details> Search(string FieldName, string SearchText, bool UseContains = false, string LocalConnectionString = "")
{
List<API_Execution_Result_Details> _TmpReturn = new List<API_Execution_Result_Details>();
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
SQL = SQL + "Select API_Execution_Result_Details.ID From API_Execution_Result_Details Where [" + FieldName + "] like '%' + @SearchParam + '%'";
} 
else { 
SQL = SQL + "Select API_Execution_Result_Details.ID From API_Execution_Result_Details Where [" + FieldName + "] = @SearchParam";
}

var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
if (Result.Tables[0].Rows.Count > 0)
{
for (int x = 0; x < Result.Tables[0].Rows.Count; x++)
{
if (Result.Tables[0].Rows[x][0] != DBNull.Value)
{
_TmpReturn.Add(new API_Execution_Result_Details((Guid)Result.Tables[0].Rows[x]["ID"]));
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
SQL = SQL + "Select * From ( Select *, ROW_NUMBER() Over(order by " + OrderByStatement + ") as RowNum From API_Execution_Result_Details Where [" + FieldName + "] like '%' + @SearchParam + '%') as T Where T.RowNum > " + (Start-1).ToString() + " AND T.RowNum < " + (Start + Increment).ToString();
} 
else { 
SQL = SQL + "Select * From ( Select *, ROW_NUMBER() Over(order by " + OrderByStatement + ") as RowNum From API_Execution_Result_Details Where [" + FieldName + "] = @SearchParam) as T Where T.RowNum > " + (Start-1).ToString() + " AND T.RowNum < " + (Start + Increment).ToString();
}

var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
return Result.Tables[0];
}

}

public static List<API_Execution_Result_Details> Search(Dictionary<string,string> FieldValues, string LocalConnectionString = "")
{
List<API_Execution_Result_Details> _TmpReturn = new List<API_Execution_Result_Details>();
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
SQL = SQL + "Select API_Execution_Result_Details.ID From API_Execution_Result_Details where ";
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
_TmpReturn.Add(new API_Execution_Result_Details((Guid)Result.Tables[0].Rows[x]["ID"]));
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
SQL = SQL + "Select * From API_Execution_Result_Details Where [" + FieldName + "] like '%' + @SearchParam + '%'";} 
else { 
SQL = SQL + "Select * From API_Execution_Result_Details Where [" + FieldName + "] = @SearchParam";}

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
if (this.API_Execution_ID != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("API_Execution_ID_Param", this.API_Execution_ID));
SQLInsertFields += "[API_Execution_ID], ";
SQLValues += "@API_Execution_ID_Param, ";
}
if (this.Saved_File_FullPath != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Saved_File_FullPath_Param", this.Saved_File_FullPath));
SQLInsertFields += "[Saved_File_FullPath], ";
SQLValues += "@Saved_File_FullPath_Param, ";
}
if (this.RAW_Return_Headers != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("RAW_Return_Headers_Param", this.RAW_Return_Headers));
SQLInsertFields += "[RAW_Return_Headers], ";
SQLValues += "@RAW_Return_Headers_Param, ";
}
if (this.RAW_Return_Body != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("RAW_Return_Body_Param", this.RAW_Return_Body));
SQLInsertFields += "[RAW_Return_Body], ";
SQLValues += "@RAW_Return_Body_Param, ";
}
if (this.JSON_OBJECT != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("JSON_OBJECT_Param", this.JSON_OBJECT));
SQLInsertFields += "[JSON_OBJECT], ";
SQLValues += "@JSON_OBJECT_Param, ";
}
if (this.JSON_INT != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("JSON_INT_Param", this.JSON_INT));
SQLInsertFields += "[JSON_INT], ";
SQLValues += "@JSON_INT_Param, ";
}
if (this.Comments != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Comments_Param", this.Comments));
SQLInsertFields += "[Comments], ";
SQLValues += "@Comments_Param, ";
}
if (this.Success != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Success_Param", this.Success));
SQLInsertFields += "[Success], ";
SQLValues += "@Success_Param, ";
}
if (this.DateAdded != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("DateAdded_Param", this.DateAdded));
SQLInsertFields += "[DateAdded], ";
SQLValues += "@DateAdded_Param, ";
}
if (this.DateModified != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("DateModified_Param", this.DateModified));
SQLInsertFields += "[DateModified], ";
SQLValues += "@DateModified_Param, ";
}
SQLInsertFields = SQLInsertFields.TrimEnd(", ".ToCharArray());
SQLValues = SQLValues.TrimEnd(", ".ToCharArray());
string _SQL = "Insert Into [API_Execution_Result_Details] ( " + SQLInsertFields + ") Values (" + SQLValues + ")";
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
if (this.API_Execution_ID == Guid.Empty){
_Params.Add(new System.Data.SqlClient.SqlParameter("API_Execution_ID_Param", DBNull.Value));
SQLInsertFields += "[API_Execution_ID] = @API_Execution_ID_Param, ";
}else if (this.API_Execution_ID != null) {
_Params.Add(new System.Data.SqlClient.SqlParameter("API_Execution_ID_Param", this.API_Execution_ID));
SQLInsertFields += "[API_Execution_ID] = @API_Execution_ID_Param, ";
}
if (this.Saved_File_FullPath != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Saved_File_FullPath_Param", this.Saved_File_FullPath));
SQLInsertFields += "[Saved_File_FullPath] = @Saved_File_FullPath_Param, ";
}
if (this.RAW_Return_Headers != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("RAW_Return_Headers_Param", this.RAW_Return_Headers));
SQLInsertFields += "[RAW_Return_Headers] = @RAW_Return_Headers_Param, ";
}
if (this.RAW_Return_Body != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("RAW_Return_Body_Param", this.RAW_Return_Body));
SQLInsertFields += "[RAW_Return_Body] = @RAW_Return_Body_Param, ";
}
if (this.JSON_OBJECT != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("JSON_OBJECT_Param", this.JSON_OBJECT));
SQLInsertFields += "[JSON_OBJECT] = @JSON_OBJECT_Param, ";
}
if (this.JSON_INT != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("JSON_INT_Param", this.JSON_INT));
SQLInsertFields += "[JSON_INT] = @JSON_INT_Param, ";
}
if (this.Comments != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Comments_Param", this.Comments));
SQLInsertFields += "[Comments] = @Comments_Param, ";
}
if (this.Success != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Success_Param", this.Success));
SQLInsertFields += "[Success] = @Success_Param, ";
}
if (this.DateAdded != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("DateAdded_Param", this.DateAdded));
SQLInsertFields += "[DateAdded] = @DateAdded_Param, ";
}
if (this.DateModified != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("DateModified_Param", DateTime.Now));
SQLInsertFields += "[DateModified] = @DateModified_Param, ";
}
SQLInsertFields = SQLInsertFields.TrimEnd(", ".ToCharArray());
SQLValues = SQLValues.TrimEnd("AND ".ToCharArray());
string _SQL = "Update [API_Execution_Result_Details] set " + SQLInsertFields + " Where " + SQLValues;
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
if (this.API_Execution_ID != null){ 
}
if (this.Saved_File_FullPath != null){ 
}
if (this.RAW_Return_Headers != null){ 
}
if (this.RAW_Return_Body != null){ 
}
if (this.JSON_OBJECT != null){ 
}
if (this.JSON_INT != null){ 
}
if (this.Comments != null){ 
}
if (this.Success != null){ 
}
if (this.DateAdded != null){ 
}
if (this.DateModified != null){ 
}
SQLValues = SQLValues.TrimEnd("AND ".ToCharArray());
string _SQL = "Delete From [API_Execution_Result_Details] Where " + SQLValues;
DataAccess.RunCommand(_SQL, _Params.ToList<System.Data.IDataParameter>(), false, System.Data.CommandType.Text);
}}

	}
}