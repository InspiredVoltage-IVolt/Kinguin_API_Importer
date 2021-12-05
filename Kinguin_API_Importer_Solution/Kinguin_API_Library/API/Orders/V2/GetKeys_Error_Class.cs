namespace IVolt.Kinguin.API.API.Orders.V2
{
    using IVolt.Kinguin.API.Configuration;
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// Defines the <see cref="GetKeys_Error_Class" />.
    /// </summary>
    public class GetKeys_Error_Class
    {
        /// <summary>
        /// Gets or sets the Kind.
        /// </summary>
        [JsonProperty("kind", NullValueHandling = NullValueHandling.Ignore)]
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public long? Status { get; set; }

        /// <summary>
        /// Gets or sets the Detail.
        /// </summary>
        [JsonProperty("detail", NullValueHandling = NullValueHandling.Ignore)]
        public string Detail { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the Path.
        /// </summary>
        [JsonProperty("path", NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the Method.
        /// </summary>
        [JsonProperty("method", NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the Timestamp.
        /// </summary>
        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the Trace.
        /// </summary>
        [JsonProperty("trace", NullValueHandling = NullValueHandling.Ignore)]
        public string Trace { get; set; }

        /// <summary>
        /// Gets or sets the Retryable.
        /// </summary>
        [JsonProperty("retryable", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Retryable { get; set; }

        /// <summary>
        /// Gets or sets the OrderId.
        /// </summary>
        [JsonProperty("orderId", NullValueHandling = NullValueHandling.Ignore)]
        public string OrderId { get; set; }

        /// <summary>
        /// The FromJson.
        /// </summary>
        /// <param name="json">The json<see cref="string"/>.</param>
        /// <returns>The <see cref="GetKeys_Error_Class"/>.</returns>
        public static GetKeys_Error_Class FromJson(string json) => JsonConvert.DeserializeObject<GetKeys_Error_Class>(json, SimpleDB_Converter.Settings);

        /// <summary>
        /// The ToJson.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string ToJson() => JsonConvert.SerializeObject(this, Converter.Settings);
    }
}
