namespace IVolt.Kinguin.API.Objects
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Kinguin_Product_Screenshot" />.
    /// </summary>
    public class Kinguin_Product_Screenshot
    {
        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the UrlOriginal.
        /// </summary>
        [JsonProperty("url_original", NullValueHandling = NullValueHandling.Ignore)]
        public string UrlOriginal { get; set; }
    }
}
