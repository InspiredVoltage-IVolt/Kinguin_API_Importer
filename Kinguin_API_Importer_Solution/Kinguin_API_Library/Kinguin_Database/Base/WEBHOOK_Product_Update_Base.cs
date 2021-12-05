
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
	public class WEBHOOK_Product_Update_CoreClass : ACT.Plugins.ACT_Core, ACT.Core.Interfaces.DataAccess.I_DataObject 
	{
	#region Private Fields

	private string _LocalConnectionString = "";

		private Guid? __ID;
		private string __ID_Description = "";
		private string __XdashEventdashName;
		private string __XdashEventdashName_Description = "";
		private string __XdashEventdashSecret;
		private string __XdashEventdashSecret_Description = "";
		private string __RAW_PAYLOAD;
		private string __RAW_PAYLOAD_Description = "";
		private string __RAW_SecurityInfo;
		private string __RAW_SecurityInfo_Description = "";
		private int? __KinguinId;
		private string __KinguinId_Description = "";
		private string __ProductId;
		private string __ProductId_Description = "";
		private string __UpdateAt;
		private string __UpdateAt_Description = "";
		private bool? __Processed;
		private string __Processed_Description = "";
		private DateTime? __ProcessedOn;
		private string __ProcessedOn_Description = "";
		private bool? __IsTest;
		private string __IsTest_Description = "";
		private DateTime? __DateAdded;
		private string __DateAdded_Description = "";

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

		public virtual string XdashEventdashName
		{
			get { return __XdashEventdashName; }
			set { __XdashEventdashName = value; }
		}

		public virtual string XdashEventdashName_Description
		{
			get { return __XdashEventdashName_Description; }
			set { __XdashEventdashName_Description = value; }
		}

		public virtual string XdashEventdashSecret
		{
			get { return __XdashEventdashSecret; }
			set { __XdashEventdashSecret = value; }
		}

		public virtual string XdashEventdashSecret_Description
		{
			get { return __XdashEventdashSecret_Description; }
			set { __XdashEventdashSecret_Description = value; }
		}

		public virtual string RAW_PAYLOAD
		{
			get { return __RAW_PAYLOAD; }
			set { __RAW_PAYLOAD = value; }
		}

		public virtual string RAW_PAYLOAD_Description
		{
			get { return __RAW_PAYLOAD_Description; }
			set { __RAW_PAYLOAD_Description = value; }
		}

		public virtual string RAW_SecurityInfo
		{
			get { return __RAW_SecurityInfo; }
			set { __RAW_SecurityInfo = value; }
		}

		public virtual string RAW_SecurityInfo_Description
		{
			get { return __RAW_SecurityInfo_Description; }
			set { __RAW_SecurityInfo_Description = value; }
		}

		public virtual int? KinguinId
		{
			get { return __KinguinId; }
			set { __KinguinId = value; }
		}

		public virtual string KinguinId_Description
		{
			get { return __KinguinId_Description; }
			set { __KinguinId_Description = value; }
		}

		public virtual string ProductId
		{
			get { return __ProductId; }
			set { __ProductId = value; }
		}

		public virtual string ProductId_Description
		{
			get { return __ProductId_Description; }
			set { __ProductId_Description = value; }
		}

		public virtual string UpdateAt
		{
			get { return __UpdateAt; }
			set { __UpdateAt = value; }
		}

		public virtual string UpdateAt_Description
		{
			get { return __UpdateAt_Description; }
			set { __UpdateAt_Description = value; }
		}

		public virtual bool? Processed
		{
			get { return __Processed; }
			set { __Processed = value; }
		}

		public virtual string Processed_Description
		{
			get { return __Processed_Description; }
			set { __Processed_Description = value; }
		}

		public virtual DateTime? ProcessedOn
		{
			get { return __ProcessedOn; }
			set { __ProcessedOn = value; }
		}

		public virtual string ProcessedOn_Description
		{
			get { return __ProcessedOn_Description; }
			set { __ProcessedOn_Description = value; }
		}

		public virtual bool? IsTest
		{
			get { return __IsTest; }
			set { __IsTest = value; }
		}

		public virtual string IsTest_Description
		{
			get { return __IsTest_Description; }
			set { __IsTest_Description = value; }
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
	
		public WEBHOOK_Product_Update_CoreClass(string localConnectionString = ""){ LocalConnectionString = localConnectionString; }


		public WEBHOOK_Product_Update_CoreClass(Guid? ID, string localConnectionString = "") 
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
		var SQL = "Select * From WEBHOOK_Product_Update Where [ID] = @IDParam";

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

		public static List<WEBHOOK_Product_Update> GetWEBHOOK_Product_Update(I_DbWhereStatement Where, string sql = "", string LocalConnectionString = "")
		{
		List<WEBHOOK_Product_Update> _TmpReturn = new List<WEBHOOK_Product_Update>();
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		if (LocalConnectionString == "") {

			DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		}

		else { 

			DataAccess.Open(LocalConnectionString);
		}

		string _Where = DataAccess.GenerateWhereStatement(Where, sql);
		var _Params = DataAccess.GenerateWhereStatementParameters(Where);
		var QR = DataAccess.RunCommand("Select [ID] From WEBHOOK_Product_Update Where " + _Where, _Params, true, System.Data.CommandType.Text);
		if (QR.Tables[0].Rows.Count > 0)
		{
		    foreach (System.Data.DataRow r in QR.Tables[0].Rows)
		    {
		        _TmpReturn.Add(new WEBHOOK_Product_Update((Guid?)r["ID"]));
		    }
		}
return _TmpReturn;
		}}

public static List<WEBHOOK_Product_Update> Search(string FieldName, string SearchText, bool UseContains = false, string LocalConnectionString = "")
{
List<WEBHOOK_Product_Update> _TmpReturn = new List<WEBHOOK_Product_Update>();
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
SQL = SQL + "Select WEBHOOK_Product_Update.ID From WEBHOOK_Product_Update Where [" + FieldName + "] like '%' + @SearchParam + '%'";
} 
else { 
SQL = SQL + "Select WEBHOOK_Product_Update.ID From WEBHOOK_Product_Update Where [" + FieldName + "] = @SearchParam";
}

var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
if (Result.Tables[0].Rows.Count > 0)
{
for (int x = 0; x < Result.Tables[0].Rows.Count; x++)
{
if (Result.Tables[0].Rows[x][0] != DBNull.Value)
{
_TmpReturn.Add(new WEBHOOK_Product_Update((Guid)Result.Tables[0].Rows[x]["ID"]));
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
SQL = SQL + "Select * From ( Select *, ROW_NUMBER() Over(order by " + OrderByStatement + ") as RowNum From WEBHOOK_Product_Update Where [" + FieldName + "] like '%' + @SearchParam + '%') as T Where T.RowNum > " + (Start-1).ToString() + " AND T.RowNum < " + (Start + Increment).ToString();
} 
else { 
SQL = SQL + "Select * From ( Select *, ROW_NUMBER() Over(order by " + OrderByStatement + ") as RowNum From WEBHOOK_Product_Update Where [" + FieldName + "] = @SearchParam) as T Where T.RowNum > " + (Start-1).ToString() + " AND T.RowNum < " + (Start + Increment).ToString();
}

var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
return Result.Tables[0];
}

}

public static List<WEBHOOK_Product_Update> Search(Dictionary<string,string> FieldValues, string LocalConnectionString = "")
{
List<WEBHOOK_Product_Update> _TmpReturn = new List<WEBHOOK_Product_Update>();
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
SQL = SQL + "Select WEBHOOK_Product_Update.ID From WEBHOOK_Product_Update where ";
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
_TmpReturn.Add(new WEBHOOK_Product_Update((Guid)Result.Tables[0].Rows[x]["ID"]));
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
SQL = SQL + "Select * From WEBHOOK_Product_Update Where [" + FieldName + "] like '%' + @SearchParam + '%'";} 
else { 
SQL = SQL + "Select * From WEBHOOK_Product_Update Where [" + FieldName + "] = @SearchParam";}

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
if (this.XdashEventdashName != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("XdashEventdashName_Param", this.XdashEventdashName));
SQLInsertFields += "[X-Event-Name], ";
SQLValues += "@XdashEventdashName_Param, ";
}
if (this.XdashEventdashSecret != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("XdashEventdashSecret_Param", this.XdashEventdashSecret));
SQLInsertFields += "[X-Event-Secret], ";
SQLValues += "@XdashEventdashSecret_Param, ";
}
if (this.RAW_PAYLOAD != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("RAW_PAYLOAD_Param", this.RAW_PAYLOAD));
SQLInsertFields += "[RAW_PAYLOAD], ";
SQLValues += "@RAW_PAYLOAD_Param, ";
}
if (this.RAW_SecurityInfo != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("RAW_SecurityInfo_Param", this.RAW_SecurityInfo));
SQLInsertFields += "[RAW_SecurityInfo], ";
SQLValues += "@RAW_SecurityInfo_Param, ";
}
if (this.KinguinId != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("KinguinId_Param", this.KinguinId));
SQLInsertFields += "[KinguinId], ";
SQLValues += "@KinguinId_Param, ";
}
if (this.ProductId != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("ProductId_Param", this.ProductId));
SQLInsertFields += "[ProductId], ";
SQLValues += "@ProductId_Param, ";
}
if (this.UpdateAt != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("UpdateAt_Param", this.UpdateAt));
SQLInsertFields += "[UpdateAt], ";
SQLValues += "@UpdateAt_Param, ";
}
if (this.Processed != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Processed_Param", this.Processed));
SQLInsertFields += "[Processed], ";
SQLValues += "@Processed_Param, ";
}
if (this.ProcessedOn != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("ProcessedOn_Param", this.ProcessedOn));
SQLInsertFields += "[ProcessedOn], ";
SQLValues += "@ProcessedOn_Param, ";
}
if (this.IsTest != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("IsTest_Param", this.IsTest));
SQLInsertFields += "[IsTest], ";
SQLValues += "@IsTest_Param, ";
}
if (this.DateAdded != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("DateAdded_Param", this.DateAdded));
SQLInsertFields += "[DateAdded], ";
SQLValues += "@DateAdded_Param, ";
}
SQLInsertFields = SQLInsertFields.TrimEnd(", ".ToCharArray());
SQLValues = SQLValues.TrimEnd(", ".ToCharArray());
string _SQL = "Insert Into [WEBHOOK_Product_Update] ( " + SQLInsertFields + ") Values (" + SQLValues + ")";
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
if (this.XdashEventdashName != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("XdashEventdashName_Param", this.XdashEventdashName));
SQLInsertFields += "[X-Event-Name] = @XdashEventdashName_Param, ";
}
if (this.XdashEventdashSecret != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("XdashEventdashSecret_Param", this.XdashEventdashSecret));
SQLInsertFields += "[X-Event-Secret] = @XdashEventdashSecret_Param, ";
}
if (this.RAW_PAYLOAD != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("RAW_PAYLOAD_Param", this.RAW_PAYLOAD));
SQLInsertFields += "[RAW_PAYLOAD] = @RAW_PAYLOAD_Param, ";
}
if (this.RAW_SecurityInfo != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("RAW_SecurityInfo_Param", this.RAW_SecurityInfo));
SQLInsertFields += "[RAW_SecurityInfo] = @RAW_SecurityInfo_Param, ";
}
if (this.KinguinId != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("KinguinId_Param", this.KinguinId));
SQLInsertFields += "[KinguinId] = @KinguinId_Param, ";
}
if (this.ProductId != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("ProductId_Param", this.ProductId));
SQLInsertFields += "[ProductId] = @ProductId_Param, ";
}
if (this.UpdateAt != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("UpdateAt_Param", this.UpdateAt));
SQLInsertFields += "[UpdateAt] = @UpdateAt_Param, ";
}
if (this.Processed != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Processed_Param", this.Processed));
SQLInsertFields += "[Processed] = @Processed_Param, ";
}
if (this.ProcessedOn != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("ProcessedOn_Param", this.ProcessedOn));
SQLInsertFields += "[ProcessedOn] = @ProcessedOn_Param, ";
}
if (this.IsTest != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("IsTest_Param", this.IsTest));
SQLInsertFields += "[IsTest] = @IsTest_Param, ";
}
if (this.DateAdded != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("DateAdded_Param", this.DateAdded));
SQLInsertFields += "[DateAdded] = @DateAdded_Param, ";
}
SQLInsertFields = SQLInsertFields.TrimEnd(", ".ToCharArray());
SQLValues = SQLValues.TrimEnd("AND ".ToCharArray());
string _SQL = "Update [WEBHOOK_Product_Update] set " + SQLInsertFields + " Where " + SQLValues;
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
if (this.XdashEventdashName != null){ 
}
if (this.XdashEventdashSecret != null){ 
}
if (this.RAW_PAYLOAD != null){ 
}
if (this.RAW_SecurityInfo != null){ 
}
if (this.KinguinId != null){ 
}
if (this.ProductId != null){ 
}
if (this.UpdateAt != null){ 
}
if (this.Processed != null){ 
}
if (this.ProcessedOn != null){ 
}
if (this.IsTest != null){ 
}
if (this.DateAdded != null){ 
}
SQLValues = SQLValues.TrimEnd("AND ".ToCharArray());
string _SQL = "Delete From [WEBHOOK_Product_Update] Where " + SQLValues;
DataAccess.RunCommand(_SQL, _Params.ToList<System.Data.IDataParameter>(), false, System.Data.CommandType.Text);
}}

	}
}