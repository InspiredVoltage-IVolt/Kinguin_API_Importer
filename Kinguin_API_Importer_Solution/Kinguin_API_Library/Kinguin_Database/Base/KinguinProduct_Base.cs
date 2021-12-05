
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
	public class KinguinProduct_CoreClass : ACT.Plugins.ACT_Core, ACT.Core.Interfaces.DataAccess.I_DataObject 
	{
	#region Private Fields

	private string _LocalConnectionString = "";

		private int? __ID;
		private string __ID_Description = "";
		private string __Name;
		private string __Name_Description = "";
		private string __JSONFileName;
		private string __JSONFileName_Description = "";
		private string __Description;
		private string __Description_Description = "";
		private string __CoverImage;
		private string __CoverImage_Description = "";
		private string __CoverImageOriginal;
		private string __CoverImageOriginal_Description = "";
		private string __Platform;
		private string __Platform_Description = "";
		private DateTime? __ReleaseDate;
		private string __ReleaseDate_Description = "";
		private int? __Qty;
		private string __Qty_Description = "";
		private int? __TextQty;
		private string __TextQty_Description = "";
		private decimal? __Price;
		private string __Price_Description = "";
		private bool? __IsPreorder;
		private string __IsPreorder_Description = "";
		private int? __MetacriticScore;
		private string __MetacriticScore_Description = "";
		private string __RegionalLimitations;
		private string __RegionalLimitations_Description = "";
		private int? __RegionId;
		private string __RegionId_Description = "";
		private string __ActivationDetails;
		private string __ActivationDetails_Description = "";
		private int? __KinguinId;
		private string __KinguinId_Description = "";
		private string __ProductId;
		private string __ProductId_Description = "";
		private string __OriginalName;
		private string __OriginalName_Description = "";
		private int? __OffersCount;
		private string __OffersCount_Description = "";
		private int? __TotalQty;
		private string __TotalQty_Description = "";
		private DateTime? __UpdatedAt;
		private string __UpdatedAt_Description = "";

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

		public virtual string JSONFileName
		{
			get { return __JSONFileName; }
			set { __JSONFileName = value; }
		}

		public virtual string JSONFileName_Description
		{
			get { return __JSONFileName_Description; }
			set { __JSONFileName_Description = value; }
		}

		public virtual string Description
		{
			get { return __Description; }
			set { __Description = value; }
		}

		public virtual string Description_Description
		{
			get { return __Description_Description; }
			set { __Description_Description = value; }
		}

		public virtual string CoverImage
		{
			get { return __CoverImage; }
			set { __CoverImage = value; }
		}

		public virtual string CoverImage_Description
		{
			get { return __CoverImage_Description; }
			set { __CoverImage_Description = value; }
		}

		public virtual string CoverImageOriginal
		{
			get { return __CoverImageOriginal; }
			set { __CoverImageOriginal = value; }
		}

		public virtual string CoverImageOriginal_Description
		{
			get { return __CoverImageOriginal_Description; }
			set { __CoverImageOriginal_Description = value; }
		}

		public virtual string Platform
		{
			get { return __Platform; }
			set { __Platform = value; }
		}

		public virtual string Platform_Description
		{
			get { return __Platform_Description; }
			set { __Platform_Description = value; }
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

		public virtual int? Qty
		{
			get { return __Qty; }
			set { __Qty = value; }
		}

		public virtual string Qty_Description
		{
			get { return __Qty_Description; }
			set { __Qty_Description = value; }
		}

		public virtual int? TextQty
		{
			get { return __TextQty; }
			set { __TextQty = value; }
		}

		public virtual string TextQty_Description
		{
			get { return __TextQty_Description; }
			set { __TextQty_Description = value; }
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

		public virtual bool? IsPreorder
		{
			get { return __IsPreorder; }
			set { __IsPreorder = value; }
		}

		public virtual string IsPreorder_Description
		{
			get { return __IsPreorder_Description; }
			set { __IsPreorder_Description = value; }
		}

		public virtual int? MetacriticScore
		{
			get { return __MetacriticScore; }
			set { __MetacriticScore = value; }
		}

		public virtual string MetacriticScore_Description
		{
			get { return __MetacriticScore_Description; }
			set { __MetacriticScore_Description = value; }
		}

		public virtual string RegionalLimitations
		{
			get { return __RegionalLimitations; }
			set { __RegionalLimitations = value; }
		}

		public virtual string RegionalLimitations_Description
		{
			get { return __RegionalLimitations_Description; }
			set { __RegionalLimitations_Description = value; }
		}

		public virtual int? RegionId
		{
			get { return __RegionId; }
			set { __RegionId = value; }
		}

		public virtual string RegionId_Description
		{
			get { return __RegionId_Description; }
			set { __RegionId_Description = value; }
		}

		public virtual string ActivationDetails
		{
			get { return __ActivationDetails; }
			set { __ActivationDetails = value; }
		}

		public virtual string ActivationDetails_Description
		{
			get { return __ActivationDetails_Description; }
			set { __ActivationDetails_Description = value; }
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

		public virtual string OriginalName
		{
			get { return __OriginalName; }
			set { __OriginalName = value; }
		}

		public virtual string OriginalName_Description
		{
			get { return __OriginalName_Description; }
			set { __OriginalName_Description = value; }
		}

		public virtual int? OffersCount
		{
			get { return __OffersCount; }
			set { __OffersCount = value; }
		}

		public virtual string OffersCount_Description
		{
			get { return __OffersCount_Description; }
			set { __OffersCount_Description = value; }
		}

		public virtual int? TotalQty
		{
			get { return __TotalQty; }
			set { __TotalQty = value; }
		}

		public virtual string TotalQty_Description
		{
			get { return __TotalQty_Description; }
			set { __TotalQty_Description = value; }
		}

		public virtual DateTime? UpdatedAt
		{
			get { return __UpdatedAt; }
			set { __UpdatedAt = value; }
		}

		public virtual string UpdatedAt_Description
		{
			get { return __UpdatedAt_Description; }
			set { __UpdatedAt_Description = value; }
		}


	#endregion 


public static ACT.Core.Interfaces.DataAccess.I_DataAccess GetDataAccess()
{
	using( var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){ 
	DataAccess.Open(GenericStaticClass.DatabaseConnectionString);

	return DataAccess;}
}
	#region Public Child Tables


	public List<KinguinProduct_To_CheapestOfferId> Get_All_KinguinProduct_To_CheapestOfferId() { 

		List<KinguinProduct_To_CheapestOfferId> _TmpReturn = new List<KinguinProduct_To_CheapestOfferId>();
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
		_Params.Add(new System.Data.SqlClient.SqlParameter("IDParam", this.ReturnProperty("ID")));
		var SQL = "Select KinguinProduct_To_CheapestOfferId.ID From KinguinProduct_To_CheapestOfferId Where KinguinProduct_ID = @IDParam";
		var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);

		for (int rownumber = 0; rownumber < Result.Tables[0].Rows.Count; rownumber++ )
		{
			_TmpReturn.Add(new KinguinProduct_To_CheapestOfferId((int?)Result.Tables[0].Rows[rownumber]["ID"]));
		}

	return _TmpReturn;
	}}
	public List<KinguinProduct_To_Developers> Get_All_KinguinProduct_To_Developers() { 

		List<KinguinProduct_To_Developers> _TmpReturn = new List<KinguinProduct_To_Developers>();
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
		_Params.Add(new System.Data.SqlClient.SqlParameter("IDParam", this.ReturnProperty("ID")));
		var SQL = "Select KinguinProduct_To_Developers.ID From KinguinProduct_To_Developers Where KinguinProduct_ID = @IDParam";
		var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);

		for (int rownumber = 0; rownumber < Result.Tables[0].Rows.Count; rownumber++ )
		{
			_TmpReturn.Add(new KinguinProduct_To_Developers((int?)Result.Tables[0].Rows[rownumber]["ID"]));
		}

	return _TmpReturn;
	}}
	public List<KinguinProduct_To_Genres> Get_All_KinguinProduct_To_Genres() { 

		List<KinguinProduct_To_Genres> _TmpReturn = new List<KinguinProduct_To_Genres>();
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
		_Params.Add(new System.Data.SqlClient.SqlParameter("IDParam", this.ReturnProperty("ID")));
		var SQL = "Select KinguinProduct_To_Genres.ID From KinguinProduct_To_Genres Where KinguinProduct_ID = @IDParam";
		var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);

		for (int rownumber = 0; rownumber < Result.Tables[0].Rows.Count; rownumber++ )
		{
			_TmpReturn.Add(new KinguinProduct_To_Genres((int?)Result.Tables[0].Rows[rownumber]["ID"]));
		}

	return _TmpReturn;
	}}
	public List<KinguinProduct_To_Languages> Get_All_KinguinProduct_To_Languages() { 

		List<KinguinProduct_To_Languages> _TmpReturn = new List<KinguinProduct_To_Languages>();
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
		_Params.Add(new System.Data.SqlClient.SqlParameter("IDParam", this.ReturnProperty("ID")));
		var SQL = "Select KinguinProduct_To_Languages.ID From KinguinProduct_To_Languages Where KinguinProduct_ID = @IDParam";
		var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);

		for (int rownumber = 0; rownumber < Result.Tables[0].Rows.Count; rownumber++ )
		{
			_TmpReturn.Add(new KinguinProduct_To_Languages((int?)Result.Tables[0].Rows[rownumber]["ID"]));
		}

	return _TmpReturn;
	}}
	public List<KinguinProduct_To_MerchantName> Get_All_KinguinProduct_To_MerchantName() { 

		List<KinguinProduct_To_MerchantName> _TmpReturn = new List<KinguinProduct_To_MerchantName>();
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
		_Params.Add(new System.Data.SqlClient.SqlParameter("IDParam", this.ReturnProperty("ID")));
		var SQL = "Select KinguinProduct_To_MerchantName.ID From KinguinProduct_To_MerchantName Where KinguinProduct_ID = @IDParam";
		var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);

		for (int rownumber = 0; rownumber < Result.Tables[0].Rows.Count; rownumber++ )
		{
			_TmpReturn.Add(new KinguinProduct_To_MerchantName((int?)Result.Tables[0].Rows[rownumber]["ID"]));
		}

	return _TmpReturn;
	}}
	public List<KinguinProduct_To_Publishers> Get_All_KinguinProduct_To_Publishers() { 

		List<KinguinProduct_To_Publishers> _TmpReturn = new List<KinguinProduct_To_Publishers>();
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
		_Params.Add(new System.Data.SqlClient.SqlParameter("IDParam", this.ReturnProperty("ID")));
		var SQL = "Select KinguinProduct_To_Publishers.ID From KinguinProduct_To_Publishers Where KinguinProduct_ID = @IDParam";
		var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);

		for (int rownumber = 0; rownumber < Result.Tables[0].Rows.Count; rownumber++ )
		{
			_TmpReturn.Add(new KinguinProduct_To_Publishers((int?)Result.Tables[0].Rows[rownumber]["ID"]));
		}

	return _TmpReturn;
	}}
	public List<KinguinProduct_To_Tags> Get_All_KinguinProduct_To_Tags() { 

		List<KinguinProduct_To_Tags> _TmpReturn = new List<KinguinProduct_To_Tags>();
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
		_Params.Add(new System.Data.SqlClient.SqlParameter("IDParam", this.ReturnProperty("ID")));
		var SQL = "Select KinguinProduct_To_Tags.ID From KinguinProduct_To_Tags Where KinguinProduct_ID = @IDParam";
		var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);

		for (int rownumber = 0; rownumber < Result.Tables[0].Rows.Count; rownumber++ )
		{
			_TmpReturn.Add(new KinguinProduct_To_Tags((int?)Result.Tables[0].Rows[rownumber]["ID"]));
		}

	return _TmpReturn;
	}}
	#endregion 

	#region Public Parent Tables


	#endregion 
	
		public KinguinProduct_CoreClass(string localConnectionString = ""){ LocalConnectionString = localConnectionString; }


		public KinguinProduct_CoreClass(int? ID, string localConnectionString = "") 
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
		var SQL = "Select * From KinguinProduct Where [ID] = @IDParam";

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

		public static List<KinguinProduct> GetKinguinProduct(I_DbWhereStatement Where, string sql = "", string LocalConnectionString = "")
		{
		List<KinguinProduct> _TmpReturn = new List<KinguinProduct>();
		using(var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent()){
		if (LocalConnectionString == "") {

			DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
		}

		else { 

			DataAccess.Open(LocalConnectionString);
		}

		string _Where = DataAccess.GenerateWhereStatement(Where, sql);
		var _Params = DataAccess.GenerateWhereStatementParameters(Where);
		var QR = DataAccess.RunCommand("Select [ID] From KinguinProduct Where " + _Where, _Params, true, System.Data.CommandType.Text);
		if (QR.Tables[0].Rows.Count > 0)
		{
		    foreach (System.Data.DataRow r in QR.Tables[0].Rows)
		    {
		        _TmpReturn.Add(new KinguinProduct((int?)r["ID"]));
		    }
		}
return _TmpReturn;
		}}

public static List<KinguinProduct> Search(string FieldName, string SearchText, bool UseContains = false, string LocalConnectionString = "")
{
List<KinguinProduct> _TmpReturn = new List<KinguinProduct>();
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
SQL = SQL + "Select KinguinProduct.ID From KinguinProduct Where [" + FieldName + "] like '%' + @SearchParam + '%'";
} 
else { 
SQL = SQL + "Select KinguinProduct.ID From KinguinProduct Where [" + FieldName + "] = @SearchParam";
}

var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
if (Result.Tables[0].Rows.Count > 0)
{
for (int x = 0; x < Result.Tables[0].Rows.Count; x++)
{
if (Result.Tables[0].Rows[x][0] != DBNull.Value)
{
_TmpReturn.Add(new KinguinProduct((int)Result.Tables[0].Rows[x]["ID"]));
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
SQL = SQL + "Select * From ( Select *, ROW_NUMBER() Over(order by " + OrderByStatement + ") as RowNum From KinguinProduct Where [" + FieldName + "] like '%' + @SearchParam + '%') as T Where T.RowNum > " + (Start-1).ToString() + " AND T.RowNum < " + (Start + Increment).ToString();
} 
else { 
SQL = SQL + "Select * From ( Select *, ROW_NUMBER() Over(order by " + OrderByStatement + ") as RowNum From KinguinProduct Where [" + FieldName + "] = @SearchParam) as T Where T.RowNum > " + (Start-1).ToString() + " AND T.RowNum < " + (Start + Increment).ToString();
}

var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
return Result.Tables[0];
}

}

public static List<KinguinProduct> Search(Dictionary<string,string> FieldValues, string LocalConnectionString = "")
{
List<KinguinProduct> _TmpReturn = new List<KinguinProduct>();
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
SQL = SQL + "Select KinguinProduct.ID From KinguinProduct where ";
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
_TmpReturn.Add(new KinguinProduct((int)Result.Tables[0].Rows[x]["ID"]));
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
SQL = SQL + "Select * From KinguinProduct Where [" + FieldName + "] like '%' + @SearchParam + '%'";} 
else { 
SQL = SQL + "Select * From KinguinProduct Where [" + FieldName + "] = @SearchParam";}

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
if (this.JSONFileName != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("JSONFileName_Param", this.JSONFileName));
SQLInsertFields += "[JSONFileName], ";
SQLValues += "@JSONFileName_Param, ";
}
if (this.Description != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Description_Param", this.Description));
SQLInsertFields += "[Description], ";
SQLValues += "@Description_Param, ";
}
if (this.CoverImage != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("CoverImage_Param", this.CoverImage));
SQLInsertFields += "[CoverImage], ";
SQLValues += "@CoverImage_Param, ";
}
if (this.CoverImageOriginal != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("CoverImageOriginal_Param", this.CoverImageOriginal));
SQLInsertFields += "[CoverImageOriginal], ";
SQLValues += "@CoverImageOriginal_Param, ";
}
if (this.Platform != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Platform_Param", this.Platform));
SQLInsertFields += "[Platform], ";
SQLValues += "@Platform_Param, ";
}
if (this.ReleaseDate != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("ReleaseDate_Param", this.ReleaseDate));
SQLInsertFields += "[ReleaseDate], ";
SQLValues += "@ReleaseDate_Param, ";
}
if (this.Qty != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Qty_Param", this.Qty));
SQLInsertFields += "[Qty], ";
SQLValues += "@Qty_Param, ";
}
if (this.TextQty != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("TextQty_Param", this.TextQty));
SQLInsertFields += "[TextQty], ";
SQLValues += "@TextQty_Param, ";
}
if (this.Price != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Price_Param", this.Price));
SQLInsertFields += "[Price], ";
SQLValues += "@Price_Param, ";
}
if (this.IsPreorder != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("IsPreorder_Param", this.IsPreorder));
SQLInsertFields += "[IsPreorder], ";
SQLValues += "@IsPreorder_Param, ";
}
if (this.MetacriticScore != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("MetacriticScore_Param", this.MetacriticScore));
SQLInsertFields += "[MetacriticScore], ";
SQLValues += "@MetacriticScore_Param, ";
}
if (this.RegionalLimitations != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("RegionalLimitations_Param", this.RegionalLimitations));
SQLInsertFields += "[RegionalLimitations], ";
SQLValues += "@RegionalLimitations_Param, ";
}
if (this.RegionId != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("RegionId_Param", this.RegionId));
SQLInsertFields += "[RegionId], ";
SQLValues += "@RegionId_Param, ";
}
if (this.ActivationDetails != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("ActivationDetails_Param", this.ActivationDetails));
SQLInsertFields += "[ActivationDetails], ";
SQLValues += "@ActivationDetails_Param, ";
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
if (this.OriginalName != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("OriginalName_Param", this.OriginalName));
SQLInsertFields += "[OriginalName], ";
SQLValues += "@OriginalName_Param, ";
}
if (this.OffersCount != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("OffersCount_Param", this.OffersCount));
SQLInsertFields += "[OffersCount], ";
SQLValues += "@OffersCount_Param, ";
}
if (this.TotalQty != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("TotalQty_Param", this.TotalQty));
SQLInsertFields += "[TotalQty], ";
SQLValues += "@TotalQty_Param, ";
}
if (this.UpdatedAt != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("UpdatedAt_Param", this.UpdatedAt));
SQLInsertFields += "[UpdatedAt], ";
SQLValues += "@UpdatedAt_Param, ";
}
SQLInsertFields = SQLInsertFields.TrimEnd(", ".ToCharArray());
SQLValues = SQLValues.TrimEnd(", ".ToCharArray());
string _SQL = "Insert Into [KinguinProduct] ( " + SQLInsertFields + ") Values (" + SQLValues + ")";
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
if (this.JSONFileName != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("JSONFileName_Param", this.JSONFileName));
SQLInsertFields += "[JSONFileName] = @JSONFileName_Param, ";
}
if (this.Description != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Description_Param", this.Description));
SQLInsertFields += "[Description] = @Description_Param, ";
}
if (this.CoverImage != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("CoverImage_Param", this.CoverImage));
SQLInsertFields += "[CoverImage] = @CoverImage_Param, ";
}
if (this.CoverImageOriginal != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("CoverImageOriginal_Param", this.CoverImageOriginal));
SQLInsertFields += "[CoverImageOriginal] = @CoverImageOriginal_Param, ";
}
if (this.Platform != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Platform_Param", this.Platform));
SQLInsertFields += "[Platform] = @Platform_Param, ";
}
if (this.ReleaseDate != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("ReleaseDate_Param", this.ReleaseDate));
SQLInsertFields += "[ReleaseDate] = @ReleaseDate_Param, ";
}
if (this.Qty != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Qty_Param", this.Qty));
SQLInsertFields += "[Qty] = @Qty_Param, ";
}
if (this.TextQty != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("TextQty_Param", this.TextQty));
SQLInsertFields += "[TextQty] = @TextQty_Param, ";
}
if (this.Price != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("Price_Param", this.Price));
SQLInsertFields += "[Price] = @Price_Param, ";
}
if (this.IsPreorder != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("IsPreorder_Param", this.IsPreorder));
SQLInsertFields += "[IsPreorder] = @IsPreorder_Param, ";
}
if (this.MetacriticScore != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("MetacriticScore_Param", this.MetacriticScore));
SQLInsertFields += "[MetacriticScore] = @MetacriticScore_Param, ";
}
if (this.RegionalLimitations != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("RegionalLimitations_Param", this.RegionalLimitations));
SQLInsertFields += "[RegionalLimitations] = @RegionalLimitations_Param, ";
}
if (this.RegionId != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("RegionId_Param", this.RegionId));
SQLInsertFields += "[RegionId] = @RegionId_Param, ";
}
if (this.ActivationDetails != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("ActivationDetails_Param", this.ActivationDetails));
SQLInsertFields += "[ActivationDetails] = @ActivationDetails_Param, ";
}
if (this.KinguinId != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("KinguinId_Param", this.KinguinId));
SQLInsertFields += "[KinguinId] = @KinguinId_Param, ";
}
if (this.ProductId != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("ProductId_Param", this.ProductId));
SQLInsertFields += "[ProductId] = @ProductId_Param, ";
}
if (this.OriginalName != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("OriginalName_Param", this.OriginalName));
SQLInsertFields += "[OriginalName] = @OriginalName_Param, ";
}
if (this.OffersCount != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("OffersCount_Param", this.OffersCount));
SQLInsertFields += "[OffersCount] = @OffersCount_Param, ";
}
if (this.TotalQty != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("TotalQty_Param", this.TotalQty));
SQLInsertFields += "[TotalQty] = @TotalQty_Param, ";
}
if (this.UpdatedAt != null){ 
_Params.Add(new System.Data.SqlClient.SqlParameter("UpdatedAt_Param", this.UpdatedAt));
SQLInsertFields += "[UpdatedAt] = @UpdatedAt_Param, ";
}
SQLInsertFields = SQLInsertFields.TrimEnd(", ".ToCharArray());
SQLValues = SQLValues.TrimEnd("AND ".ToCharArray());
string _SQL = "Update [KinguinProduct] set " + SQLInsertFields + " Where " + SQLValues;
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
if (this.JSONFileName != null){ 
}
if (this.Description != null){ 
}
if (this.CoverImage != null){ 
}
if (this.CoverImageOriginal != null){ 
}
if (this.Platform != null){ 
}
if (this.ReleaseDate != null){ 
}
if (this.Qty != null){ 
}
if (this.TextQty != null){ 
}
if (this.Price != null){ 
}
if (this.IsPreorder != null){ 
}
if (this.MetacriticScore != null){ 
}
if (this.RegionalLimitations != null){ 
}
if (this.RegionId != null){ 
}
if (this.ActivationDetails != null){ 
}
if (this.KinguinId != null){ 
}
if (this.ProductId != null){ 
}
if (this.OriginalName != null){ 
}
if (this.OffersCount != null){ 
}
if (this.TotalQty != null){ 
}
if (this.UpdatedAt != null){ 
}
SQLValues = SQLValues.TrimEnd("AND ".ToCharArray());
string _SQL = "Delete From [KinguinProduct] Where " + SQLValues;
DataAccess.RunCommand(_SQL, _Params.ToList<System.Data.IDataParameter>(), false, System.Data.CommandType.Text);
}}

	}
}