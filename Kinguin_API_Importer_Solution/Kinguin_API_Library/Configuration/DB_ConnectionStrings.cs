using ACT.Core.Extensions;

namespace IVolt.Kinguin.API.Configuration
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;

    /// <summary>
    /// Defines the <see cref="SimpleDbConnections" />.
    /// </summary>
    public class SimpleDbConnections
    {
        /// <summary>
        /// Defines the FileCorrect.
        /// </summary>
        private static string FileCorrect = AppDomain.CurrentDomain.BaseDirectory + "Data\\Storage_Settings.acte";

        /// <summary>
        /// Defines the FileInCorrect.
        /// </summary>
        private static string FileInCorrect = AppDomain.CurrentDomain.BaseDirectory + "Data\\Storage_Settings.json";

        /// <summary>
        /// Gets the GetKinguin_Intermediate_DatabaseConnection.
        /// </summary>
        [JsonIgnore()]
        public System.Data.SqlClient.SqlConnection GetKinguin_Intermediate_DatabaseConnection
        {
            get
            {
                try
                {
                    var Conn = this.DatabaseConnections.First(x => x.Name == "Kinguin_Intermediate").ConnectionString;
                    var _tmpReturn = new System.Data.SqlClient.SqlConnection(Conn);

                    if (_tmpReturn.State == System.Data.ConnectionState.Open) { return _tmpReturn; }
                    else
                    {
                        _tmpReturn.Dispose();
                        return null;
                    }
                }
                catch
                {
                    // TODO Log Error
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the GetKinguin_NopCommerce_DatabaseConnection.
        /// </summary>
        [JsonIgnore()]
        public System.Data.SqlClient.SqlConnection GetKinguin_NopCommerce_DatabaseConnection
        {
            get
            {
                try
                {
                    var Conn = this.DatabaseConnections.First(x => x.Name == "Kinguin_NopCommerce").ConnectionString;
                    var _tmpReturn = new System.Data.SqlClient.SqlConnection(Conn);

                    if (_tmpReturn.State == System.Data.ConnectionState.Open) { return _tmpReturn; }
                    else
                    {
                        _tmpReturn.Dispose();
                        return null;
                    }
                }
                catch
                {
                    // TODO Log Error
                    return null;
                }
            }
        }
        private static byte[] _Oragami = new byte[] { 44, 55, 66, 77, 88, 99, 1, 2, 3, 4, 5 };

        /// <summary>
        /// Use This Method.
        /// </summary>
        /// <returns>.</returns>
        public static SimpleDbConnections LoadConnectionsFromFile()
        {

            bool _FixFile = false;
            byte[] _Enc_Files;

            if (System.IO.File.Exists(FileCorrect) == true && System.IO.File.Exists(FileInCorrect) == false)
            {
                // PROPER
            }
            else if (System.IO.File.Exists(FileCorrect) == false && System.IO.File.Exists(FileInCorrect) == true)
            {
                _FixFile = true;
            }
            else if (System.IO.File.Exists(FileCorrect) == true && System.IO.File.Exists(FileInCorrect) == true)
            {
                // Assume JSON File Is Correct ALWAYS
                _FixFile = true;
            }

            if (_FixFile)
            {
                // JUST ENCRYPT FILE
                // Security.FileSecurity.ProtectFiles();
                //_Enc_Files = System.Security.Cryptography.ProtectedData.Protect(System.IO.File.ReadAllBytes(FileInCorrect), _Oragami, System.Security.Cryptography.DataProtectionScope.LocalMachine);
                //System.IO.File.WriteAllBytes(FileCorrect, _Enc_Files);
            }

            // MAKE SURE JSON FILE IS DELETED
            try
            {
                if (System.IO.File.Exists(FileInCorrect)) { System.IO.File.Delete(FileInCorrect); }
            }
            catch
            {
                throw new Exception("Critical Error Cleaning Up Files in Connection String");
            }
            _Enc_Files = null;

            string _file = AppDomain.CurrentDomain.BaseDirectory.FindFileReturnPath("Storage_Settings.acte");
            

           // _Enc_Files = Security.FileSecurity.GetFile(Enums.Protected_Files.API_Configuration);//.Unprotect(System.IO.File.ReadAllBytes(FileCorrect), _Oragami, System.Security.Cryptography.DataProtectionScope.LocalMachine);
            string _JSONData = System.Text.Encoding.Default.GetString(ProtectedData.Unprotect(System.IO.File.ReadAllBytes(_file), _Oragami, DataProtectionScope.CurrentUser));

            try { return FromJson(_JSONData); }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Save Connections.
        /// </summary>
        public void SaveConnections()
        {
            string _JSON = this.ToJson();
            var _FileContents = System.Text.Encoding.Default.GetBytes(_JSON);

            if (System.IO.File.Exists(FileCorrect))
            {
                System.IO.File.Copy(FileCorrect, FileCorrect.Replace(".acte", DateTime.Now.ToFileTime().ToString() + ".bak"));
            }
          //  Security.FileSecurity.ProtectFiles();

            //byte[] encB = System.Security.Cryptography.ProtectedData.Protect(_FileContents, _Oragami, System.Security.Cryptography.DataProtectionScope.LocalMachine);
            //System.IO.File.WriteAllBytes(FileCorrect, encB);

            //encB = null;
            _FileContents = null;
            _JSON = null;
            GC.Collect();
        }

        /// <summary>
        /// Gets or sets the DatabaseConnections.
        /// </summary>
        [JsonProperty("database_connections", NullValueHandling = NullValueHandling.Ignore)]
        public List<DatabaseConnection> DatabaseConnections { get; set; }

        /// <summary>
        /// The FromJson.
        /// </summary>
        /// <param name="json">The json<see cref="string"/>.</param>
        /// <returns>The <see cref="SimpleDbConnections"/>.</returns>
        internal static SimpleDbConnections FromJson(string json) => JsonConvert.DeserializeObject<SimpleDbConnections>(json, SimpleDB_Converter.Settings);

        /// <summary>
        /// The ToJson.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        internal string ToJson() => JsonConvert.SerializeObject(this, SimpleDB_Converter.Settings);
    }

    /// <summary>
    /// Defines the <see cref="DatabaseConnection" />.
    /// </summary>
    public class DatabaseConnection
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ConnectionString.
        /// </summary>
        [JsonProperty("connection_string", NullValueHandling = NullValueHandling.Ignore)]
        public string ConnectionString { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="SimpleDB_Converter" />.
    /// </summary>
    internal static class SimpleDB_Converter
    {
        /// <summary>
        /// Defines the Settings.
        /// </summary>
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
