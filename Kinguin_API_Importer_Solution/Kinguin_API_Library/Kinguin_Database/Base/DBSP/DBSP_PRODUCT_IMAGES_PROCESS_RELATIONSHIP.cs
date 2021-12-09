using ACT.Core;
using ACT.Core.Interfaces.DataAccess;
/// <summary>
/// Execute PRODUCT_GET_ALL_METADATA
/// </summary>
/// <returns>I_QueryResult</returns>


namespace IVolt.Kinguin.API.LocalDB.PRODUCT.IMAGES.PROCESS.RELATIONSHIP
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
                List<System.Data.IDataParameter> _Params = new List<System.Data.IDataParameter>();
                #region Param Values
                #endregion
                var _Result = DataAccess.RunCommand("[dbo].PROC_PRODUCT_IMAGES_PROCESS_RELATIONSHIP", _Params, true, System.Data.CommandType.StoredProcedure);
                return _Result;
            }
        }
    }

}
