namespace IVolt.Kinguin.API.API.Orders.V2
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="PlaceOrder_Input_Product" />.
    /// </summary>
    public class PlaceOrder_Input_Product
    {
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
        /// Gets or sets the Price.
        /// </summary>
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the KeyType.
        /// </summary>
        [JsonProperty("keyType", NullValueHandling = NullValueHandling.Ignore)]
        public string KeyType { get; set; }

        /// <summary>
        /// Gets or sets the OfferId.
        /// </summary>
        [JsonProperty("offerId", NullValueHandling = NullValueHandling.Ignore)]
        public string OfferId { get; set; }
    }
}
