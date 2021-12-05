namespace IVolt.Kinguin.API.LocalDB
{
    /// <summary>
    /// Defines the <see cref="Global_ImportErrors" />.
    /// </summary>
    public class Global_ImportErrors : Global_ImportErrors_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Global_ImportErrors"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Global_ImportErrors(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Global_ImportErrors"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Global_ImportErrors(int? ID, string Conn = "") : base(ID, Conn)
        {
        }
    }
}
