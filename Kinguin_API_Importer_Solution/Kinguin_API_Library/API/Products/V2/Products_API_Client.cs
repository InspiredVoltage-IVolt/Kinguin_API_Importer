namespace IVolt.Kinguin.API.Products.V2
{
    using IVolt.Kinguin.API.Objects;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="Products_API_Client" />.
    /// </summary>
    public static class Products_API_Client
    {
        /// <summary>
        /// The GetProductByID.
        /// </summary>
        /// <param name="Product_ID">The Product_ID<see cref="int"/>.</param>
        /// <returns>The <see cref="Kinguin_Product"/>.</returns>
        public static Kinguin_Product GetProductByID(int Product_ID)
        {
            using (WebClient _WebClient = new WebClient())
            {
                _WebClient.Headers.Add("X-Api-Key: " + Globals.APIKEY);
                string _ProductJSON = _WebClient.DownloadString(Globals.ProductsV2Baseurl + Product_ID.ToString());
                return Kinguin_Product.FromJson(_ProductJSON);
            }
        }
    }
}
