
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
	public class WEBHOOK_Product_Update : WEBHOOK_Product_Update_CoreClass
	{

		public WEBHOOK_Product_Update(string Conn = ""){ }

public WEBHOOK_Product_Update(Guid? ID, string Conn = "") : base (ID, Conn)
 { } 

}
}