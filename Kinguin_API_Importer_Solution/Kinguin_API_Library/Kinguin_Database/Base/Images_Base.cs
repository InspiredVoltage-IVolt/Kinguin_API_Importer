namespace IVolt.Kinguin.API.LocalDB
{
    using ACT.Core.Extensions.CodeGenerator;
    using ACT.Core.Interfaces.DataAccess;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines the <see cref="Images_CoreClass" />.
    /// </summary>
    public class Images_CoreClass : ACT.Plugins.ACT_Core, ACT.Core.Interfaces.DataAccess.I_DataObject
    {
        /// <summary>
        /// Defines the _LocalConnectionString.
        /// </summary>
        private string _LocalConnectionString = "";

        /// <summary>
        /// Defines the __ID.
        /// </summary>
        private int? __ID;

        /// <summary>
        /// Defines the __ID_Description.
        /// </summary>
        private string __ID_Description = "";

        /// <summary>
        /// Defines the __Image_Type_ID.
        /// </summary>
        private int? __Image_Type_ID;

        /// <summary>
        /// Defines the __Image_Type_ID_Description.
        /// </summary>
        private string __Image_Type_ID_Description = "";

        /// <summary>
        /// Defines the __url.
        /// </summary>
        private string __url;

        /// <summary>
        /// Defines the __url_Description.
        /// </summary>
        private string __url_Description = "";

      

        private byte[] __imagebytes = null;

        private string __imagebytes_Description = null;

        /// <summary>
        /// Defines the __DateAdded.
        /// </summary>
        private DateTime? __DateAdded;

        /// <summary>
        /// Defines the __DateAdded_Description.
        /// </summary>
        private string __DateAdded_Description = "";

        /// <summary>
        /// Defines the __DateModified.
        /// </summary>
        private DateTime? __DateModified;

        /// <summary>
        /// Defines the __DateModified_Description.
        /// </summary>
        private string __DateModified_Description = "";

        /// <summary>
        /// Gets or sets the LocalConnectionString.
        /// </summary>
        public virtual string LocalConnectionString
        {
            get { return _LocalConnectionString; }
            set { _LocalConnectionString = value; }
        }

        /// <summary>
        /// Gets the PrimaryKey.
        /// </summary>
        public virtual string PrimaryKey
        {
            get { return "ID"; }
        }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public virtual int? ID
        {
            get { return __ID; }
            set { __ID = value; }
        }

        /// <summary>
        /// Gets or sets the ID_Description.
        /// </summary>
        public virtual string ID_Description
        {
            get { return __ID_Description; }
            set { __ID_Description = value; }
        }

        /// <summary>
        /// Gets or sets the Image_Type_ID.
        /// </summary>
        public virtual int? Image_Type_ID
        {
            get { return __Image_Type_ID; }
            set { __Image_Type_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Image_Type_ID_Description.
        /// </summary>
        public virtual string Image_Type_ID_Description
        {
            get { return __Image_Type_ID_Description; }
            set { __Image_Type_ID_Description = value; }
        }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public virtual string url
        {
            get { return __url; }
            set { __url = value; }
        }

        /// <summary>
        /// Gets or sets the url_Description.
        /// </summary>
        public virtual string url_Description
        {
            get { return __url_Description; }
            set { __url_Description = value; }
        }

        


        /// <summary>
        /// Gets or sets the thumbnail.
        /// </summary>
        public virtual byte[]? imagebytes
        {
            get { return __imagebytes; }
            set { __imagebytes = value; }
        }

        /// <summary>
        /// Gets or sets the thumbnail_Description.
        /// </summary>
        public virtual string imagebytes_Description
        {
            get { return imagebytes_Description; }
            set { imagebytes_Description = value; }
        }
        /// <summary>
        /// Gets or sets the DateAdded.
        /// </summary>
        public virtual DateTime? DateAdded
        {
            get { return __DateAdded; }
            set { __DateAdded = value; }
        }

        /// <summary>
        /// Gets or sets the DateAdded_Description.
        /// </summary>
        public virtual string DateAdded_Description
        {
            get { return __DateAdded_Description; }
            set { __DateAdded_Description = value; }
        }

        /// <summary>
        /// Gets or sets the DateModified.
        /// </summary>
        public virtual DateTime? DateModified
        {
            get { return __DateModified; }
            set { __DateModified = value; }
        }

        /// <summary>
        /// Gets or sets the DateModified_Description.
        /// </summary>
        public virtual string DateModified_Description
        {
            get { return __DateModified_Description; }
            set { __DateModified_Description = value; }
        }

        /// <summary>
        /// The GetDataAccess.
        /// </summary>
        /// <returns>The <see cref="ACT.Core.Interfaces.DataAccess.I_DataAccess"/>.</returns>
        public static ACT.Core.Interfaces.DataAccess.I_DataAccess GetDataAccess()
        {
            using (var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent())
            {
                DataAccess.Open(GenericStaticClass.DatabaseConnectionString);

                return DataAccess;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Images_CoreClass"/> class.
        /// </summary>
        /// <param name="localConnectionString">The localConnectionString<see cref="string"/>.</param>
        public Images_CoreClass(string localConnectionString = "")
        {
            LocalConnectionString = localConnectionString;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Images_CoreClass"/> class.
        /// </summary>
        /// <param name="ID">The ID<see cref="int?"/>.</param>
        /// <param name="localConnectionString">The localConnectionString<see cref="string"/>.</param>
        public Images_CoreClass(int? ID, string localConnectionString = "")
        {
            using (var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent())
            {
                if (localConnectionString == "")
                {

                    DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
                }
                else
                {
                    LocalConnectionString = localConnectionString;
                    DataAccess.Open(localConnectionString);
                }

                List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
                _Params.Add(new System.Data.SqlClient.SqlParameter("IDParam", ID));
                var SQL = "Select * From Images Where [ID] = @IDParam";

                var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);

                if (Result.Tables[0].Rows.Count == 1)
                {
                    for (int x = 0; x < Result.Tables[0].Columns.Count; x++)
                    {
                        if (Result.Tables[0].Rows[0][x] != DBNull.Value)
                        {
                            this.SetProperty(Result.Tables[0].Columns[x].ColumnName.ToCSharpFriendlyName(), Result.Tables[0].Rows[0][x]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// The GetImages.
        /// </summary>
        /// <param name="Where">The Where<see cref="I_DbWhereStatement"/>.</param>
        /// <param name="sql">The sql<see cref="string"/>.</param>
        /// <param name="LocalConnectionString">The LocalConnectionString<see cref="string"/>.</param>
        /// <returns>The <see cref="List{Images}"/>.</returns>
        public static List<Images> GetImages(I_DbWhereStatement Where, string sql = "", string LocalConnectionString = "")
        {
            List<Images> _TmpReturn = new List<Images>();
            using (var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent())
            {
                if (LocalConnectionString == "")
                {

                    DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
                }

                else
                {

                    DataAccess.Open(LocalConnectionString);
                }

                string _Where = DataAccess.GenerateWhereStatement(Where, sql);
                var _Params = DataAccess.GenerateWhereStatementParameters(Where);
                var QR = DataAccess.RunCommand("Select [ID] From Images Where " + _Where, _Params, true, System.Data.CommandType.Text);
                if (QR.Tables[0].Rows.Count > 0)
                {
                    foreach (System.Data.DataRow r in QR.Tables[0].Rows)
                    {
                        _TmpReturn.Add(new Images((int?)r["ID"]));
                    }
                }
                return _TmpReturn;
            }
        }

        /// <summary>
        /// The Search.
        /// </summary>
        /// <param name="FieldName">The FieldName<see cref="string"/>.</param>
        /// <param name="SearchText">The SearchText<see cref="string"/>.</param>
        /// <param name="UseContains">The UseContains<see cref="bool"/>.</param>
        /// <param name="LocalConnectionString">The LocalConnectionString<see cref="string"/>.</param>
        /// <returns>The <see cref="List{Images}"/>.</returns>
        public static List<Images> Search(string FieldName, string SearchText, bool UseContains = false, string LocalConnectionString = "")
        {
            List<Images> _TmpReturn = new List<Images>();
            using (var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent())
            {

                if (LocalConnectionString == "")
                {

                    DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
                }

                else
                {

                    DataAccess.Open(LocalConnectionString);
                }

                List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
                _Params.Add(new System.Data.SqlClient.SqlParameter("SearchParam", SearchText));
                var SQL = "";
                if (UseContains == true)
                {
                    SQL = SQL + "Select Images.ID From Images Where [" + FieldName + "] like '%' + @SearchParam + '%'";
                }
                else
                {
                    SQL = SQL + "Select Images.ID From Images Where [" + FieldName + "] = @SearchParam";
                }

                var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
                if (Result.Tables[0].Rows.Count > 0)
                {
                    for (int x = 0; x < Result.Tables[0].Rows.Count; x++)
                    {
                        if (Result.Tables[0].Rows[x][0] != DBNull.Value)
                        {
                            _TmpReturn.Add(new Images((int)Result.Tables[0].Rows[x]["ID"]));
                        }
                    }
                }
            }
            return _TmpReturn;
        }

        /// <summary>
        /// The Search.
        /// </summary>
        /// <param name="FieldName">The FieldName<see cref="string"/>.</param>
        /// <param name="SearchText">The SearchText<see cref="string"/>.</param>
        /// <param name="OrderByStatement">The OrderByStatement<see cref="string"/>.</param>
        /// <param name="Start">The Start<see cref="int"/>.</param>
        /// <param name="Increment">The Increment<see cref="int"/>.</param>
        /// <param name="UseContains">The UseContains<see cref="bool"/>.</param>
        /// <param name="LocalConnectionString">The LocalConnectionString<see cref="string"/>.</param>
        /// <returns>The <see cref="System.Data.DataTable"/>.</returns>
        public static System.Data.DataTable Search(string FieldName, string SearchText, string OrderByStatement, int Start, int Increment, bool UseContains = false, string LocalConnectionString = "")
        {
            using (var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent())
            {
                if (LocalConnectionString == "")
                {

                    DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
                }

                else
                {

                    DataAccess.Open(LocalConnectionString);
                }

                List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
                _Params.Add(new System.Data.SqlClient.SqlParameter("SearchParam", SearchText));
                var SQL = "";
                if (UseContains == true)
                {
                    SQL = SQL + "Select * From ( Select *, ROW_NUMBER() Over(order by " + OrderByStatement + ") as RowNum From Images Where [" + FieldName + "] like '%' + @SearchParam + '%') as T Where T.RowNum > " + (Start - 1).ToString() + " AND T.RowNum < " + (Start + Increment).ToString();
                }
                else
                {
                    SQL = SQL + "Select * From ( Select *, ROW_NUMBER() Over(order by " + OrderByStatement + ") as RowNum From Images Where [" + FieldName + "] = @SearchParam) as T Where T.RowNum > " + (Start - 1).ToString() + " AND T.RowNum < " + (Start + Increment).ToString();
                }

                var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
                return Result.Tables[0];
            }
        }

        /// <summary>
        /// The Search.
        /// </summary>
        /// <param name="FieldValues">The FieldValues<see cref="Dictionary{string,string}"/>.</param>
        /// <param name="LocalConnectionString">The LocalConnectionString<see cref="string"/>.</param>
        /// <returns>The <see cref="List{Images}"/>.</returns>
        public static List<Images> Search(Dictionary<string, string> FieldValues, string LocalConnectionString = "")
        {
            List<Images> _TmpReturn = new List<Images>();
            using (var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent())
            {

                if (LocalConnectionString == "")
                {

                    DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
                }

                else
                {

                    DataAccess.Open(LocalConnectionString);
                }

                List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
                foreach (var skey in FieldValues.Keys)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter(skey, FieldValues[skey]));
                }
                var SQL = "";
                SQL = SQL + "Select Images.ID From Images where ";
                foreach (var skey in FieldValues.Keys)
                {
                    SQL = SQL + "[" + skey + "] = @" + skey + " AND ";
                }
                SQL = SQL.Substring(0, SQL.LastIndexOf("AND"));


                var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
                if (Result.Tables[0].Rows.Count > 0)
                {
                    for (int x = 0; x < Result.Tables[0].Rows.Count; x++)
                    {
                        if (Result.Tables[0].Rows[x][0] != DBNull.Value)
                        {
                            _TmpReturn.Add(new Images((int)Result.Tables[0].Rows[x]["ID"]));
                        }
                    }
                }
            }
            return _TmpReturn;
        }

        /// <summary>
        /// The Search.
        /// </summary>
        /// <param name="FieldName">The FieldName<see cref="string"/>.</param>
        /// <param name="SearchText">The SearchText<see cref="string"/>.</param>
        /// <param name="OrderByStatement">The OrderByStatement<see cref="string"/>.</param>
        /// <param name="UseContains">The UseContains<see cref="bool"/>.</param>
        /// <param name="LocalConnectionString">The LocalConnectionString<see cref="string"/>.</param>
        /// <returns>The <see cref="System.Data.DataTable"/>.</returns>
        public static System.Data.DataTable Search(string FieldName, string SearchText, string OrderByStatement, bool UseContains = false, string LocalConnectionString = "")
        {
            using (var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent())
            {
                if (LocalConnectionString == "")
                {

                    DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
                }

                else
                {

                    DataAccess.Open(LocalConnectionString);
                }

                List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
                _Params.Add(new System.Data.SqlClient.SqlParameter("SearchParam", SearchText));
                var SQL = "";
                if (UseContains == true)
                {
                    SQL = SQL + "Select * From Images Where [" + FieldName + "] like '%' + @SearchParam + '%'";
                }
                else
                {
                    SQL = SQL + "Select * From Images Where [" + FieldName + "] = @SearchParam";
                }

                var Result = DataAccess.RunCommand(SQL, _Params.ToList<System.Data.IDataParameter>(), true, System.Data.CommandType.Text);
                return Result.Tables[0];
            }
        }

        /// <summary>
        /// The Export.
        /// </summary>
        /// <param name="Format">The Format<see cref="string"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string Export(string Format)
        {
            if (Format.ToLower() == "xml")
            {
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(this.GetType());
                System.IO.StringWriter _Output = new System.IO.StringWriter();
                x.Serialize(_Output, this);
                return _Output.ToString();
            }
            else if (Format.ToLower() == "json")
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
            }

            return "";
        }

        /// <summary>
        /// The Create.
        /// </summary>
        /// <returns>The <see cref="I_QueryResult"/>.</returns>
        public virtual I_QueryResult Create()
        {
            using (var DataAccess = new ACT.Plugins.DataAccess.ACT_MSSQL())// ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent())
            {
                if (LocalConnectionString == "")
                {

                    DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
                }

                else
                {

                    DataAccess.Open(LocalConnectionString);
                }


                List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
                string SQLInsertFields = "";
                string SQLValues = "";
                if (this.ID != null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("ID_Param", this.ID));
                    SQLInsertFields += "[ID], ";
                    SQLValues += "@ID_Param, ";
                }
                if (this.Image_Type_ID != null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("Image_Type_ID_Param", this.Image_Type_ID));
                    SQLInsertFields += "[Image_Type_ID], ";
                    SQLValues += "@Image_Type_ID_Param, ";
                }
                if (this.url != null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("url_Param", this.url));
                    SQLInsertFields += "[url], ";
                    SQLValues += "@url_Param, ";
                }

                if (this.imagebytes != null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("imagebytes_Param", this.imagebytes));
                    SQLInsertFields += "[imagebytes], ";
                    SQLValues += "@imagebytes_Param, ";
                }
                if (this.DateAdded != null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("DateAdded_Param", this.DateAdded));
                    SQLInsertFields += "[DateAdded], ";
                    SQLValues += "@DateAdded_Param, ";
                }
                if (this.DateModified != null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("DateModified_Param", this.DateModified));
                    SQLInsertFields += "[DateModified], ";
                    SQLValues += "@DateModified_Param, ";
                }
                SQLInsertFields = SQLInsertFields.TrimEnd(", ".ToCharArray());
                SQLValues = SQLValues.TrimEnd(", ".ToCharArray());
                string _SQL = "Insert Into [Images] ( " + SQLInsertFields + ") Values (" + SQLValues + ")";
                var _TmpReturn = DataAccess.RunCommand(_SQL, _Params.ToList<System.Data.IDataParameter>(), false, System.Data.CommandType.Text);


                return _TmpReturn;
            }
        }

        /// <summary>
        /// The Update.
        /// </summary>
        /// <returns>The <see cref="I_QueryResult"/>.</returns>
        public virtual I_QueryResult Update()
        {
            using (var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent())
            {
                if (LocalConnectionString == "")
                {

                    DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
                }

                else
                {

                    DataAccess.Open(LocalConnectionString);
                }


                List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
                string SQLInsertFields = "";
                string SQLValues = "";
                if (this.ID != null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("ID_Param", this.ID));
                    SQLValues += "[ID] = @ID_Param AND ";
                }
                if (this.Image_Type_ID != null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("Image_Type_ID_Param", this.Image_Type_ID));
                    SQLInsertFields += "[Image_Type_ID] = @Image_Type_ID_Param, ";
                }
                if (this.url != null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("url_Param", this.url));
                    SQLInsertFields += "[url] = @url_Param, ";
                }
               
                if (this.imagebytes != null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("imagebytes_Param", this.imagebytes));
                    SQLInsertFields += "[imagebytes] = @imagebytes_Param, ";
                }
                if (this.DateAdded != null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("DateAdded_Param", this.DateAdded));
                    SQLInsertFields += "[DateAdded] = @DateAdded_Param, ";
                }
                if (this.DateModified != null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("DateModified_Param", DateTime.Now));
                    SQLInsertFields += "[DateModified] = @DateModified_Param, ";
                }
                SQLInsertFields = SQLInsertFields.TrimEnd(", ".ToCharArray());
                SQLValues = SQLValues.TrimEnd("AND ".ToCharArray());
                string _SQL = "Update [Images] set " + SQLInsertFields + " Where " + SQLValues;
                var _TmpReturn = DataAccess.RunCommand(_SQL, _Params.ToList<System.Data.IDataParameter>(), false, System.Data.CommandType.Text);


                return _TmpReturn;
            }
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        public virtual void Delete()
        {
            using (var DataAccess = ACT.Core.CurrentCore<ACT.Core.Interfaces.DataAccess.I_DataAccess>.GetCurrent())
            {
                if (LocalConnectionString == "")
                {

                    DataAccess.Open(GenericStaticClass.DatabaseConnectionString);
                }

                else
                {

                    DataAccess.Open(LocalConnectionString);
                }


                List<System.Data.SqlClient.SqlParameter> _Params = new List<System.Data.SqlClient.SqlParameter>();
                string SQLValues = "";
                if (this.ID != null)
                {
                    _Params.Add(new System.Data.SqlClient.SqlParameter("ID_Param", this.ID));
                    SQLValues += "[ID] = @ID_Param AND ";
                }
                if (this.Image_Type_ID != null)
                {
                }
                if (this.url != null)
                {
                }
               
                if (this.imagebytes != null)
                {
                }
                if (this.DateAdded != null)
                {
                }
                if (this.DateModified != null)
                {
                }
                SQLValues = SQLValues.TrimEnd("AND ".ToCharArray());
                string _SQL = "Delete From [Images] Where " + SQLValues;
                DataAccess.RunCommand(_SQL, _Params.ToList<System.Data.IDataParameter>(), false, System.Data.CommandType.Text);
            }
        }
    }
}
