using ACT.Core.Extensions;
using IVolt.Kinguin.API.DB;
using IVolt.Kinguin.API.Enums;
using IVolt.Kinguin.API.LocalDB;
using IVolt.Kinguin.API.Objects;
using IVolt.Kinguin.API.Security;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Genres = IVolt.Kinguin.API.LocalDB.Genres;
using Tags = IVolt.Kinguin.API.LocalDB.Tags;

namespace IVolt.Kinguin.API.Local
{

    /// <summary>
    /// Defines the <see cref="Import_Json_Files_Into_Database" />.
    /// </summary>
    public static partial class Import_Json_Files_Into_Database
    {

        #region Variables / Fields

        /// <summary>
        /// General Error Log
        /// </summary>
        public static List<string> ErrorLog = new List<string>();

        /// <summary>
        /// Concurrent Thread Safe Variables
        /// </summary>
        internal static ConcurrentBag<DatabaseMetaData_Struct> _AllMetaData = new ConcurrentBag<DatabaseMetaData_Struct>();
        internal static ConcurrentBag<Kinguin_Product_Offer> _AllOffers = new ConcurrentBag<Kinguin_Product_Offer>();
        internal static ConcurrentBag<Kinguin_Product> KinguinProductRefs = new ConcurrentBag<Kinguin_Product>();

        // Non Thread Safe Product Variables

        private static List<int> ProductsInserted = new List<int>();
        private static List<string> ProductsNotInserted = new List<String>();


        #endregion

        /// <summary>
        /// Start Tje Import ProcessProcess.
        /// </summary>
        public static void Process()
        {
            ACT.Core.SystemSettings.LoadedSettings.Clear();
            ACT.Core.SystemSettings.LoadSystemSettings();
            var _Files = System.IO.Directory.GetFiles(FileSecurity.KinguinLocalDownloadFolder_Protected, "*.json", SearchOption.AllDirectories).ToList();

            // IMPORT META DATA and OFFERS
            ImportCollectedMetaData(_Files);
            
            // Download and Save All Images To Database
            DownloadAllImages();
        }

        /// <summary>
        /// Loads and Saves Data To Database
        /// </summary>
        /// <param name="ImportFiles"></param>
        public static void ImportCollectedMetaData(List<string> ImportFiles)
        {
            for (int x = 0; x < ImportFiles.Count; x += 500)
            {
                int SelectionCount = 500;

                if (ImportFiles.Count - x < 500) { SelectionCount = ImportFiles.Count - x; }

                Console.WriteLine(x.ToString() + "to" + SelectionCount.ToString());

                QuickLoadData(ImportFiles.GetRange(x, SelectionCount));

                #region Add / INSERT ALL META DATA INTO DATABASE
                List<DatabaseMetaData_Struct> _t = new List<DatabaseMetaData_Struct>();
                _t.AddRange(_AllMetaData);
                using (var bcp = new SqlBulkCopy(FileSecurity.KinguinDatabase_ConnectionString_Protected))
                using (var reader = FastMember.ObjectReader.Create(_t))
                {
                    bcp.ColumnMappings.Add("V1", "V1");
                    bcp.ColumnMappings.Add("V2", "V2");
                    bcp.ColumnMappings.Add("TableName", "TableName");
                    bcp.ColumnMappings.Add("KProductID", "KProductID");
                    bcp.DestinationTableName = "All_META_DATA";
                    bcp.WriteToServer(reader);
                }
                _t.Clear();
                #endregion

                #region Add / INSERT ALL INTO DATABASE
                using (var bcp1 = new SqlBulkCopy(FileSecurity.KinguinDatabase_ConnectionString_Protected))
                using (var reader1 = FastMember.ObjectReader.Create(_AllOffers))
                {
                    bcp1.ColumnMappings.Add("MerchantName", "MerchantName");
                    bcp1.ColumnMappings.Add("Name", "Name");
                    bcp1.ColumnMappings.Add("ID", "OfferID");
                    bcp1.ColumnMappings.Add("Price", "Price");
                    bcp1.ColumnMappings.Add("Qty", "Quantity");
                    bcp1.ColumnMappings.Add("KProductID", "KProductID");
                    bcp1.ColumnMappings.Add("TextQty", "TextQty");
                    bcp1.ColumnMappings.Add("ReleaseDate", "ReleaseDate");
                    bcp1.ColumnMappings.Add("IsPreorder", "IsPreorder");

                    bcp1.DestinationTableName = "Offers";
                    bcp1.WriteToServer(reader1);
                }

                #endregion



                LoadAllProducts();

                KinguinProductRefs.Clear();
                _AllOffers.Clear();
                _AllMetaData.Clear();

                Console.WriteLine("STARTING IMPORT OF RAW META DATA");
                Console.WriteLine("-----------------");

                IVolt.Kinguin.API.LocalDB.PROC.PRODUCT.ADD.UPDATE.META.DATA.Execute.Proc();


                Console.WriteLine("FINISHED IMPORT META DATA SECTION");
                Console.WriteLine("-----------------");

               // IVolt.Kinguin.API.LocalDB.PROC.PRODUCT.CREATE.RELATIONSHIPS.Execute.Proc();

            }

            foreach (var PNI in ProductsNotInserted)
            {
                LocalDB.Global_ImportErrors _A = new Global_ImportErrors();
                _A.ErrDesc = "Product File: " + PNI;
                _A.Create();
            }
            ProductsNotInserted.Clear();
        }



        /// <summary>
        /// Save current Global Variable KinguinProductRefs to the Database
        /// </summary>
        private static void LoadAllProducts()
        {
            foreach (var P in KinguinProductRefs)
            {
                if (P.ReleaseDate < new DateTime(1920, 1, 1)) { P.ReleaseDate = null; }

                var _ProductIDResultA = LocalDB.PROC.PRODUCT.ADD.Execute.Proc(P.Name, P.JSONFileName, P.Description,
                    P.CoverImage, P.CoverImageOriginal,
                    P.Platform, P.ReleaseDate, (int?)P.Qty,
                    (int?)P.TextQty, (decimal)P.Price,
                    P.IsPreorder, (int?)P.MetacriticScore,
                    P.RegionalLimitations,
                    (int?)P.RegionId, P.ActivationDetails,
                    (int?)P.KinguinId, P.ProductId, P.OriginalName,
                    (int?)P.OffersCount, (int?)P.TotalQty,
                    P.UpdatedAt);

                var _ProductIDResult = _ProductIDResultA.FirstDataTable_WithRows();

                if (_ProductIDResult == null)
                {
                    ProductsNotInserted.Add(P.JSONFileName);
                    ErrorLog.Add("Critical Error: Unable To Add Product! ProductID: " + P.ProductId + ": KinguinProductId: " + P.KinguinId.ToString() + ":" + P.JSONFileName);
                    continue;
                }

                int _ProductID = _ProductIDResult.Rows[0]["ID"].ToInt(-1);

                if (_ProductID == -1)
                {
                    ProductsNotInserted.Add(P.JSONFileName);
                    ErrorLog.Add("Critical Error: Unable To Add Product! ProductID: " + P.ProductId + ": KinguinProductId: " + P.KinguinId.ToString() + ":" + P.JSONFileName);
                    return;
                }

                ProductsInserted.Add(_ProductID);
            }           
        }

        /// <summary>
        /// Gets the Kinguin Intermediate Database Product ID Based On the KinguinProductID
        /// </summary>
        /// <param name="KinguinProductId"></param>
        /// <returns></returns>
       public static int GetProductByKinguinProductId(string KinguinProductId)
        {
            using (var TestForExistingProduct = LocalDB.PROC.PRODUCTS.SEARCH.BY.KINGUINID.Execute
                                                       .Proc(KinguinProductId).FirstDataTable_WithRows())
            {
                // ReSharper disable once ConvertIfStatementToReturnStatement
                if (TestForExistingProduct != null)
                {
                    return TestForExistingProduct.Rows[0]["ID"].ToInt();
                }
            }

            return 0;
        }


    }
}
