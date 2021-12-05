namespace IVolt.Kinguin.API.Configuration
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Order_Search_Response" />.
    /// </summary>
    public class Order_Search_Response
    {
        /// <summary>
        /// Gets or sets the Results.
        /// </summary>
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public List<Result> Results { get; set; }

        /// <summary>
        /// Gets or sets the ItemCount.
        /// </summary>
        [JsonProperty("item_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? ItemCount { get; set; }

        /// <summary>
        /// The FromJson.
        /// </summary>
        /// <param name="json">The json<see cref="string"/>.</param>
        /// <returns>The <see cref="Order_Search_Response"/>.</returns>
        public static Order_Search_Response FromJson(string json) => JsonConvert.DeserializeObject<Order_Search_Response>(json, SimpleDB_Converter.Settings);

        /// <summary>
        /// The ToJson.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string ToJson() => JsonConvert.SerializeObject(this, SimpleDB_Converter.Settings);
    }

    /// <summary>
    /// Defines the <see cref="Result" />.
    /// </summary>
    public partial class Result
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
        public List<Product> Products { get; set; }

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
    }

    /// <summary>
    /// Defines the <see cref="Product" />.
    /// </summary>
    public partial class Product
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
