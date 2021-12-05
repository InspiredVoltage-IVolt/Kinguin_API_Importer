namespace IVolt.Kinguin.API.Objects
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Kinguin_Product_System_Requirement" />.
    /// </summary>
    public class Kinguin_Product_System_Requirement
    {
        /// <summary>
        /// Gets or sets the System.
        /// </summary>
        [JsonProperty("system", NullValueHandling = NullValueHandling.Ignore)]
        public string System { get; set; }

        /// <summary>
        /// Gets or sets the Requirements.
        /// </summary>
        [JsonProperty("requirement", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Requirements { get; set; }
    }
}
