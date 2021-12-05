using ACT.Core.Extensions;
using IVolt.Kinguin.API.DB;
using IVolt.Kinguin.API.Objects;

namespace IVolt.Kinguin.API.Local
{

    /// <summary>
    /// Defines the <see cref="JSON_File_Importer" />.
    /// </summary>
    public static partial class JSON_File_Importer
    {

        /// <summary>
        /// Loads Data using Parallel Threading
        /// KinguinProductRefs, AllMetaData and _AllOffers, Variables
        /// </summary>
        /// <param name="ImportFiles">List of JSON Files to Import</param>
        internal static void QuickLoadData(List<string> ImportFiles)
        {
            if (_ImportedFiles.Count == 0)
            {
                // Load All Files That Are In the Import Log
                var _ImportLogData = LocalDB.GET.ALL.IMPORTLOG.ENTRIES.Execute.Proc().FirstDataTable_WithRows();
                if (_ImportLogData != null)
                {
                    foreach (System.Data.DataRow dr in _ImportLogData.Rows)
                    {
                        DateTime? _DateUpdated = (DateTime?)dr["DateModified"];
                        if (_DateUpdated != null)
                        {
                            _ImportedFiles.Add(dr["JSON_FileName"].ToString(), _DateUpdated.Value);
                        }
                    }
                }
            }

            _AllMetaData.Clear();

            Parallel.ForEach(ImportFiles, FileName =>
            {
                var _LoadedKinguinProduct = Kinguin_Product.FromJson(FileName.ReadAllText());

                if (_ImportedFiles.ContainsKey(FileName))
                {
                    if (_LoadedKinguinProduct.UpdatedAt != null)
                    {
                        if (_ImportedFiles[FileName].ToDateTime() == _LoadedKinguinProduct.UpdatedAt.Value)
                        {
                            return;
                        }
                    }
                }

                _LoadedKinguinProduct.JSONFileName = FileName;

                KinguinProductRefs.Add(_LoadedKinguinProduct);

                if (_LoadedKinguinProduct.Publishers != null)
                {
                    foreach (var Pub in _LoadedKinguinProduct.Publishers)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Publishers",
                            V1 = Pub,
                            KProductID = _LoadedKinguinProduct.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (_LoadedKinguinProduct.Developers != null)
                {
                    foreach (var Dev in _LoadedKinguinProduct.Developers)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Developers",
                            V1 = Dev,
                            KProductID = _LoadedKinguinProduct.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (_LoadedKinguinProduct.Genres != null)
                {
                    foreach (var Gen in _LoadedKinguinProduct.Genres)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Genres",
                            V1 = Gen,
                            KProductID = _LoadedKinguinProduct.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (_LoadedKinguinProduct.Languages != null)
                {
                    foreach (var Lan in _LoadedKinguinProduct.Languages)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Languages",
                            V1 = Lan,
                            KProductID = _LoadedKinguinProduct.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (_LoadedKinguinProduct.Tags != null)
                {
                    foreach (var Tag in _LoadedKinguinProduct.Tags)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Tags",
                            V1 = Tag,
                            KProductID = _LoadedKinguinProduct.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (_LoadedKinguinProduct.MerchantName != null)
                {
                    foreach (var Mer in _LoadedKinguinProduct.MerchantName)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "MerchantName",
                            V1 = Mer,
                            KProductID = _LoadedKinguinProduct.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (_LoadedKinguinProduct.CheapestOfferId != null)
                {
                    foreach (var Off in _LoadedKinguinProduct.CheapestOfferId)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "CheapestOfferId",
                            V1 = Off,
                            V2 = _LoadedKinguinProduct.ProductId,
                            KProductID = _LoadedKinguinProduct.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (_LoadedKinguinProduct.Screenshots != null)
                {
                    foreach (var Sh in _LoadedKinguinProduct.Screenshots)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Screenshots",
                            V1 = Sh.Url,
                            V2 = Sh.UrlOriginal,
                            KProductID = _LoadedKinguinProduct.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (_LoadedKinguinProduct.Videos != null)
                {
                    foreach (var Vid in _LoadedKinguinProduct.Videos)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Videos",
                            V1 = Vid.ID,
                            V2 = Vid.Name,
                            KProductID = _LoadedKinguinProduct.ProductId,
                            FilePath = FileName
                        });
                    }
                }

                if (_LoadedKinguinProduct.SystemRequirements != null)
                {
                    foreach (var ReqS in _LoadedKinguinProduct.SystemRequirements)
                    {
                        if (ReqS.System != null)
                        {
                            _AllMetaData.Add(new DatabaseMetaData_Struct()
                            {
                                TableName = "Systems",
                                V1 = ReqS.System,
                                KProductID = _LoadedKinguinProduct.ProductId,
                                FilePath = FileName
                            });
                        }

                        foreach (var Req in ReqS.Requirements)
                        {
                            _AllMetaData.Add(new DatabaseMetaData_Struct()
                            {
                                TableName = "Requirements",
                                V1 = Req,
                                V2 = ReqS.System,
                                KProductID = _LoadedKinguinProduct.ProductId,
                                FilePath = FileName
                            });
                        }
                    }
                }

                if (_LoadedKinguinProduct.Offers != null)
                {
                    // Only MerchantName and OfferID
                    foreach (var Offer in _LoadedKinguinProduct.Offers)
                    {
                        _AllMetaData.Add(new DatabaseMetaData_Struct()
                        {
                            TableName = "Offers",
                            V1 = Offer.MerchantName,
                            V2 = Offer.ID,
                            KProductID = _LoadedKinguinProduct.ProductId,
                            FilePath = FileName
                        });
                        _AllOffers.Add(Offer);
                    }
                }
            });

        }
    }
}
