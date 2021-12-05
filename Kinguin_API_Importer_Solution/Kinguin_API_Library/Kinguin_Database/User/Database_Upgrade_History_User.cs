namespace IVolt.Kinguin.API.LocalDB
{
    /// <summary>
    /// Defines the <see cref="Database_Upgrade_History" />.
    /// </summary>
    public class Database_Upgrade_History : Database_Upgrade_History_CoreClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Database_Upgrade_History"/> class.
        /// </summary>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Database_Upgrade_History(string Conn = "")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Database_Upgrade_History"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="Conn">The Conn<see cref="string"/>.</param>
        public Database_Upgrade_History(int? ID, string Conn = "") : base(ID, Conn)
        {
        }
    }
}
