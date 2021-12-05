namespace IVolt.Kinguin.API.Objects
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="Kinguin_Product" />.
    /// </summary>
    public partial class Kinguin_Product
    {
        /// <summary>
        /// Defines the _tmpErrorData.
        /// </summary>
        public static List<string> _tmpErrorData = new List<string>();

        /// <summary>
        /// The InsertJSON_Files.
        /// </summary>
        /// <param name="BaseFolder">The BaseFolder<see cref="string"/>.</param>
        public static void InsertJSON_Files(string BaseFolder)
        {
            foreach (string file in System.IO.Directory.GetFiles(BaseFolder))
            {
                if (file.EndsWith(".json") == false) { return; }

                try
                {
                    var _KinguinProductLoaded = Kinguin_Product.FromJson(file);

                    if (Convert.ToInt32(_KinguinProductLoaded.ProductId) < 1) { _tmpErrorData.Add(file); }
                }
                catch
                {
                    _tmpErrorData.Add(file);
                    continue;
                }
            }
        }

        /// <summary>
        /// The InsertIntoDatabase.
        /// </summary>
        /// <param name="ConnectionString">The ConnectionString<see cref="string"/>.</param>
        public void InsertIntoDatabase(string ConnectionString)
        {
            List<System.Data.SqlClient.SqlParameter> _Parameters = new List<System.Data.SqlClient.SqlParameter>();
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", this.ID));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@Name", this.Name));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@Description", this.Description));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@CoverImage", this.CoverImage));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@CoverImageOriginal", this.CoverImageOriginal));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@Platform", this.Platform));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReleaseDate", this.ReleaseDate));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@Qty", this.Qty));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@TextQty", this.TextQty));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@Price", this.Price));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsPreorder", this.IsPreorder));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@MetacriticScore", this.MetacriticScore));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@RegionalLimitations", this.RegionalLimitations));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@CoverImage", this.CoverImage));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@CoverImageOriginal", this.CoverImageOriginal));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@Platform", this.Platform));
            _Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReleaseDate", this.ReleaseDate));
        }
    }
}
