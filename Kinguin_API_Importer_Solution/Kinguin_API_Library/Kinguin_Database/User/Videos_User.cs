using System.Linq;

using System.Collections.Generic;
using IVolt.Kinguin.API.Objects;

namespace IVolt.Kinguin.API.LocalDB
{
    /// <summary>
    /// Defines the <see cref="Videos" />.
    /// </summary>
    public class Videos : Videos_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Videos"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Videos(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Videos"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Videos(int? ID, string Conn = "") : base(ID, Conn)
        {
        }

        /// <summary>
        /// The Exists.
        /// </summary>
        /// <param name="ScreenShotToCheck">The ScreenShot tO tEST fOR<see cref="string"/>.</param>
        /// <returns>The <see cref="long?"/>.</returns>
        public static long? Exists(Kinguin_Product_Video VideoToCheck)
        {

	        Dictionary<string, string> _SearchData = new Dictionary<string, string>();
	        _SearchData.Add("name", VideoToCheck.Name);
	        _SearchData.Add("Video_ID", VideoToCheck.ID);

	        var _SearchResults = Videos.Search(_SearchData);

	        if (_SearchResults.Count > 0) { return _SearchResults.First().ID; }

	        return null;
        }
    }
}
