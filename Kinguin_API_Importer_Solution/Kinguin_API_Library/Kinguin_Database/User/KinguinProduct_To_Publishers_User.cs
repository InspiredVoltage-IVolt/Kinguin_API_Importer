namespace IVolt.Kinguin.API.LocalDB
{
    /// <summary>
    /// Defines the <see cref="KinguinProduct_To_Publishers" />.
    /// </summary>
    public class KinguinProduct_To_Publishers : KinguinProduct_To_Publishers_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KinguinProduct_To_Publishers"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public KinguinProduct_To_Publishers(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KinguinProduct_To_Publishers"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public KinguinProduct_To_Publishers(int? ID, string Conn = "") : base(ID, Conn)
        {
        }
    }
}
