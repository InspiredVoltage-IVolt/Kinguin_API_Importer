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
        /// <summary>
        /// Loads Data using Parallel Threading
        /// </summary>
        /// <param name="ImportFiles"></param>
        internal static void QuickLoadData(List<string> ImportFiles)
        {
            _AllMetaData.Clear();

            Parallel.ForEach(ImportFiles, FileName =>
            {
                var P = Kinguin_Product.FromJson(FileName.ReadAllText());
                P.JSONFileName = FileName;
                KinguinProductRefs.Add(P);

                if (P.Publishers != null)
                {
                    foreach (var Pub in P.Publishers)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Publishers",
                            V1 = Pub,
                            KProductID = P.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (P.Developers != null)
                {
                    foreach (var Dev in P.Developers)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Developers",
                            V1 = Dev,
                            KProductID = P.ProductId,
                            FilePath = FileName           
                        });
                    }
                }

                if (P.Genres != null)
                {
                    foreach (var Gen in P.Genres)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Genres",
                            V1 = Gen,
                            KProductID = P.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (P.Languages != null)
                {
                    foreach (var Lan in P.Languages)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Languages",
                            V1 = Lan,
                            KProductID = P.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (P.Tags != null)
                {
                    foreach (var Tag in P.Tags)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Tags",
                            V1 = Tag,
                            KProductID = P.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (P.MerchantName != null)
                {
                    foreach (var Mer in P.MerchantName)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "MerchantName",
                            V1 = Mer,
                            KProductID = P.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (P.CheapestOfferId != null)
                {
                    foreach (var Off in P.CheapestOfferId)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "CheapestOfferId",
                            V1 = Off,
                            V2 = P.ProductId,
                            KProductID = P.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (P.Screenshots != null)
                {
                    foreach (var Sh in P.Screenshots)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Screenshots",
                            V1 = Sh.Url,
                            V2 = Sh.UrlOriginal,
                            KProductID = P.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (P.Videos != null)
                {
                    foreach (var Vid in P.Videos)
                    {                       
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Videos",
                            V1 = Vid.ID,
                            V2 = Vid.Name,
                            KProductID = P.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (P.SystemRequirements != null)
                {
                    foreach (var ReqS in P.SystemRequirements)
                    {
                        if (ReqS.System != null)
                            _AllMetaData.Add(new DatabaseMetaData_Struct()
                            {
                                TableName = "Systems",
                                V1 = ReqS.System,
                                KProductID = P.ProductId,
                                FilePath = FileName
                            });


                        foreach (var Req in ReqS.Requirements)
                        {
                            _AllMetaData.Add(new DatabaseMetaData_Struct()
                            {
                                TableName = "Requirements",
                                V1 = Req,
                                V2 = ReqS.System,
                                KProductID = P.ProductId,
                                FilePath = FileName
                            });
                        }
                    }
                }

                if (P.Offers != null)
                {
                    // Only Merchant Name
                    foreach (var Offer in P.Offers)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Offers",
                            V1 = Offer.MerchantName,
                            V2 = Offer.ID,
                            KProductID = P.ProductId,
                            FilePath = FileName
                        });
                        _AllOffers.Add(Offer);
                    }
                }                
            });

            LoadImages();
        }
    }
}
