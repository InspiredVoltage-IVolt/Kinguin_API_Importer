namespace IVolt.Kinguin.API.LocalDB
{
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="MerchantName" />.
    /// </summary>
    public class MerchantName : MerchantName_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantName"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public MerchantName(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MerchantName"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public MerchantName(int? ID, string Conn = "") : base(ID, Conn)
        {
        }

        /// <summary>
        /// The Exists.
        /// </summary>
        /// <param name="MerchantName">The MerchantName<see cref="string"/>.</param>
        /// <returns>The <see cref="long?"/>.</returns>
        public static long? Exists(string MerchantName)
        {
            var _SearchResults = Genres.Search("Name", MerchantName, false);

            if (_SearchResults.Count > 0) { return _SearchResults.First().ID; }

            return null;
        }
    }
}
