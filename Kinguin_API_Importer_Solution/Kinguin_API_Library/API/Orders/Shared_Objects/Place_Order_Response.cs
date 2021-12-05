namespace IVolt.Kinguin.API.Configuration
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Place_Order_Response" />.
    /// </summary>
    public class Place_Order_Response
    {
        /// <summary>
        /// Gets or sets the TotalPrice.
        /// </summary>
        [JsonProperty("totalPrice", NullValueHandling = NullValueHandling.Ignore)]
        public double? TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the RequestTotalPrice.
        /// </summary>
        [JsonProperty("requestTotalPrice", NullValueHandling = NullValueHandling.Ignore)]
        public double? RequestTotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the UserEmail.
        /// </summary>
        [JsonProperty("userEmail", NullValueHandling = NullValueHandling.Ignore)]
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the StoreId.
        /// </summary>
        [JsonProperty("storeId", NullValueHandling = NullValueHandling.Ignore)]
        public long? StoreId { get; set; }

        /// <summary>
        /// Gets or sets the CreatedAt.
        /// </summary>
        [JsonProperty("createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the OrderId.
        /// </summary>
        [JsonProperty("orderId", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; set; }

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
        /// Gets or sets the PaymentPrice.
        /// </summary>
        [JsonProperty("paymentPrice", NullValueHandling = NullValueHandling.Ignore)]
        public double? PaymentPrice { get; set; }

        /// <summary>
        /// Gets or sets the Products.
        /// </summary>
        [JsonProperty("products", NullValueHandling = NullValueHandling.Ignore)]
        public List<Place_Order_Response_Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the TotalQty.
        /// </summary>
        [JsonProperty("totalQty", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalQty { get; set; }

        /// <summary>
        /// Gets or sets the IsPreorder.
        /// </summary>
        [JsonProperty("isPreorder", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPreorder { get; set; }

        /// <summary>
        /// Gets or sets the PreorderReleaseDate.
        /// </summary>
        [JsonProperty("preorderReleaseDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? PreorderReleaseDate { get; set; }

        /// <summary>
        /// The FromJson.
        /// </summary>
        /// <param name="json">The json<see cref="string"/>.</param>
        /// <returns>The <see cref="Place_Order_Response"/>.</returns>
        public static Place_Order_Response FromJson(string json) => JsonConvert.DeserializeObject<Place_Order_Response>(json, SimpleDB_Converter.Settings);

        /// <summary>
        /// The ToJson.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string ToJson() => JsonConvert.SerializeObject(this, SimpleDB_Converter.Settings);
    }
}
