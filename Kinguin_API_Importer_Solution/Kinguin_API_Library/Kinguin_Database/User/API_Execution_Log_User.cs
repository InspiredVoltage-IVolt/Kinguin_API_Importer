
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
	public class API_Execution_Log : API_Execution_Log_CoreClass
	{

		public API_Execution_Log(string Conn = ""){ }

public API_Execution_Log(Guid? ID, string Conn = "") : base (ID, Conn)
 { } 

}
}