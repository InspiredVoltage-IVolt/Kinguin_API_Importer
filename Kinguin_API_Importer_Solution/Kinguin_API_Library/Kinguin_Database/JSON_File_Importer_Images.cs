using ACT.Core.Extensions;
using IVolt.Kinguin.API.DB;
using IVolt.Kinguin.API.Security;
using System.Collections.Concurrent;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace IVolt.Kinguin.API.Local
{

    /// <summary>
    /// Defines the <see cref="JSON_File_Importer" />.
    /// </summary>
    public static partial class JSON_File_Importer
    {
        public static void LoadImages()
        {
            ConcurrentBag<DatabaseMetaData_Struct> _ImgDataStruct = new ConcurrentBag<DatabaseMetaData_Struct>();

            Parallel.ForEach(KinguinProductRefs, Prod =>
            {
                if (Prod.Images != null)
                {
                    // Add All Screenshots
                    foreach (var ImgScreenShot in Prod.Images.Screenshots)
                    {
                        _ImgDataStruct.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "ScreenShot_Images",
                            KProductID = Prod.ProductId,
                            V1 = ImgScreenShot.Url,
                            V2 = ImgScreenShot.Thumbnail,
                            i1 = 1,
                            FilePath = Prod.JSONFileName
                        });
                    }
                    if (Prod.Images.Cover != null)
                    {
                        _ImgDataStruct.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "ScreenShot_CoverImages",
                            KProductID = Prod.ProductId,
                            V1 = Prod.Images.Cover.Url,
                            V2 = Prod.Images.Cover.Thumbnail,
                            i1 = 2,
                            FilePath = Prod.JSONFileName
                        });
                    }
                }
            });

            #region Add / INSERT ALL INTO DATABASE
            using (var bcp1 = new SqlBulkCopy(FileSecurity.KinguinDatabase_ConnectionString_Protected))
            using (var reader1 = FastMember.ObjectReader.Create(_ImgDataStruct.ToList()))
            {
                bcp1.ColumnMappings.Add("i1", "Image_Type_ID");
                bcp1.ColumnMappings.Add("V1", "url");
                bcp1.ColumnMappings.Add("KProductID", "Kinguin_ProductID");
                bcp1.DestinationTableName = "Images";
                bcp1.WriteToServer(reader1);
            }

            #endregion
        }

        public static async Task<int> SaveImagesToDatabase()
        {
            var _AllImages = LocalDB.PROC.IMAGES.GET.IMAGES.TO.DOWNLOAD.Execute.Proc();
            System.Data.DataTable _ResultsData = _AllImages.FirstDataTable_WithRows();
            if (_ResultsData == null) { return -1; }
            ConcurrentBag<string> _Errors = new ConcurrentBag<string>();
            ConcurrentBag<string> _SuccessFiles = new ConcurrentBag<string>();
            Parallel.ForEach(_ResultsData.AsEnumerable(), async dr =>
            {
                if (dr["URL"] == null || dr["Kinguin_ProductID"] == null) { return; }

                var _Results = await DownloadImageAndSaveToDisk((string)dr["URL"], (string)dr["Kinguin_ProductID"]);

                if (_Results == false)
                {
                    _Errors.Add("Unable To Download: " + (string)dr["URL"] + ", " + (string)dr["Kinguin_ProductID"]);
                    return;
                }
                _SuccessFiles.Add((string)dr["URL"] + (string)dr["Kinguin_ProductID"]);
            });

            string _FileName = FileSecurity.Kinguin_ImageDownloadPath + "\\_errorlog.txt";
            StringBuilder _B = new StringBuilder();

            foreach (string err in _Errors.ToList()) { _B.Append(err); }
            System.IO.File.WriteAllText(_FileName, _B.ToString());

            return _SuccessFiles.Count;

            #region Old Code
            //        }
            //        {
            //            Console.WriteLine("Starting Image Download..");

            //            var _ImagesToDownload = LocalDB.PROC.IMAGES.GET.IAMGES.TO.DOWNLOAD.Execute.Proc();
            //        var _Rows = _ImagesToDownload.FirstDataTable_WithRows();

            //            if (_Rows == null)
            //            {
            //                Console.WriteLine("No Images To Download Found..");
            //                return;
            //            }

            //    Console.WriteLine("Found " + _Rows.Rows.Count.ToString() + " Images To Download");

            //            ConcurrentDictionary<int, string> ImageIDAndURLConcurrent = new ConcurrentDictionary<int, string>();
            //    ConcurrentDictionary<int, byte[]> ImageByteData = new ConcurrentDictionary<int, byte[]>();
            //    List<ImageData_Struct> ImageDataStruct = new List<ImageData_Struct>();

            //    int _HiddenCount = 0;
            //    int _Count = 0;
            //            foreach (System.Data.DataRow Dr in _Rows.Rows)
            //            {
            //                ImageDataStruct.Add(new ImageData_Struct() { ImageID = Dr["ID"].ToInt(-1), KinguinProductID = Dr["Kinguin_ProductID"].ToString(), URL = Dr["URL"].ToString() });
            //            }

            //Console.WriteLine("Downloading " + _Count.ToString() + " Images.  Total Downloaded: " + _HiddenCount.ToString());

            //_Count = 0;
            //Parallel.ForEach(ImageDataStruct, ImgData =>
            //{
            //    HttpHelper.DownloadFileAsync(ImgData.URL, FileSecurity.Kinguin_ImageDownloadPath);
            //    ImageIDAndURLConcurrent.AddOrUpdate(ImgData.URL, )

            //    ImageByteData.AddOrUpdate(ImgData., _TmpData, (Dr[""], text) => _TmpData);
            //});

            //List<ImageData> _ImgData = new List<ImageData>();
            //foreach (int K in ImageIDAndURLConcurrent.Keys)
            //{
            //    _ImgData.Add(new ImageData()
            //    {
            //        ID = Guid.NewGuid(),
            //        ImageID = K,
            //        ImageURL = ImageIDAndURLConcurrent[K],
            //        ImagePNGBytes = ImageByteData[K]
            //    });
            //}
            //SaveImagesToDatabase(_ImgData);

            //ImageIDAndURLConcurrent.Clear();
            //ImageByteData.Clear();
            //_ImgData.Clear();

            //_Count = _Count + 1;
            #endregion
        }


        public class ImageData
        {
            public Guid ID { get; set; }
            public int ImageID { get; set; }
            public string ImageURL { get; set; }
            public byte[] ImagePNGBytes { get; set; }
        }

        /// <summary>
        /// Download Image to File Location (Kinguin_ImageDownloadPath)
        /// </summary>
        /// <param name="URL">Image URL</param>
        /// <returns>byte[]</returns>
        public static async Task<bool> DownloadImageAndSaveToDisk(string URL, string KinguinProductID)
        {
            try
            {
                string _Extension = URL.GetExtensionFromFileName();
                string _FileName = FileSecurity.Kinguin_ImageDownloadPath + "\\" + KinguinProductID + "." + _Extension;
                using (HttpClient client = new HttpClient())
                {
                    using (var response = client.GetByteArrayAsync(URL))
                    {
                        if (response.IsCompletedSuccessfully) { await HttpHelper.DownloadFileAsync(URL, _FileName); }
                    }
                }

                if (_FileName.ToLower().EndsWith(".png"))
                {
                    if (System.IO.File.Exists(_FileName)) { return true; }
                    else { return false; }
                }
                else
                {
                    using (Stream stream = new MemoryStream(System.IO.File.ReadAllBytes(_FileName)))
                    {
                        Bitmap bitmap;
                        bitmap = new Bitmap(stream);
                        using (var _tmpMemS = new MemoryStream())
                        {
                            bitmap.Save(_tmpMemS, ImageFormat.Png);

                            if (System.IO.File.Exists(_FileName)) { return true; }
                            else { return false; }
                        }
                    }
                }
            }
            catch
            {
                // TODO LOG ERROR
                Console.WriteLine("Error Downloading Image: [" + URL.TryToString("") + "] For: [" + KinguinProductID.TryToString("") + "]");
                return false;
            }
        }


        /// <summary>
        /// Download Image Into ByteArray
        /// </summary>
        /// <param name="URL">Image URL</param>
        /// <returns>byte[]</returns>
        public static byte[] DownloadImageFromUrl(string URL, string KinguinProductID)
        {

            try
            {
                string _Extension = URL.GetExtensionFromFileName();
                string _FileName = FileSecurity.Kinguin_ImageDownloadPath + "\\" + KinguinProductID + "." + _Extension;

                var _Results = HttpHelper.DownloadFileAsync(URL, _FileName);

                using (Stream stream = new MemoryStream(System.IO.File.ReadAllBytes(_FileName)))
                {
                    Bitmap bitmap;
                    bitmap = new Bitmap(stream);
                    using (var _tmpMemS = new MemoryStream())
                    {
                        bitmap.Save(_tmpMemS, ImageFormat.Png);
                        return _tmpMemS.ToArray();
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static class HttpHelper
        {
            private static readonly HttpClient _httpClient = new HttpClient();

            public static async Task<bool> DownloadFileAsync(string uri, string outputPath)
            {
                Uri uriResult;

                if (!Uri.TryCreate(uri, UriKind.Absolute, out uriResult))
                {
                    Console.WriteLine("URI is invalid."); return false;
                }

                if (!File.Exists(outputPath)) { Console.WriteLine("File not found." + outputPath); return false; }

                byte[] fileBytes = await _httpClient.GetByteArrayAsync(uri);
                File.WriteAllBytes(outputPath, fileBytes);
                return true;
            }
        }
    }
}
