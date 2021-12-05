namespace IVolt.Kinguin.API.LocalDB
{
    /// <summary>
    /// Defines the <see cref="KinguinProduct_To_Screenshot" />.
    /// </summary>
    public class KinguinProduct_To_Screenshot : KinguinProduct_To_Screenshot_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KinguinProduct_To_Screenshot"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public KinguinProduct_To_Screenshot(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KinguinProduct_To_Screenshot"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public KinguinProduct_To_Screenshot(int? ID, string Conn = "") : base(ID, Conn)
        {
        }
    }
}
