using System.Linq;
namespace IVolt.Kinguin.API.LocalDB
{
    /// <summary>
    /// Defines the <see cref="Image_Type" />.
    /// </summary>
    public class Image_Type : Image_Type_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Image_Type"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Image_Type(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Image_Type"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Image_Type(int? ID, string Conn = "") : base(ID, Conn)
        {
        }

        /// <summary>
        /// The Exists.
        /// </summary>
        /// <param name="GenName">The GenName<see cref="string"/>.</param>
        /// <returns>The <see cref="long?"/>.</returns>
        public static long? Exists(string GenName)
        {
	        var _SearchResults = Image_Type.Search("Name", GenName, false);

	        if (_SearchResults.Count > 0) { return _SearchResults.First().ID; }

	        return null;
        }
    }
}
