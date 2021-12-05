namespace IVolt.Kinguin.API.LocalDB
{
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="Publishers" />.
    /// </summary>
    public class Publishers : Publishers_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Publishers"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Publishers(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Publishers"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Publishers(int? ID, string Conn = "") : base(ID, Conn)
        {
        }

        /// <summary>
        /// The Exists.
        /// </summary>
        /// <param name="PublisherName">The PublisherName<see cref="string"/>.</param>
        /// <returns>The <see cref="long?"/>.</returns>
        public static long? Exists(string PublisherName)
        {
            var _SearchResults = Publishers.Search("Name", PublisherName, false);

            if (_SearchResults.Count > 0) { return _SearchResults.First().ID; }

            return null;
        }
    }
}
