namespace IVolt.Kinguin.API.Objects
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Kinguin_Product_Video" />.
    /// </summary>
    public class Kinguin_Product_Video
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [JsonProperty("video_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }
    }
}
