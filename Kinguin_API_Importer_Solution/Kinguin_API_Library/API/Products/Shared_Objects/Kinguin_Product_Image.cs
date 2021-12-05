namespace IVolt.Kinguin.API.Objects
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Kinguin_Product_Image" />.
    /// </summary>
    public class Kinguin_Product_Image
    {
        /// <summary>
        /// Gets or sets the Screenshots.
        /// </summary>
        [JsonProperty("screenshots", NullValueHandling = NullValueHandling.Ignore)]
        public List<Kinguin_Product_CoverImage> Screenshots { get; set; }

        /// <summary>
        /// Gets or sets the Cover.
        /// </summary>
        [JsonProperty("cover", NullValueHandling = NullValueHandling.Ignore)]
        public Kinguin_Product_CoverImage Cover { get; set; }
    }
}
