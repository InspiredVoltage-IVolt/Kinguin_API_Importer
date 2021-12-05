using System;
using System.Collections.Generic;
using System.Text;
using ACT.Core.Enums;
using ACT.Core.Interfaces.DataAccess;
using ACT.Core.Extensions;

namespace IVolt.Kinguin.API.LocalDB
{
    public static class GenericStaticClass
    {
        public static string DatabaseConnectionName = "Kinguin_connectionstring";
        public static string DatabaseConnectionString { get { return ACT.Core.SystemSettings.GetSettingByName(DatabaseConnectionName).Value; } }
		public static I_DataAccess GetDataAccess(bool OpenDB)
        {
            var _TmpReturn = ACT.Core.CurrentCore<I_DataAccess>.GetCurrent();

			if (_TmpReturn == null) 
			{
				ACT.Core.Helper.ErrorLogger.LogError("unable to create instance of I_DataAccess", "Check Plugin Configuration", null, ErrorLevel.Critical);
				return null;
			}

            if (OpenDB)
            {
                if (_TmpReturn.Open(DatabaseConnectionString) == false) { return null; }
            }

            return _TmpReturn;
        }
    }
}
