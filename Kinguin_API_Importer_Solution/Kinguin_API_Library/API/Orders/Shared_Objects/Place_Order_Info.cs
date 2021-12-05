namespace IVolt.Kinguin.API.Configuration
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Place_Order_Info" />.
    /// </summary>
    public class Place_Order_Info
    {
        /// <summary>
        /// Gets or sets the Products.
        /// </summary>
        [JsonProperty("products", NullValueHandling = NullValueHandling.Ignore)]
        public List<OrderInfo_Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the OrderExternalId.
        /// </summary>
        [JsonProperty("orderExternalId", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderExternalId { get; set; }

        /// <summary>
        /// Gets or sets the CouponCode.
        /// </summary>
        [JsonProperty("couponCode", NullValueHandling = NullValueHandling.Ignore)]
        public string CouponCode { get; set; }

        /// <summary>
        /// The FromJson.
        /// </summary>
        /// <param name="json">The json<see cref="string"/>.</param>
        /// <returns>The <see cref="Place_Order_Info"/>.</returns>
        public static Place_Order_Info FromJson(string json) => JsonConvert.DeserializeObject<Place_Order_Info>(json, SimpleDB_Converter.Settings);

        /// <summary>
        /// The ToJson.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string ToJson() => JsonConvert.SerializeObject(this, SimpleDB_Converter.Settings);
    }

    /// <summary>
    /// Defines the <see cref="OrderInfo_Product" />.
    /// </summary>
    public class OrderInfo_Product
    {
        /// <summary>
        /// Gets or sets the KinguinId.
        /// </summary>
        [JsonProperty("kinguinId", NullValueHandling = NullValueHandling.Ignore)]
        public long? KinguinId { get; set; }

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
