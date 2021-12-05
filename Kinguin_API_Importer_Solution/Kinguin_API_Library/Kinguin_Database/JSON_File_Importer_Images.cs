using ACT.Core.Extensions;
using IVolt.Kinguin.API.DB;
using IVolt.Kinguin.API.Security;
using System.Collections.Concurrent;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;

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
            ConcurrentBag<DatabaseMetaData_Struct> _ImgCoverDataStruct = new ConcurrentBag<DatabaseMetaData_Struct>();

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
                bcp1.ColumnMappings.Add("ImageType", "i1");
                bcp1.ColumnMappings.Add("url", "V1");
                bcp1.DestinationTableName = "Images";
                bcp1.WriteToServer(reader1);
            }

            #endregion
        }

        public static void DownloadAllImages()
        {
            var _ImagesToDownload = LocalDB.PROC.IMAGES.GET.IAMGES.TO.DOWNLOAD.Execute.Proc();
            var _Rows = _ImagesToDownload.FirstDataTable_WithRows();

            if (_Rows == null) { return; }

            ConcurrentDictionary<int, string> ImageIDAndURLConcurrent = new ConcurrentDictionary<int, string>();
            ConcurrentDictionary<int, byte[]> ImageByteData = new ConcurrentDictionary<int, byte[]>();

            int _Count = 0;
            foreach (System.Data.DataRow Dr in _Rows.Rows)
            {
                ImageIDAndURLConcurrent.AddOrUpdate(Dr["ID"].ToInt(-1), Dr["url"].ToString(), (id, text) => Dr["url"].ToString());

                if (_Count == 300)
                {
                    _Count = 0;
                    Parallel.ForEach(ImageIDAndURLConcurrent, ImgData =>
                    {
                        byte[] _TmpData = DownloadImageFromUrl(ImgData.Value);
                        if (_TmpData != null) { ImageByteData.AddOrUpdate(ImgData.Key, _TmpData, (id, text) => _TmpData); }
                    });

                    List<ImageData> _ImgData = new List<ImageData>();
                    foreach (int K in ImageIDAndURLConcurrent.Keys)
                    {
                        _ImgData.Add(new ImageData()
                        {
                            ID = Guid.NewGuid(),
                            ImageID = K,
                            ImageURL = ImageIDAndURLConcurrent[K],
                            ImagePNGBytes = ImageByteData[K]
                        });
                    }
                    SaveImagesToDatabase(_ImgData);

                    ImageIDAndURLConcurrent.Clear();
                    ImageByteData.Clear();
                    _ImgData.Clear();
                }
                _Count = _Count + 1;
            }
        }

        private class ImageData
        {
            public Guid ID { get; set; }
            public int ImageID { get; set; }
            public string ImageURL { get; set; }
            public byte[] ImagePNGBytes { get; set; }
        }

        private static void SaveImagesToDatabase(List<ImageData> ImgData)
        {
            #region Add / INSERT ALL META DATA INTO DATABASE         
            using (var bcp = new SqlBulkCopy(FileSecurity.KinguinDatabase_ConnectionString_Protected))
            using (var reader = FastMember.ObjectReader.Create(ImgData))
            {
                bcp.DestinationTableName = "Images_LoadingData";
                bcp.WriteToServer(reader);
            }
            #endregion
        }

        /// <summary>
        /// Download Image Into ByteArray
        /// </summary>
        /// <param name="URL">Image URL</param>
        /// <returns>byte[]</returns>
        public static byte[] DownloadImageFromUrl(string URL)
        {
            //TEMP
            return null;

            byte[] _tmpReturn = null;
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (Stream stream = client.OpenRead(URL))
                    {
                        Bitmap bitmap;
                        bitmap = new Bitmap(stream);
                        using (var _tmpMemS = new MemoryStream())
                        {
                            bitmap.Save(_tmpMemS, ImageFormat.Png);
                            _tmpReturn = _tmpMemS.ToArray();
                        }
                    }
                }
            }
            catch
            {
                return null;
            }

            return _tmpReturn;
        }
    }
}
