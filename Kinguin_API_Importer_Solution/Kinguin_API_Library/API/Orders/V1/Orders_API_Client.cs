namespace IVolt.Kinguin.API.Orders.V1
{
    using IVolt.Kinguin.API.Configuration;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="Orders_API_Client" />.
    /// </summary>
    public static class Orders_API_Client
    {
        /// <summary>
        /// The PlaceOrder.
        /// </summary>
        /// <param name="orderInfo">The orderInfo<see cref="Place_Order_Info"/>.</param>
        /// <returns>The <see cref="Place_Order_Response"/>.</returns>
        public static Place_Order_Response PlaceOrder(Place_Order_Info orderInfo)
        {
            using (WebClient _WebClient = new WebClient())
            {
                _WebClient.Headers.Add("X-Api-Key: " + Globals.APIKEY);
                string _tmpReturn = _WebClient.UploadString(Globals.OrdersV1Baseurl, orderInfo.ToJson());
                return Place_Order_Response.FromJson(_tmpReturn);
            }
        }

        /// <summary>
        /// The SearchOrders.
        /// </summary>
        /// <param name="searchInfo">The searchInfo<see cref="Search_Orders_Struct"/>.</param>
        /// <returns>The <see cref="Order_Search_Response"/>.</returns>
        public static Order_Search_Response SearchOrders(Search_Orders_Struct searchInfo)
        {
            string _SearchData = searchInfo.BuildQueryString();
            if (_SearchData.ToString() == "") { return null; }
            _SearchData = "?" + _SearchData.TrimEnd(',');

            using (WebClient _WebClient = new WebClient())
            {
                _WebClient.Headers.Add("X-Api-Key: " + Globals.APIKEY);
                return Order_Search_Response.FromJson(_WebClient.DownloadString(Globals.OrdersV1Baseurl + _SearchData));
            }
        }
    }
}
