namespace IVolt.Kinguin.API.Objects
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Kinguin_Product_CoverImage" />.
    /// </summary>
    public class Kinguin_Product_CoverImage
    {
        /// <summary>
        /// Gets or sets the Url.
        /// </summary>
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the Thumbnail.
        /// </summary>
        [JsonProperty("thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }
    }
}
