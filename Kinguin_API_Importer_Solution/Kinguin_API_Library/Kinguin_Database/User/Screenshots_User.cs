using System.Linq;

using System.Collections.Generic;
using IVolt.Kinguin.API.Objects;

namespace IVolt.Kinguin.API.LocalDB
{
    /// <summary>
    /// Defines the <see cref="Screenshots" />.
    /// </summary>
    public class Screenshots : Screenshots_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Screenshots"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Screenshots(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Screenshots"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Screenshots(int? ID, string Conn = "") : base(ID, Conn)
        {
        }

        /// <summary>
        /// The Exists.
        /// </summary>
        /// <param name="ScreenShotToCheck">The ScreenShot tO tEST fOR<see cref="string"/>.</param>
        /// <returns>The <see cref="long?"/>.</returns>
        public static long? Exists(Kinguin_Product_Screenshot ScreenShotToCheck)
        {

            Dictionary<string, string> _SearchData = new Dictionary<string, string>();
            _SearchData.Add("URL", ScreenShotToCheck.Url);
            _SearchData.Add("URL_Original", ScreenShotToCheck.UrlOriginal);

            var _SearchResults = Screenshots.Search(_SearchData);

            if (_SearchResults.Count > 0) { return _SearchResults.First().ID; }

            return null;
        }
    }
}
