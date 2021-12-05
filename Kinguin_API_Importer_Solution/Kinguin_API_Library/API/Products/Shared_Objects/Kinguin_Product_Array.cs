namespace IVolt.Kinguin.API.Objects
{
    using IVolt.Kinguin.API.Configuration;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Kinguin_Product_Array" />.
    /// </summary>
    public class Kinguin_Product_Array
    {
        /// <summary>
        /// Gets or sets the Products.
        /// </summary>
        [JsonProperty("results", NullValueHandling = NullValueHandling.Ignore)]
        public List<Kinguin_Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the ItemCount.
        /// </summary>
        [JsonProperty("item_count", NullValueHandling = NullValueHandling.Ignore)]
        public int ItemCount { get; set; }

        /// <summary>
        /// The FromJson.
        /// </summary>
        /// <param name="json">The json<see cref="string"/>.</param>
        /// <returns>The <see cref="Kinguin_Product_Array"/>.</returns>
        public static Kinguin_Product_Array FromJson(string json)
        {
            var _tmpReturn = JsonConvert.DeserializeObject<Kinguin_Product_Array>(json.Replace(",[],", ",").Replace(",[]", "").Replace("\"videos\":[[]]", "\"videos\":[]"), SimpleDB_Converter.Settings);
            
            if (_tmpReturn == null) { return null;}

            int _PKID = 1;
            foreach (var Prod in _tmpReturn.Products)
            {
                Prod.ID = _PKID;
                _PKID++;
            }
            return _tmpReturn;
        }

        /// <summary>
        /// The ToJson.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string ToJson() => JsonConvert.SerializeObject(this, SimpleDB_Converter.Settings);
    }
}
