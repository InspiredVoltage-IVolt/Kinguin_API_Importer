namespace IVolt.Kinguin.API.Orders.V2
{
    using IVolt.Kinguin.API.Configuration;
    using System.Collections.Generic;
    using System.Net;

    /// <summary>
    /// Defines the <see cref="Orders_API_Client" />.
    /// </summary>
    public static class Orders_API_Client
    {
        /// <summary>
        /// The GetOrder_Keys.
        /// </summary>
        /// <param name="OrderID">The OrderID<see cref="string"/>.</param>
        /// <returns>The <see cref="List{Order_Keys}"/>.</returns>
        public static List<Order_Keys> GetOrder_Keys(string OrderID)
        {
            string _APIURL = Globals.OrdersV2Baseurl + "/#ORDERID#/keys";
            _APIURL = _APIURL.Replace("#ORDERID#", OrderID.ToString());
            using (WebClient _WebClient = new WebClient())
            {
                _WebClient.Headers.Add("X-Api-Key: " + Globals.APIKEY);
                string _tmpReturn = _WebClient.DownloadString(_APIURL);
                return Order_Keys.FromJson(_tmpReturn);
            }
        }
    }
}
