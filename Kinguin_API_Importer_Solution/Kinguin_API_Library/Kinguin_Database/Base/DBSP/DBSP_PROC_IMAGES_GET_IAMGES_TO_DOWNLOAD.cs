using ACT.Core;
using ACT.Core.Interfaces.DataAccess;
/// <summary>
/// Execute PROC_IMAGES_GET_IAMGES_TO_DOWNLOAD
/// </summary>
/// <returns>I_QueryResult</returns>


namespace IVolt.Kinguin.API.LocalDB.PROC.IMAGES.GET.IMAGES.TO.DOWNLOAD
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
                var _Result = DataAccess.RunCommand("[dbo].PROC_IMAGES_GET_IMAGES_TO_DOWNLOAD", _Params, true, System.Data.CommandType.StoredProcedure);
                return _Result;
            }
        }
    }

}
