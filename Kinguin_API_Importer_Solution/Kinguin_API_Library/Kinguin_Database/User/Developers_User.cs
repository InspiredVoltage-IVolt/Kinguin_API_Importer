namespace IVolt.Kinguin.API.LocalDB
{
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="Developers" />.
    /// </summary>
    public class Developers : Developers_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Developers"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Developers(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Developers"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Developers(int? ID, string Conn = "") : base(ID, Conn)
        {
        }

        /// <summary>
        /// The Exists.
        /// </summary>
        /// <param name="DeveloperName">The DeveloperName<see cref="string"/>.</param>
        /// <returns>The <see cref="int?"/>.</returns>
        public static int? Exists(string DeveloperName)
        {
            var _SearchResults = Developers.Search("Name", DeveloperName, false);

            if (_SearchResults.Count > 0) { return _SearchResults.First().ID; }

            return null;
        }
    }
}
