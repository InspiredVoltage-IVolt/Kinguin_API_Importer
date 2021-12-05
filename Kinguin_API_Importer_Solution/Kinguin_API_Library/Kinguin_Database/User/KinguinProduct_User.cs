namespace IVolt.Kinguin.API.LocalDB
{
    using ACT.Core.Extensions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using JSON_OBJ = IVolt.Kinguin.API.Objects;

    /// <summary>
    /// Defines the <see cref="KinguinProduct" />.
    /// </summary>
    public class KinguinProduct : KinguinProduct_CoreClass
    {
     

        /// <summary>
        /// Initializes a new instance of the <see cref="KinguinProduct"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public KinguinProduct(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KinguinProduct"/> class.
        /// </summary>
        /// <param name="Id">The Id<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public KinguinProduct(int? Id, string Conn = "") : base(Id, Conn)
        {
        }
       
    }
}
