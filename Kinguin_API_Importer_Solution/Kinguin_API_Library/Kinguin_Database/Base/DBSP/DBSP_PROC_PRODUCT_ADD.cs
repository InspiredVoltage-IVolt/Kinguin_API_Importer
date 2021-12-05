
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
/// Execute PROC_PRODUCT_ADD
/// </summary>
/// <returns>I_QueryResult</returns>


namespace IVolt.Kinguin.API.LocalDB.PROC.PRODUCT.ADD
{
public static class Execute {
public static I_QueryResult Proc(string @Name_VALUE, string @JSONFileName_VALUE, string @Description_VALUE, string @CoverImage_VALUE, string @CoverImageOriginal_VALUE, string @Platform_VALUE, DateTime? @ReleaseDate_VALUE, int? @Qty_VALUE, int? @TextQty_VALUE, decimal? @Price_VALUE, bool? @IsPreorder_VALUE, int? @MetacriticScore_VALUE, string @RegionalLimitations_VALUE, int? @RegionId_VALUE, string @ActivationDetails_VALUE, int? @KinguinId_VALUE, string @ProductId_VALUE, string @OriginalName_VALUE, int? @OffersCount_VALUE, int? @TotalQty_VALUE, DateTime? @UpdatedAt_VALUE, string Conn = "")
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
	if (@Name_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@Name", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@Name", @Name_VALUE));
	}
	if (@JSONFileName_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@JSONFileName", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@JSONFileName", @JSONFileName_VALUE));
	}
	if (@Description_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@Description", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@Description", @Description_VALUE));
	}
	if (@CoverImage_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@CoverImage", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@CoverImage", @CoverImage_VALUE));
	}
	if (@CoverImageOriginal_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@CoverImageOriginal", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@CoverImageOriginal", @CoverImageOriginal_VALUE));
	}
	if (@Platform_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@Platform", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@Platform", @Platform_VALUE));
	}
	if (@ReleaseDate_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@ReleaseDate", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@ReleaseDate", @ReleaseDate_VALUE));
	}
	if (@Qty_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@Qty", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@Qty", @Qty_VALUE));
	}
	if (@TextQty_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@TextQty", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@TextQty", @TextQty_VALUE));
	}
	if (@Price_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@Price", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@Price", @Price_VALUE));
	}
	if (@IsPreorder_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@IsPreorder", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@IsPreorder", @IsPreorder_VALUE));
	}
	if (@MetacriticScore_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@MetacriticScore", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@MetacriticScore", @MetacriticScore_VALUE));
	}
	if (@RegionalLimitations_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@RegionalLimitations", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@RegionalLimitations", @RegionalLimitations_VALUE));
	}
	if (@RegionId_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@RegionId", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@RegionId", @RegionId_VALUE));
	}
	if (@ActivationDetails_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@ActivationDetails", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@ActivationDetails", @ActivationDetails_VALUE));
	}
	if (@KinguinId_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@KinguinId", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@KinguinId", @KinguinId_VALUE));
	}
	if (@ProductId_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@ProductId", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@ProductId", @ProductId_VALUE));
	}
	if (@OriginalName_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@OriginalName", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@OriginalName", @OriginalName_VALUE));
	}
	if (@OffersCount_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@OffersCount", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@OffersCount", @OffersCount_VALUE));
	}
	if (@TotalQty_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@TotalQty", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@TotalQty", @TotalQty_VALUE));
	}
	if (@UpdatedAt_VALUE == null) 
	 { 
	_Params.Add(new System.Data.SqlClient.SqlParameter("@UpdatedAt", DBNull.Value));
	}
	else 
	{
	_Params.Add(new System.Data.SqlClient.SqlParameter("@UpdatedAt", @UpdatedAt_VALUE));
	}
	#endregion
	var _Result = DataAccess.RunCommand("[dbo].PROC_PRODUCT_ADD", _Params, true, System.Data.CommandType.StoredProcedure);
	return _Result;
}}}

}
