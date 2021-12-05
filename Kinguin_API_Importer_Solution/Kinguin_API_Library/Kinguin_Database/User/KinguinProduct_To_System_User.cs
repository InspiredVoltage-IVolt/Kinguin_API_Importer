namespace IVolt.Kinguin.API.LocalDB
{
    /// <summary>
    /// Defines the <see cref="KinguinProduct_To_System" />.
    /// </summary>
    public class KinguinProduct_To_System : KinguinProduct_To_System_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KinguinProduct_To_System"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public KinguinProduct_To_System(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KinguinProduct_To_System"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public KinguinProduct_To_System(int? ID, string Conn = "") : base(ID, Conn)
        {
        }
    }
}
