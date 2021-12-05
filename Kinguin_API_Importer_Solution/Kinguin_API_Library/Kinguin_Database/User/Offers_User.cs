namespace IVolt.Kinguin.API.LocalDB
{
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="Offers" />.
    /// </summary>
    public class Offers : Offers_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Offers"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Offers(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Offers"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Offers(int? ID, string Conn = "") : base(ID, Conn)
        {
        }

        /// <summary>
        /// The Exists.
        /// </summary>
        /// <param name="OfferID">The OfferID<see cref="string"/>.</param>
        /// <returns>The <see cref="long?"/>.</returns>
        public static long? Exists(string OfferID)
        {
            var _SearchResults = Offers.Search("OfferID", OfferID, false);

            if (_SearchResults.Count > 0) { return _SearchResults.First().ID; }

            return null;
        }
    }
}
