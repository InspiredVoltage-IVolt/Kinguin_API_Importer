namespace IVolt.Kinguin.API.Configuration
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Order_Keys" />.
    /// </summary>
    public class Order_Keys
    {
        /// <summary>
        /// Gets or sets the Serial.
        /// </summary>
        [JsonProperty("serial", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Serial { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

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
        /// The FromJson.
        /// </summary>
        /// <param name="json">The json<see cref="string"/>.</param>
        /// <returns>The <see cref="List{Order_Keys}"/>.</returns>
        public static List<Order_Keys> FromJson(string json) => JsonConvert.DeserializeObject<List<Order_Keys>>(json, SimpleDB_Converter.Settings);

        /// <summary>
        /// The ToJson.
        /// </summary>
        /// <param name="self">The self<see cref="List{Order_Keys}"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string ToJson(List<Order_Keys> self) => JsonConvert.SerializeObject(self, SimpleDB_Converter.Settings);
    }
}
