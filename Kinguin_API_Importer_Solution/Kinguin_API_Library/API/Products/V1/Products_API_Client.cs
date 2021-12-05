namespace IVolt.Kinguin.API.Products.V1
{
    using IVolt.Kinguin.API.Objects;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="Products_API_Client" />.
    /// </summary>
    public static class Products_API_Client
    {
        /// <summary>
        /// Store the Loading History Here;.
        /// </summary>
        internal class MassDownloadPathInfo
        {
            /// <summary>
            /// Defines the FullPath.
            /// </summary>
            public string FullPath = "";

            /// <summary>
            /// Defines the FolderName.
            /// </summary>
            public string FolderName = "";

            /// <summary>
            /// Defines the FolderDateTime.
            /// </summary>
            public DateTime FolderDateTime = DateTime.MinValue;

            /// <summary>
            /// Defines the JSON_FileCount.
            /// </summary>
            public int JSON_FileCount = 0;

            /// <summary>
            /// Defines the Valid_JSON_Count.
            /// </summary>
            public int Valid_JSON_Count = 0;

            /// <summary>
            /// Defines the LoadedProductIDs.
            /// </summary>
            public List<ProductIDInfo> LoadedProductIDs = new List<ProductIDInfo>();
        }

        /// <summary>
        /// Defines the <see cref="ProductIDInfo" />.
        /// </summary>
        internal class ProductIDInfo
        {
            /// <summary>
            /// Defines the Name.
            /// </summary>
            public string Name = "";

            /// <summary>
            /// Defines the Invalid.
            /// </summary>
            public bool Invalid = false;

            /// <summary>
            /// Defines the DatabaseID.
            /// </summary>
            public Guid DatabaseID = Guid.Empty;

            /// <summary>
            /// Defines the KinguinProductID.
            /// </summary>
            public string KinguinProductID = "";

            // Not Used Yet
            /// <summary>
            /// Defines the NopCommerceProductID.
            /// </summary>
            public int NopCommerceProductID = 0;
        }

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
                string _ProductJSON = _WebClient.DownloadString(Globals.ProductsV1Baseurl + Product_ID.ToString());
                return Kinguin_Product.FromJson(_ProductJSON);
            }
        }

        /// <summary>
        /// The SearchProducts.
        /// </summary>
        /// <param name="searchProperties">The searchProperties<see cref="Configuration.Search_Orders_Struct"/>.</param>
        /// <returns>The <see cref="List{Kinguin_Product}"/>.</returns>
        public static List<Kinguin_Product> SearchProducts(Configuration.Search_Orders_Struct searchProperties)
        {
            using (WebClient _WebClient = new WebClient())
            {
                _WebClient.Headers.Add("X-Api-Key", Globals.APIKEY);
                string _ProductJSON = _WebClient.DownloadString(Globals.ProductsV1Baseurl.TrimEnd('/') + searchProperties.BuildQueryString());
                return IVolt.Kinguin.API.Objects.Kinguin_Product_Array.FromJson(_ProductJSON).Products;
            }
        }

        /// <summary>
        /// The SearchProducts.
        /// </summary>
        /// <param name="searchProperties">The searchProperties<see cref="Configuration.Search_Orders_Struct"/>.</param>
        /// <returns>The <see cref="List{Kinguin_Product}"/>.</returns>
        public static List<string> SearchProductsReturnString(Configuration.Search_Orders_Struct searchProperties)
        {
	        List<string> _tmpReturn = new List<string> ();
	        using (WebClient _WebClient = new WebClient())
	        {
		        _WebClient.Headers.Add("X-Api-Key", Globals.APIKEY);
		        string _ProductJSON = _WebClient.DownloadString(Globals.ProductsV1Baseurl.TrimEnd('/') + searchProperties.BuildQueryString());
		        _tmpReturn.Add (_ProductJSON);
	        }

	        return _tmpReturn;
        }

        /// <summary>
        /// Defines the _OriginalBasePath.
        /// </summary>
        private static string _OriginalBasePath = "";

        /// <summary>
        /// The UploadAllDownloadedProducts.
        /// </summary>
        /// <param name="LastPageID">The LastPageID<see cref="int"/>.</param>
        /// <param name="BasePath">The BasePath<see cref="string"/>.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public static int UploadAllDownloadedProducts(int LastPageID = 1, string BasePath = "")
        {
            string _WorkingPath = "";
            int _tmpInstalled = 0;
            List<MassDownloadPathInfo> _PathInfo = new List<MassDownloadPathInfo>();
            DateTime _LastDateTime = DateTime.MinValue;

            if (_OriginalBasePath != BasePath) { _WorkingPath = ""; }

            if (_WorkingPath == "")
            {
                if (BasePath == null) { BasePath = AppDomain.CurrentDomain.BaseDirectory; }
                else if (System.IO.Directory.Exists(BasePath) == false) { BasePath = AppDomain.CurrentDomain.BaseDirectory; }

                // Ensure _Working Path Ends With \\
                if (!BasePath.EndsWith("\\")) { BasePath += "\\"; }

                _OriginalBasePath = BasePath;
                _WorkingPath = BasePath;
            }

            // GET ALL THE Downloaded DIRECTORIES -- FULL PATHS
            var _Directories = System.IO.Directory.GetDirectories(_WorkingPath);

            foreach (string dir in _Directories)
            {
                DateTime _DownloadDate = DateTime.MinValue;
                ;
                System.IO.DirectoryInfo _D = new DirectoryInfo(dir);

                try { _DownloadDate = Convert.ToDateTime(_D.Name.Replace("\\", "").Trim()); }
                catch { }

                _PathInfo.Add(new MassDownloadPathInfo()
                {
                    FullPath = dir,
                    FolderName = _D.Name,
                    FolderDateTime = _DownloadDate
                });
            }

            // GO Through All Paths
            foreach (var pathInfo in _PathInfo)
            {
                List<FileInfo> DirectoryFileInfo = new DirectoryInfo(pathInfo.FullPath).GetFiles().ToList();
                var AllFileInfo = DirectoryFileInfo.Where(x => x.Extension.ToLower() == "json").ToList();
                pathInfo.JSON_FileCount = AllFileInfo.Count();

                foreach (var fileInfo in AllFileInfo)
                {
                    ProductIDInfo _info = new ProductIDInfo { Name = fileInfo.FullName };
                    string _tmpJSON = File.ReadAllText(fileInfo.FullName);
                    if (_tmpJSON.Contains("kinguin") == false) { _info.Invalid = true; }

                    var _KinguinProduct = Kinguin_Product.FromJson(_tmpJSON);

                    var _ProductData = IVolt.Kinguin.API.LocalDB.PROC.PRODUCTS.SEARCH.BY.KINGUINID.Execute.Proc(_KinguinProduct.ProductId).FirstDataTable_WithRows();

                    if (_ProductData == null)
                    {

                    }
                }


            }

            return _tmpInstalled;
        }

        /// <summary>
        /// Allows Resume Function Through the use of LastPageID.
        /// </summary>
        /// <param name="LastPageID">Last Page ID.</param>
        /// <param name="BasePath">The BasePath<see cref="string"/>.</param>
        /// <returns>The <see cref="(int page, int totalDownloads)"/>.</returns>
        public static (int page, int totalDownloads) DownloadAllProducts(int LastPageID = 1, string BasePath = "")
        {
            string _WorkingPath = "";

            if (_OriginalBasePath != BasePath) { _WorkingPath = ""; }

            if (_WorkingPath == "")
            {
                if (BasePath == null) { BasePath = AppDomain.CurrentDomain.BaseDirectory; }
                else if (System.IO.Directory.Exists(BasePath) == false) { BasePath = AppDomain.CurrentDomain.BaseDirectory; }

                // Ensure _Working Path Ends With \\
                if (!BasePath.EndsWith("\\")) { BasePath += "\\"; }

                _OriginalBasePath = BasePath;
                _WorkingPath = BasePath;
            }


            List<string> ExistingProducts = new List<string>();

            foreach (string file in System.IO.Directory.GetFiles(_WorkingPath))
            {
                if (file.ToLower().EndsWith(".json"))
                {
                    ExistingProducts.Add(file.Substring(0, file.IndexOf('.')));
                }
            }

            var _SO = new IVolt.Kinguin.API.Configuration.Search_Orders_Struct();

            var now = DateTime.Now;

            string _BPD = now.Month + "-" + now.Day + "-" + now.Year + "\\";
            var WorkingPathNew = _WorkingPath + _BPD;

            try
            {
                System.IO.Directory.CreateDirectory(WorkingPathNew);
            }
            catch
            {
                throw new Exception("Error Creating Output Path");
            }

            bool _hasData = true;
            int _PageID = LastPageID;
            int _TotalCount = 0;
            try
            {
                while (_hasData)
                {
                    _SO.page = _PageID;
                    var _Results = SearchProducts(_SO);

                    if (!_Results.Any())
                    {
                        _hasData = false;
                        continue;
                    }
                    if (System.IO.Directory.Exists(WorkingPathNew) == false)
                    {
                        System.IO.Directory.CreateDirectory(WorkingPathNew);
                    }

                    Parallel.ForEach (_Results, ProductItem =>
                    {

	                    if (!ExistingProducts.Contains (ProductItem.ProductId))
	                    {
		                    System.IO.File.WriteAllText (
			                    WorkingPathNew + ProductItem.ProductId + "_" + _PageID.ToString () + ".json",
			                    ProductItem.ToJson ());
	                    }
	                    Interlocked.Increment(ref _TotalCount);
                    });

                    _PageID++;
                }
            }
            catch
            {
                return (_PageID, _TotalCount);
            }

            return (_PageID, -1);
        }
    }
}
