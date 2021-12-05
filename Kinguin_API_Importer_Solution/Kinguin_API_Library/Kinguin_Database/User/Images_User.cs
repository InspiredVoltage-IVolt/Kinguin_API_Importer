using System.Collections.Generic;
using System.Linq;

namespace IVolt.Kinguin.API.LocalDB
{
    /// <summary>
    /// Defines the <see cref="Images" />.
    /// </summary>
    public class Images : Images_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Images"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Images(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Images"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Images(int? ID, string Conn = "") : base(ID, Conn)
        {
        }

        /// <summary>
        /// The Exists.
        /// </summary>
        /// <param name="URL">The GenName<see cref="string"/>.</param>
        /// <paramref name="TypeID">1=Full, 2=Thumb, 3=Cover, 4=Cover Thumb</paramref>
        /// <returns>The <see cref="long?"/>.</returns>
        public static long? Exists(string URL, int TypeID = -1)
        {
            if (URL == null) { return null; }

            Dictionary<string, string> _SearchData = new Dictionary<string, string>();

            int _TypeID = 0;

            if (TypeID == -1)
            {
                _TypeID = 1;
                if (URL.ToLower().Contains("thumb")) { _TypeID = 2; }
            }

            if (_TypeID == 0) { _TypeID = TypeID; }

            _SearchData.Add("url", URL);
            _SearchData.Add("Image_Type_ID", _TypeID.ToString());
            var img = Search(_SearchData).FirstOrDefault();
            return img?.ID;
        }
    }
}
