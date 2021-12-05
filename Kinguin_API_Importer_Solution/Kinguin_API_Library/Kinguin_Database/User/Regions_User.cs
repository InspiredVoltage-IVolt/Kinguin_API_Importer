namespace IVolt.Kinguin.API.LocalDB
{
    /// <summary>
    /// Defines the <see cref="Regions" />.
    /// </summary>
    public class Regions : Regions_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Regions"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Regions(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Regions"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Regions(int? ID, string Conn = "") : base(ID, Conn)
        {
        }
    }
}
