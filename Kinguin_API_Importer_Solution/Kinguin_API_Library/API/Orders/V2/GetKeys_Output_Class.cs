namespace IVolt.Kinguin.API.API.Orders.V2
{
    using IVolt.Kinguin.API.Configuration;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="GetKeys_Output_Class" />.
    /// </summary>
    public class GetKeys_Output_Class
    {
        /// <summary>
        /// Gets or sets the Serial1.
        /// </summary>
        [JsonProperty("serial1", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Serial1 { get; set; }

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
        /// <returns>The <see cref="List{GetKeys_Output_Class}"/>.</returns>
        public static List<GetKeys_Output_Class> FromJson(string json) => JsonConvert.DeserializeObject<List<GetKeys_Output_Class>>(json, SimpleDB_Converter.Settings);

        /// <summary>
        /// The ToJson.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string ToJson() => JsonConvert.SerializeObject(this, SimpleDB_Converter.Settings);
    }
}
