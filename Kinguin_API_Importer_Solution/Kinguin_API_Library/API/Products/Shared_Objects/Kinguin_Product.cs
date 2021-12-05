namespace IVolt.Kinguin.API.Objects
{
    using IVolt.Kinguin.API.Configuration;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Kinguin_Product" />.
    /// </summary>
    public partial class Kinguin_Product
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [JsonIgnore()]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the JSON File.
        /// </summary>
        [JsonIgnore()]
        public string JSONFileName { get; set; }


        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the CoverImage.
        /// </summary>
        [JsonProperty("coverImage", NullValueHandling = NullValueHandling.Ignore)]
        public string CoverImage { get; set; }

        /// <summary>
        /// Gets or sets the CoverImageOriginal.
        /// </summary>
        [JsonProperty("coverImageOriginal", NullValueHandling = NullValueHandling.Ignore)]
        public string CoverImageOriginal { get; set; }

        /// <summary>
        /// Gets or sets the Developers.
        /// </summary>
        [JsonProperty("developers", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Developers { get; set; }

        /// <summary>
        /// Gets or sets the Publishers.
        /// </summary>
        [JsonProperty("publishers", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Publishers { get; set; }

        /// <summary>
        /// Gets or sets the Genres.
        /// </summary>
        [JsonProperty("genres", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Genres { get; set; }

        /// <summary>
        /// Gets or sets the Platform.
        /// </summary>
        [JsonProperty("platform", NullValueHandling = NullValueHandling.Ignore)]
        public string Platform { get; set; }

        /// <summary>
        /// Gets or sets the ReleaseDate.
        /// </summary>
        [JsonProperty("releaseDate", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets the Qty.
        /// </summary>
        [JsonProperty("qty", NullValueHandling = NullValueHandling.Ignore)]
        public long? Qty { get; set; }

        /// <summary>
        /// Gets or sets the TextQty.
        /// </summary>
        [JsonProperty("textQty", NullValueHandling = NullValueHandling.Ignore)]
        public long? TextQty { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
        public double? Price { get; set; }

        /// <summary>
        /// Gets or sets the CheapestOfferId.
        /// </summary>
        [JsonProperty("cheapestOfferId", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> CheapestOfferId { get; set; }

        /// <summary>
        /// Gets or sets the IsPreorder.
        /// </summary>
        [JsonProperty("isPreorder", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPreorder { get; set; }

        /// <summary>
        /// Gets or sets the MetacriticScore.
        /// </summary>
        [JsonProperty("metacriticScore", NullValueHandling = NullValueHandling.Ignore)]
        public long? MetacriticScore { get; set; }

        /// <summary>
        /// Gets or sets the RegionalLimitations.
        /// </summary>
        [JsonProperty("regionalLimitations", NullValueHandling = NullValueHandling.Ignore)]
        public string RegionalLimitations { get; set; }

        /// <summary>
        /// Gets or sets the RegionId.
        /// </summary>
        [JsonProperty("regionId", NullValueHandling = NullValueHandling.Ignore)]
        public long? RegionId { get; set; }

        /// <summary>
        /// Gets or sets the ActivationDetails.
        /// </summary>
        [JsonProperty("activationDetails", NullValueHandling = NullValueHandling.Ignore)]
        public string ActivationDetails { get; set; }

        /// <summary>
        /// Gets or sets the KinguinId.
        /// </summary>
        [JsonProperty("kinguinId", NullValueHandling = NullValueHandling.Ignore)]
        public long? KinguinId { get; set; }

        /// <summary>
        /// Gets or sets the ProductId.
        /// </summary>
        [JsonProperty("productId", NullValueHandling = NullValueHandling.Ignore)]
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the OriginalName.
        /// </summary>
        [JsonProperty("originalName", NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalName { get; set; }

        /// <summary>
        /// Gets or sets the Screenshots.
        /// </summary>
        [JsonProperty("screenshots", NullValueHandling = NullValueHandling.Ignore)]
        public List<Kinguin_Product_Screenshot> Screenshots { get; set; }

        /// <summary>
        /// Gets or sets the Videos.
        /// </summary>
        [JsonProperty("videos", NullValueHandling = NullValueHandling.Ignore)]
        public List<Kinguin_Product_Video> Videos { get; set; }

        /// <summary>
        /// Gets or sets the Languages.
        /// </summary>
        [JsonProperty("languages", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Languages { get; set; }

        /// <summary>
        /// Gets or sets the SystemRequirements.
        /// </summary>
        [JsonProperty("systemRequirements", NullValueHandling = NullValueHandling.Ignore)]
        public List<Kinguin_Product_System_Requirement> SystemRequirements { get; set; }

        /// <summary>
        /// Gets or sets the Tags.
        /// </summary>
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the Offers.
        /// </summary>
        [JsonProperty("offers", NullValueHandling = NullValueHandling.Ignore)]
        public List<Kinguin_Product_Offer> Offers { get; set; }

        /// <summary>
        /// Gets or sets the OffersCount.
        /// </summary>
        [JsonProperty("offersCount", NullValueHandling = NullValueHandling.Ignore)]
        public long? OffersCount { get; set; }

        /// <summary>
        /// Gets or sets the TotalQty.
        /// </summary>
        [JsonProperty("totalQty", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalQty { get; set; }

        /// <summary>
        /// Gets or sets the MerchantName.
        /// </summary>
        [JsonProperty("merchantName", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> MerchantName { get; set; }

        /// <summary>
        /// Gets or sets the Images.
        /// </summary>
        [JsonProperty("images", NullValueHandling = NullValueHandling.Ignore)]
        public Kinguin_Product_Image Images { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedAt.
        /// </summary>
        [JsonProperty("updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// The FromJson.
        /// </summary>
        /// <param name="json">The json<see cref="string"/>.</param>
        /// <returns>The <see cref="Kinguin_Product"/>.</returns>
        public static Kinguin_Product FromJson(string json) => JsonConvert.DeserializeObject<Kinguin_Product>(json, SimpleDB_Converter.Settings);

        /// <summary>
        /// The ToJson.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string ToJson() => JsonConvert.SerializeObject(this, SimpleDB_Converter.Settings);
    }
}
