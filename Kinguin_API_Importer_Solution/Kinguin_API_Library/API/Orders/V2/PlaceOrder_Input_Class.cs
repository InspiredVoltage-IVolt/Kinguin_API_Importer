namespace IVolt.Kinguin.API.API.Orders.V2
{
    using IVolt.Kinguin.API.Configuration;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="PlaceOrder_Input_Class" />.
    /// </summary>
    public class PlaceOrder_Input_Class
    {
        /// <summary>
        /// Gets or sets the Products.
        /// </summary>
        [JsonProperty("products", NullValueHandling = NullValueHandling.Ignore)]
        public List<PlaceOrder_Input_Product> Products { get; set; }

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
        /// <returns>The <see cref="PlaceOrder_Input_Class"/>.</returns>
        public static PlaceOrder_Input_Class FromJson(string json) => JsonConvert.DeserializeObject<PlaceOrder_Input_Class>(json, SimpleDB_Converter.Settings);

        /// <summary>
        /// The ToJson.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string ToJson() => JsonConvert.SerializeObject(this, SimpleDB_Converter.Settings);
    }
}
