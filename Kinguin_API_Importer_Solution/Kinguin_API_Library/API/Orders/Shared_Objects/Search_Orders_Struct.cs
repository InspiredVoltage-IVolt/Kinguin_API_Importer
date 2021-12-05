namespace IVolt.Kinguin.API.Configuration
{
    /// <summary>
    /// Defines the <see cref="Search_Orders_Struct" />.
    /// </summary>
    public class Search_Orders_Struct
    {
        /// <summary>
        /// Defines the page.
        /// </summary>
        public int page = -1;

        /// <summary>
        /// Defines the limit.
        /// </summary>
        public int limit = -1;

        /// <summary>
        /// Defines the sortBy.
        /// </summary>
        public string sortBy = null;

        /// <summary>
        /// Defines the sortType.
        /// </summary>
        public string sortType = null;

        /// <summary>
        /// Defines the totalPriceFrom.
        /// </summary>
        public float totalPriceFrom = -1;

        /// <summary>
        /// Defines the totalPriceTo.
        /// </summary>
        public float totalPriceTo = -1;

        /// <summary>
        /// Defines the createdAtFrom.
        /// </summary>
        public string createdAtFrom = null;

        /// <summary>
        /// Defines the createdAtTo.
        /// </summary>
        public string createdAtTo = null;

        /// <summary>
        /// Defines the kinguinId.
        /// </summary>
        public int kinguinId = -1;

        /// <summary>
        /// Defines the productId.
        /// </summary>
        public string productId = null;

        /// <summary>
        /// Defines the orderId.
        /// </summary>
        public string orderId = null;

        /// <summary>
        /// Defines the kinguinOrderId.
        /// </summary>
        public int kinguinOrderId = -1;

        /// <summary>
        /// Defines the orderExternalId.
        /// </summary>
        public string orderExternalId = null;

        /// <summary>
        /// Defines the name.
        /// </summary>
        public string name = null;

        /// <summary>
        /// Defines the status.
        /// </summary>
        public string status = null;

        /// <summary>
        /// Defines the isPreorder.
        /// </summary>
        public string isPreorder = null;

        /// <summary>
        /// The BuildQueryString.
        /// </summary>
        /// <returns>The <see cref="string"/>.</returns>
        public string BuildQueryString()
        {
            string _tmpReturn = "?";
            if (page != -1) { _tmpReturn += "page=" + page.ToString() + ","; }
            if (limit != -1) { _tmpReturn += "limit=" + limit.ToString() + ","; }
            if (totalPriceFrom != -1) { _tmpReturn += "totalPriceFrom=" + totalPriceFrom.ToString() + ","; }
            if (totalPriceTo != -1) { _tmpReturn += "totalPriceTo=" + totalPriceTo.ToString() + ","; }
            if (kinguinId != -1) { _tmpReturn += "regionId=" + kinguinId.ToString() + ","; }
            if (kinguinOrderId != -1) { _tmpReturn += "kinguinOrderId=" + kinguinOrderId.ToString() + ","; }

            if (sortBy != null) { _tmpReturn += "sortBy=" + sortBy.ToString() + ","; }
            if (sortType != null) { _tmpReturn += "sortType=" + sortType.ToString() + ","; }
            if (createdAtFrom != null) { _tmpReturn += "createdAtFrom=" + createdAtFrom.ToString() + ","; }
            if (createdAtTo != null) { _tmpReturn += "createdAtTo=" + createdAtTo.ToString() + ","; }
            if (productId != null) { _tmpReturn += "productId=" + productId.ToString() + ","; }
            if (orderId != null) { _tmpReturn += "orderId=" + orderId.ToString() + ","; }
            if (orderExternalId != null) { _tmpReturn += "orderExternalId=" + orderExternalId.ToString() + ","; }
            if (name != null) { _tmpReturn += "name=" + name.ToString() + ","; }
            if (status != null) { _tmpReturn += "status=" + status.ToString() + ","; }
            if (isPreorder != null) { _tmpReturn += "isPreorder=" + isPreorder.ToString() + ","; }

            if (_tmpReturn != "") { _tmpReturn = _tmpReturn.TrimEnd(','); }
            return _tmpReturn;
        }
    }
}
