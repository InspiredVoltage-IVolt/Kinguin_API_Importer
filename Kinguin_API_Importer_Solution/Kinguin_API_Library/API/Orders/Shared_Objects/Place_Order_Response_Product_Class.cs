namespace IVolt.Kinguin.API.Configuration
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Defines the <see cref="Place_Order_Response_Product" />.
    /// </summary>
    public class Place_Order_Response_Product
    {
        /// <summary>
        /// Gets or sets the KinguinId.
        /// </summary>
        [JsonProperty("kinguinId", NullValueHandling = NullValueHandling.Ignore)]
        public long? KinguinId { get; set; }

        /// <summary>
        /// Gets or sets the OfferId.
        /// </summary>
        [JsonProperty("offerId", NullValueHandling = NullValueHandling.Ignore)]
        public string OfferId { get; set; }

        /// <summary>
        /// Gets or sets the ProductId.
        /// </summary>
        [JsonProperty("productId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the Qty.
        /// </summary>
        [JsonProperty("qty", NullValueHandling = NullValueHandling.Ignore)]
        public long? Qty { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        /// <summary>
        /// Gets or sets the TotalPrice.
        /// </summary>
        [JsonProperty("totalPrice", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the RequestPrice.
        /// </summary>
        [JsonProperty("requestPrice", NullValueHandling = NullValueHandling.Ignore)]
        public double? RequestPrice { get; set; }

        /// <summary>
        /// Gets or sets the IsPreorder.
        /// </summary>
        [JsonProperty("isPreorder", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPreorder { get; set; }

        /// <summary>
        /// Gets or sets the ReleaseDate.
        /// </summary>
        [JsonProperty("releaseDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the KeyType.
        /// </summary>
        [JsonProperty("keyType", NullValueHandling = NullValueHandling.Ignore)]
        public string KeyType { get; set; }

        /// <summary>
        /// Gets or sets the Accurate.
        /// </summary>
        [JsonProperty("accurate", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Accurate { get; set; }

        /// <summary>
        /// Gets or sets the Broker.
        /// </summary>
        [JsonProperty("broker", NullValueHandling = NullValueHandling.Ignore)]
        public string Broker { get; set; }
    }
}
