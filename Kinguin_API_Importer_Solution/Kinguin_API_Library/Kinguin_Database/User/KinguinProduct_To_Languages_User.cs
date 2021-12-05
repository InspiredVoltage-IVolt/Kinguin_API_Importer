namespace IVolt.Kinguin.API.LocalDB
{
    /// <summary>
    /// Defines the <see cref="KinguinProduct_To_Languages" />.
    /// </summary>
    public class KinguinProduct_To_Languages : KinguinProduct_To_Languages_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KinguinProduct_To_Languages"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public KinguinProduct_To_Languages(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KinguinProduct_To_Languages"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public KinguinProduct_To_Languages(int? ID, string Conn = "") : base(ID, Conn)
        {
        }
    }
}
