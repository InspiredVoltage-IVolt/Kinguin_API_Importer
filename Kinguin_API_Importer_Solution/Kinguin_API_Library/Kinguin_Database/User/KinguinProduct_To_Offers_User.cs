namespace IVolt.Kinguin.API.LocalDB
{
    /// <summary>
    /// Defines the <see cref="KinguinProduct_To_Offers" />.
    /// </summary>
    public class KinguinProduct_To_Offers : KinguinProduct_To_Offers_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KinguinProduct_To_Offers"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public KinguinProduct_To_Offers(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KinguinProduct_To_Offers"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public KinguinProduct_To_Offers(int? ID, string Conn = "") : base(ID, Conn)
        {
        }
    }
}
