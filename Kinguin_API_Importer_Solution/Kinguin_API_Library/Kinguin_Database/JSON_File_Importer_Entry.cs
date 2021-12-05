using ACT.Core.Extensions;
using IVolt.Kinguin.API.DB;
using IVolt.Kinguin.API.LocalDB;
using IVolt.Kinguin.API.Objects;
using IVolt.Kinguin.API.Security;
using System.Collections.Concurrent;
using System.Data.SqlClient;

namespace IVolt.Kinguin.API.Local
{

    /// <summary>
    /// Defines the <see cref="JSON_File_Importer" />.
    /// </summary>
    public static partial class JSON_File_Importer
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
        private static Dictionary<string, DateTime> _ImportedFiles = new Dictionary<string, DateTime>();


        #endregion

        /// <summary>
        /// Start Tje Import ProcessProcess.
        /// </summary>
        public static void Process()
        {
            ACT.Core.SystemSettings.LoadedSettings.Clear();
            ACT.Core.SystemSettings.LoadSystemSettings();
            var _Files = System.IO.Directory.GetFiles(FileSecurity.KinguinLocalDownloadFolder_Protected, "*.json", SearchOption.AllDirectories).ToList();


            _ImportedFiles.Clear();
            _AllMetaData.Clear();
            _AllOffers.Clear();
            KinguinProductRefs.Clear();
            ErrorLog.Clear();

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

                Console.WriteLine(x.ToString() + "to" + (x + 500).ToString() + " out of " + ImportFiles.Count.ToString());

                // Loads KinguinProductRefs, _AllOffers, and AllMetaData
                QuickLoadData(ImportFiles.GetRange(x, SelectionCount));

                #region Add / INSERT ALL META DATA INTO DATABASE (_AllMetaData)
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

                #region Add / INSERT ALL OFFERS INTO DATABASE (_AllOfferS)
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

                /// Save Prodycts To Database (KinguinProductRefs)
                SaveProductsToDatabase();

                /// Save Import Log

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
        /// Saves the Import Log Data
        /// </summary>
        private static void SaveImportLog()
        {
            using (var bcp = new SqlBulkCopy(FileSecurity.KinguinDatabase_ConnectionString_Protected))
            using (var reader = FastMember.ObjectReader.Create(KinguinProductRefs))
            {
                bcp.ColumnMappings.Add("ImportID", "ImportID");
                bcp.ColumnMappings.Add("JSONFileName", "JSONFileName");
                bcp.ColumnMappings.Add("DateModified", "UpdatedAt");
                bcp.DestinationTableName = "Import_Log";
                bcp.WriteToServer(reader);
            }
        }

        /// <summary>
        /// Save current Global Variable KinguinProductRefs to the Database
        /// Uses the Setting KinguinDatabase_ConnectionString in ConfigurationSettings.xml
        /// </summary>
        private static Guid SaveProductsToDatabase()
        {
            #region Add / INSERT ALL META DATA INTO DATABASE
            var _t = KinguinProductRefs.ToList();

            Guid _ImportID = Guid.NewGuid();

            foreach (var P in _t)
            {
                if (P.ReleaseDate < new DateTime(1920, 1, 1)) { P.ReleaseDate = null; }
                P.ImportID = _ImportID;
                if (P.UpdatedAt == null || P.ReleaseDate < new DateTime(1920, 1, 1)) { P.UpdatedAt = DateTime.Now; }
            }

            using (var bcp = new SqlBulkCopy(FileSecurity.KinguinDatabase_ConnectionString_Protected))
            using (var reader = FastMember.ObjectReader.Create(_t))
            {
                bcp.ColumnMappings.Add("Name", "Name");
                bcp.ColumnMappings.Add("JSONFileName", "JSONFileName");
                bcp.ColumnMappings.Add("Description", "Description");
                bcp.ColumnMappings.Add("CoverImage", "CoverImage");
                bcp.ColumnMappings.Add("CoverImageOriginal", "CoverImageOriginal");
                bcp.ColumnMappings.Add("Platform", "Platform");
                bcp.ColumnMappings.Add("Qty", "Qty");
                bcp.ColumnMappings.Add("TextQty", "TextQty");
                bcp.ColumnMappings.Add("Price", "Price");
                bcp.ColumnMappings.Add("IsPreorder", "IsPreorder");
                bcp.ColumnMappings.Add("MetacriticScore", "MetacriticScore");
                bcp.ColumnMappings.Add("RegionalLimitations", "RegionalLimitations");
                bcp.ColumnMappings.Add("RegionId", "RegionId");
                bcp.ColumnMappings.Add("ActivationDetails", "ActivationDetails");
                bcp.ColumnMappings.Add("KinguinId", "KinguinId");
                bcp.ColumnMappings.Add("ProductId", "ProductId");
                bcp.ColumnMappings.Add("OriginalName", "OriginalName");
                bcp.ColumnMappings.Add("OffersCount", "OffersCount");
                bcp.ColumnMappings.Add("TotalQty", "TotalQty");
                bcp.ColumnMappings.Add("UpdatedAt", "UpdatedAt");
                bcp.ColumnMappings.Add("ImportID", "ImportID");
                bcp.DestinationTableName = "KinguinProduct";
                bcp.WriteToServer(reader);
            }
            _t.Clear();

            return _ImportID;
            #endregion
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
