namespace IVolt.Kinguin.API.Objects
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="Kinguin_Product_Offer" />.
    /// </summary>
    public class Kinguin_Product_Offer
    {
        /// <summary>
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [JsonProperty("offerId", NullValueHandling = NullValueHandling.Ignore)]
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        /// <summary>
        /// Gets or sets the Qty.
        /// </summary>
        [JsonProperty("qty", NullValueHandling = NullValueHandling.Ignore)]
        public long? Qty { get; set; }

        /// <summary>
        /// Gets or sets the TextQty.
        /// </summary>
        [JsonProperty("textQty", NullValueHandling = NullValueHandling.Ignore)]
        public long? TextQty { get; set; }

        /// <summary>
        /// Gets or sets the MerchantName.
        /// </summary>
        [JsonProperty("merchantName", NullValueHandling = NullValueHandling.Ignore)]
        public string MerchantName { get; set; }

        /// <summary>
        /// Gets or sets the IsPreorder.
        /// </summary>
        [JsonProperty("isPreorder", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPreorder { get; set; }

        /// <summary>
        /// Gets or sets the ReleaseDate.
        /// </summary>
        [JsonProperty("releaseDate", NullValueHandling = NullValueHandling.Ignore)]
        public string ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the KinguinProductID.
        /// </summary>
        [JsonIgnore()]
        public string KProductID { get; set; }

        /// <summary>
        /// Gets or sets the KinguinProductID.
        /// </summary>     
        [JsonIgnore()]
        public string? FileName { get; set; }
    }
}
