
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
	public class Videos_CoreClass : ACT.Plugins.ACT_Core, ACT.Core.Interfaces.DataAccess.I_DataObject 
	{
	#region Private Fields

	private string _LocalConnectionString = "";

		private int? __ID;
		private string __ID_Description = "";
		private string __Name;
		private string __Name_Description = "";
		private string __Video_ID;
		private string __Video_ID_Description = "";
		private DateTime? __DateAdded;
		private string __DateAdded_Description = "";
		private DateTime? __DateModified;
		private string __DateModified_Description = "";

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

		public virtual string Name
		{
			get { return __Name; }
			set { __Name = value; }
		}

		public virtual string Name_Description
		{
			get { return __Name_Description; }
			set { __Name_Description = value; }
		}

		public virtual string Video_ID
		{
			get { return __Video_ID; }
			set { __Video_ID = value; }
		}

		public virtual string Video_ID_Description
		{
			get { return __Video_ID_Description; }
			set { __Video_ID_Description = value; }
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
	
		public Videos_CoreClass(string localConnectionString = ""){ LocalConnectionString = localConnectionString; }


		public Videos_CoreClass(int? ID, string localConnectionString = "") 
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
		var SQL = "Select * From Videos Where [ID] = @IDParam";

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

		public static List<Videos> GetVideos(I_DbWhereStatement Where, string sql = "", string LocalConnectionString = "")
		{
		List<Videos> _TmpReturn = new List<Videos>();
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		if (LocalConnectionString == "") {

			DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		}

		else { 

			DataAccess.Open(LocalConnectionString);
		}

		string _Where = DataAccess.GenerateWhereStatement(Where, sql);
		var _Params = DataAccess.GenerateWhereStatementParameters(Where);
		var QR = DataAccess.RunCommand("Select [ID] From Videos Where " + _Where, _Params, true, System.Data.CommandType.Text);
		if (QR.Tables[0].Rows.Count > 0)
		{
		    foreach (System.Data.DataRow r in QR.Tables[0].Rows)
		    {
		        _TmpReturn.Add(new Videos((int?)r["ID"]));
		    }
		}
return _TmpReturn;
		}}

public static List<Videos> Search(string FieldName, string SearchText, bool UseContains = false, string LocalConnectionString = "")
{
List<Videos> _TmpReturn = new List<Videos>();
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
SQL = SQL + "Select Videos.ID From Videos Where [" + FieldName + "] like '%' + @SearchParam + '%'";
} 
else { 
SQL = SQL + "Select Videos.ID From Videos Where [" + FieldName + "] = @SearchParam";
}

var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
if (Result.Tables[0].Rows.Count > 0)
{
for (int x = 0; x < Result.Tables[0].Rows.Count; x++)
{
if (Result.Tables[0].Rows[x][0] != DBNull.Value)
{
_TmpReturn.Add(new Videos((int)Result.Tables[0].Rows[x]["ID"]));
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
SQL = SQL + "Select * From ( Select *, ROW_NUMBER() Over(order by " + OrderByStatement + ") as RowNum From Videos Where [" + FieldName + "] like '%' + @SearchParam + '%') as T Where T.RowNum > " + (Start-1).ToString() + " AND T.RowNum < " + (Start + Increment).ToString();
} 
else { 
SQL = SQL + "Select * From ( Select *, ROW_NUMBER() Over(order by " + OrderByStatement + ") as RowNum From Videos Where [" + FieldName + "] = @SearchParam) as T Where T.RowNum > " + (Start-1).ToString() + " AND T.RowNum < " + (Start + Increment).ToString();
}

var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
return Result.Tables[0];
}

}

public static List<Videos> Search(Dictionary<string,string> FieldValues, string LocalConnectionString = "")
{
List<Videos> _TmpReturn = new List<Videos>();
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
SQL = SQL + "Select Videos.ID From Videos where ";
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
_TmpReturn.Add(new Videos((int)Result.Tables[0].Rows[x]["ID"]));
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
SQL = SQL + "Select * From Videos Where [" + FieldName + "] like '%' + @SearchParam + '%'";} 
else { 
SQL = SQL + "Select * From Videos Where [" + FieldName + "] = @SearchParam";}

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
if (this.Name != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Name_Param", this.Name));
SQLInsertFields += "[Name], ";
SQLValues += "@Name_Param, ";
}
if (this.Video_ID != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Video_ID_Param", this.Video_ID));
SQLInsertFields += "[Video_ID], ";
SQLValues += "@Video_ID_Param, ";
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
string _SQL = "Insert Into [Videos] ( " + SQLInsertFields + ") Values (" + SQLValues + ")";
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
if (this.Name != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Name_Param", this.Name));
SQLInsertFields += "[Name] = @Name_Param, ";
}
if (this.Video_ID != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Video_ID_Param", this.Video_ID));
SQLInsertFields += "[Video_ID] = @Video_ID_Param, ";
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
string _SQL = "Update [Videos] set " + SQLInsertFields + " Where " + SQLValues;
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
if (this.Name != null){ 
}
if (this.Video_ID != null){ 
}
if (this.DateAdded != null){ 
}
if (this.DateModified != null){ 
}
SQLValues = SQLValues.TrimEnd("AND ".ToCharArray());
string _SQL = "Delete From [Videos] Where " + SQLValues;
DataAccess.RunCommand(_SQL, _Params.ToList<System.Data.IDataParameter>(), false, System.Data.CommandType.Text);
}}

	}
}