namespace IVolt.Kinguin.API.Configuration
{
    using ACT.Core.Extensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Globalization;
    using System.Security.Cryptography;

    /// <summary>
    /// Defines the <see cref="Kinguin_API_ConfigurationSettings" />.
    /// </summary>
    public static class Kinguin_API_ConfigurationSettings
    {
        /// <summary>
        /// Defines the appSettingsFilePath.
        /// </summary>
        private static string appSettingsFilePath = AppDomain.CurrentDomain.BaseDirectory + "Data\\appSettings.ini";

        /// <summary>
        /// Defines the appSettingsContents.
        /// </summary>
        private static string appSettingsContents = "";

        /// <summary>
        /// Defines the ConfigurationData.
        /// </summary>
        internal static KinguinApiConfiguration ConfigurationData = null;
        private static byte[] _Oragami = new byte[] { 44, 55, 66, 77, 88, 99, 1, 2, 3, 4, 5 };

        /// <summary>
        /// Initializes static members of the <see cref="Kinguin_API_ConfigurationSettings"/> class.
        /// </summary>
        static Kinguin_API_ConfigurationSettings()
        {
            if (System.IO.File.Exists(appSettingsFilePath) == true)
            {
                appSettingsContents = System.IO.File.ReadAllText(appSettingsFilePath);
                Globals.DataDirectory = appSettingsContents.Replace("datafilelocation:", "").Replace("###BASEDIRECTORY###", Globals.BaseDirectory);
            }
            string _file = AppDomain.CurrentDomain.BaseDirectory.FindFileReturnPath("API_Configuration.acte");


            // _Enc_Files = Security.FileSecurity.GetFile(Enums.Protected_Files.API_Configuration);//.Unprotect(System.IO.File.ReadAllBytes(FileCorrect), _Oragami, System.Security.Cryptography.DataProtectionScope.LocalMachine);
            string _JSONData = System.Text.Encoding.Default.GetString(ProtectedData.Unprotect(System.IO.File.ReadAllBytes(_file), _Oragami, DataProtectionScope.CurrentUser));

          //  string _ConfigurationData = Security.FileSecurity.UnProtect_ToMemory(Enums.Protected_Files.API_Configuration)[Enums.Protected_Files.API_Configuration];
            ConfigurationData = KinguinApiConfiguration.FromJson(_JSONData);
        }

        /// <summary>
        /// Gets the APIKey.
        /// </summary>
        public static string APIKey
        {
            get { return ConfigurationData.Apikey; }
        }
    }

    /// <summary>
    /// Defines the <see cref="KinguinApiConfiguration" />.
    /// </summary>
    public class KinguinApiConfiguration
    {
        /// <summary>
        /// Gets or sets the Apikey.
        /// </summary>
        [JsonProperty("apikey", NullValueHandling = NullValueHandling.Ignore)]
        public string Apikey { get; set; }

        /// <summary>
        /// Gets or sets the ProductsV1Baseurl.
        /// </summary>
        [JsonProperty("products_v1_baseurl", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductsV1Baseurl { get; set; }

        /// <summary>
        /// Gets or sets the ProductsV2Baseurl.
        /// </summary>
        [JsonProperty("products_v2_baseurl", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductsV2Baseurl { get; set; }

        /// <summary>
        /// Gets or sets the OrdersV1Baseurl.
        /// </summary>
        [JsonProperty("orders_v1_baseurl", NullValueHandling = NullValueHandling.Ignore)]
        public string OrdersV1Baseurl { get; set; }

        /// <summary>
        /// Gets or sets the OrdersV2Baseurl.
        /// </summary>
        [JsonProperty("orders_v2_baseurl", NullValueHandling = NullValueHandling.Ignore)]
        public string OrdersV2Baseurl { get; set; }

        /// <summary>
        /// The FromJson.
        /// </summary>
        /// <param name="json">The json<see cref="string"/>.</param>
        /// <returns>The <see cref="KinguinApiConfiguration"/>.</returns>
        public static KinguinApiConfiguration FromJson(string json) => JsonConvert.DeserializeObject<KinguinApiConfiguration>(json, KinguinApiConfiguration_Converter.Settings);

        /// <summary>
        /// The ToJson.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string ToJson() => JsonConvert.SerializeObject(this, KinguinApiConfiguration_Converter.Settings);
    }

    /// <summary>
    /// Defines the <see cref="KinguinApiConfiguration_Converter" />.
    /// </summary>
    internal static class KinguinApiConfiguration_Converter
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
