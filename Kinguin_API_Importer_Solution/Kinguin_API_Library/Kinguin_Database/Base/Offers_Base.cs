
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
	public class Offers_CoreClass : ACT.Plugins.ACT_Core, ACT.Core.Interfaces.DataAccess.I_DataObject 
	{
	#region Private Fields

	private string _LocalConnectionString = "";

		private int? __ID;
		private string __ID_Description = "";
		private int? __Merchant_ID;
		private string __Merchant_ID_Description = "";
		private string __Name;
		private string __Name_Description = "";
		private string __OfferID;
		private string __OfferID_Description = "";
		private decimal? __Price;
		private string __Price_Description = "";
		private int? __Quantity;
		private string __Quantity_Description = "";
		private int? __textQty;
		private string __textQty_Description = "";
		private bool? __isPreorder;
		private string __isPreorder_Description = "";
		private DateTime? __ReleaseDate;
		private string __ReleaseDate_Description = "";
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

		public virtual int? Merchant_ID
		{
			get { return __Merchant_ID; }
			set { __Merchant_ID = value; }
		}

		public virtual string Merchant_ID_Description
		{
			get { return __Merchant_ID_Description; }
			set { __Merchant_ID_Description = value; }
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

		public virtual string OfferID
		{
			get { return __OfferID; }
			set { __OfferID = value; }
		}

		public virtual string OfferID_Description
		{
			get { return __OfferID_Description; }
			set { __OfferID_Description = value; }
		}

		public virtual decimal? Price
		{
			get { return __Price; }
			set { __Price = value; }
		}

		public virtual string Price_Description
		{
			get { return __Price_Description; }
			set { __Price_Description = value; }
		}

		public virtual int? Quantity
		{
			get { return __Quantity; }
			set { __Quantity = value; }
		}

		public virtual string Quantity_Description
		{
			get { return __Quantity_Description; }
			set { __Quantity_Description = value; }
		}

		public virtual int? textQty
		{
			get { return __textQty; }
			set { __textQty = value; }
		}

		public virtual string textQty_Description
		{
			get { return __textQty_Description; }
			set { __textQty_Description = value; }
		}

		public virtual bool? isPreorder
		{
			get { return __isPreorder; }
			set { __isPreorder = value; }
		}

		public virtual string isPreorder_Description
		{
			get { return __isPreorder_Description; }
			set { __isPreorder_Description = value; }
		}

		public virtual DateTime? ReleaseDate
		{
			get { return __ReleaseDate; }
			set { __ReleaseDate = value; }
		}

		public virtual string ReleaseDate_Description
		{
			get { return __ReleaseDate_Description; }
			set { __ReleaseDate_Description = value; }
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
	
		public Offers_CoreClass(string localConnectionString = ""){ LocalConnectionString = localConnectionString; }


		public Offers_CoreClass(int? ID, string localConnectionString = "") 
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
		var SQL = "Select * From Offers Where [ID] = @IDParam";

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

		public static List<Offers> GetOffers(I_DbWhereStatement Where, string sql = "", string LocalConnectionString = "")
		{
		List<Offers> _TmpReturn = new List<Offers>();
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		if (LocalConnectionString == "") {

			DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		}

		else { 

			DataAccess.Open(LocalConnectionString);
		}

		string _Where = DataAccess.GenerateWhereStatement(Where, sql);
		var _Params = DataAccess.GenerateWhereStatementParameters(Where);
		var QR = DataAccess.RunCommand("Select [ID] From Offers Where " + _Where, _Params, true, System.Data.CommandType.Text);
		if (QR.Tables[0].Rows.Count > 0)
		{
		    foreach (System.Data.DataRow r in QR.Tables[0].Rows)
		    {
		        _TmpReturn.Add(new Offers((int?)r["ID"]));
		    }
		}
return _TmpReturn;
		}}

public static List<Offers> Search(string FieldName, string SearchText, bool UseContains = false, string LocalConnectionString = "")
{
List<Offers> _TmpReturn = new List<Offers>();
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
SQL = SQL + "Select Offers.ID From Offers Where [" + FieldName + "] like '%' + @SearchParam + '%'";
} 
else { 
SQL = SQL + "Select Offers.ID From Offers Where [" + FieldName + "] = @SearchParam";
}

var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
if (Result.Tables[0].Rows.Count > 0)
{
for (int x = 0; x < Result.Tables[0].Rows.Count; x++)
{
if (Result.Tables[0].Rows[x][0] != DBNull.Value)
{
_TmpReturn.Add(new Offers((int)Result.Tables[0].Rows[x]["ID"]));
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
SQL = SQL + "Select * From ( Select *, ROW_NUMBER() Over(order by " + OrderByStatement + ") as RowNum From Offers Where [" + FieldName + "] like '%' + @SearchParam + '%') as T Where T.RowNum > " + (Start-1).ToString() + " AND T.RowNum < " + (Start + Increment).ToString();
} 
else { 
SQL = SQL + "Select * From ( Select *, ROW_NUMBER() Over(order by " + OrderByStatement + ") as RowNum From Offers Where [" + FieldName + "] = @SearchParam) as T Where T.RowNum > " + (Start-1).ToString() + " AND T.RowNum < " + (Start + Increment).ToString();
}

var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
return Result.Tables[0];
}

}

public static List<Offers> Search(Dictionary<string,string> FieldValues, string LocalConnectionString = "")
{
List<Offers> _TmpReturn = new List<Offers>();
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
SQL = SQL + "Select Offers.ID From Offers where ";
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
_TmpReturn.Add(new Offers((int)Result.Tables[0].Rows[x]["ID"]));
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
SQL = SQL + "Select * From Offers Where [" + FieldName + "] like '%' + @SearchParam + '%'";} 
else { 
SQL = SQL + "Select * From Offers Where [" + FieldName + "] = @SearchParam";}

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
if (this.Merchant_ID != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Merchant_ID_Param", this.Merchant_ID));
SQLInsertFields += "[Merchant_ID], ";
SQLValues += "@Merchant_ID_Param, ";
}
if (this.Name != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Name_Param", this.Name));
SQLInsertFields += "[Name], ";
SQLValues += "@Name_Param, ";
}
if (this.OfferID != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("OfferID_Param", this.OfferID));
SQLInsertFields += "[OfferID], ";
SQLValues += "@OfferID_Param, ";
}
if (this.Price != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Price_Param", this.Price));
SQLInsertFields += "[Price], ";
SQLValues += "@Price_Param, ";
}
if (this.Quantity != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Quantity_Param", this.Quantity));
SQLInsertFields += "[Quantity], ";
SQLValues += "@Quantity_Param, ";
}
if (this.textQty != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("textQty_Param", this.textQty));
SQLInsertFields += "[textQty], ";
SQLValues += "@textQty_Param, ";
}
if (this.isPreorder != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("isPreorder_Param", this.isPreorder));
SQLInsertFields += "[isPreorder], ";
SQLValues += "@isPreorder_Param, ";
}
if (this.ReleaseDate != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("ReleaseDate_Param", this.ReleaseDate));
SQLInsertFields += "[ReleaseDate], ";
SQLValues += "@ReleaseDate_Param, ";
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
string _SQL = "Insert Into [Offers] ( " + SQLInsertFields + ") Values (" + SQLValues + ")";
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
if (this.Merchant_ID != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Merchant_ID_Param", this.Merchant_ID));
SQLInsertFields += "[Merchant_ID] = @Merchant_ID_Param, ";
}
if (this.Name != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Name_Param", this.Name));
SQLInsertFields += "[Name] = @Name_Param, ";
}
if (this.OfferID != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("OfferID_Param", this.OfferID));
SQLInsertFields += "[OfferID] = @OfferID_Param, ";
}
if (this.Price != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Price_Param", this.Price));
SQLInsertFields += "[Price] = @Price_Param, ";
}
if (this.Quantity != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Quantity_Param", this.Quantity));
SQLInsertFields += "[Quantity] = @Quantity_Param, ";
}
if (this.textQty != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("textQty_Param", this.textQty));
SQLInsertFields += "[textQty] = @textQty_Param, ";
}
if (this.isPreorder != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("isPreorder_Param", this.isPreorder));
SQLInsertFields += "[isPreorder] = @isPreorder_Param, ";
}
if (this.ReleaseDate != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("ReleaseDate_Param", this.ReleaseDate));
SQLInsertFields += "[ReleaseDate] = @ReleaseDate_Param, ";
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
string _SQL = "Update [Offers] set " + SQLInsertFields + " Where " + SQLValues;
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
if (this.Merchant_ID != null){ 
}
if (this.Name != null){ 
}
if (this.OfferID != null){ 
}
if (this.Price != null){ 
}
if (this.Quantity != null){ 
}
if (this.textQty != null){ 
}
if (this.isPreorder != null){ 
}
if (this.ReleaseDate != null){ 
}
if (this.DateAdded != null){ 
}
if (this.DateModified != null){ 
}
SQLValues = SQLValues.TrimEnd("AND ".ToCharArray());
string _SQL = "Delete From [Offers] Where " + SQLValues;
DataAccess.RunCommand(_SQL, _Params.ToList<System.Data.IDataParameter>(), false, System.Data.CommandType.Text);
}}

	}
}