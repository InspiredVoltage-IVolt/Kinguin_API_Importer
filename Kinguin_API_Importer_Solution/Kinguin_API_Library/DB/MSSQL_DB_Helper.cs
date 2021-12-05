namespace IVolt.Kinguin.API.DB
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="MSSQL_DB_Helper" />.
    /// </summary>
    public static class MSSQL_DB_Helper
    {
        /// <summary>
        /// Defines the _SQL_Exececution_Position.
        /// </summary>
        internal static int _SQL_Exececution_Position = 0;

        /// <summary>
        /// Defines the _TableCreate.
        /// </summary>
        internal static string _TableCreate = "CREATE TABLE [dbo].[###TABLE_NAME###](";

        /// <summary>
        /// Defines the _tmpGuid_Column_SQLTemplate.
        /// </summary>
        internal static string _tmpGuid_Column_SQLTemplate = "[###COLUMN_NAME###] [UNIQUEIDENTIFIER] ###CANBENULL###,";

        /// <summary>
        /// Defines the _tmpDateTime_Column_SQLTemplate.
        /// </summary>
        internal static string _tmpDateTime_Column_SQLTemplate = "[###COLUMN_NAME###] [DATETIME] NULL,";

        /// <summary>
        /// Defines the _tmpWholeNumber_Column_SQLTemplate.
        /// </summary>
        internal static string _tmpWholeNumber_Column_SQLTemplate = "[###COLUMN_NAME###] [INT] ###IDENTITY### ###CANBENULL###,";

        /// <summary>
        /// Defines the _tmpBoolean_Column_SQLTemplate.
        /// </summary>
        internal static string _tmpBoolean_Column_SQLTemplate = "[###COLUMN_NAME###] [BIT] NULL,";

        /// <summary>
        /// Defines the _tmpString_Column_SQLTemplate.
        /// </summary>
        internal static string _tmpString_Column_SQLTemplate = "[###COLUMN_NAME###] [NVARCHAR](MAX) NULL,";

        /// <summary>
        /// Defines the _tmpRealNumber_Column_SQLTemplate.
        /// </summary>
        internal static string _tmpRealNumber_Column_SQLTemplate = "[###COLUMN_NAME###] [DECIMAL](14, 4) NULL,";

        /// <summary>
        /// Defines the _tmpBinary_Column_SQLTemplate.
        /// </summary>
        internal static string _tmpBinary_Column_SQLTemplate = "[###COLUMN_NAME###] [[VARBINARY](MAX)] NULL,";

        /// <summary>
        /// Defines the _tmpTableGuid_PK_CONSTRAINT_SQLTemplate.
        /// </summary>
        internal static string _tmpTableGuid_PK_CONSTRAINT_SQLTemplate = "CONSTRAINT[PK_Guid_###TABLENAME###] PRIMARY KEY CLUSTERED ( [###PKFIELDNAME###] ASC ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY] ) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]";

        /// <summary>
        /// Defines the _tmpTableWholeNumber_PK_CONSTRAINT_SQLTemplate.
        /// </summary>
        internal static string _tmpTableWholeNumber_PK_CONSTRAINT_SQLTemplate = "CONSTRAINT [PK_Int_###TABLENAME###] PRIMARY KEY CLUSTERED ([###PKFIELDNAME###] ASC )WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]) ON[PRIMARY]";

        //static string _tmpRelationship_SQL_Template = @"ALTER TABLE [dbo].[###BASETABLENAME###]  WITH CHECK ADD  CONSTRAINT [FK_###BASETABLENAME###_###TABLENAME###_###COLUMNNAME###] FOREIGN KEY([###COLUMNNAME###]) REFERENCES [dbo].[###BASETABLENAME###] ([###BASETABLE_COLUMNNAME###]) ";
        // static string _tmpRelationship_SQL_Template = @"ALTER TABLE[dbo].[###BASETABLENAME###] ADD CONSTRAINT FK_###BASETABLENAME###_###TABLENAME###_###COLUMNNAME### FOREIGN KEY(###BASE_PRIMARYKEY_COLUMNNAME###) REFERENCES[dbo].[###TABLENAME###] (###COLUMNNAME###) ON DELETE CASCADE ON UPDATE CASCADE";
        /// <summary>
        /// Defines the _ReferencingTableData.
        /// </summary>
        internal static Dictionary<int, (string FieldName, string ParentName)> _ReferencingTableData = new Dictionary<int, (string, string)>();

        /// <summary>
        /// The CreateTablesSQL.
        /// </summary>
        /// <param name="T">The T<see cref="Type"/>.</param>
        /// <param name="ParentHashKey">The ParentHashKey<see cref="int"/>.</param>
        /// <param name="AssumePK">The AssumePK<see cref="string"/>.</param>
        /// <param name="DefaultNvarcharSize">The DefaultNvarcharSize<see cref="int"/>.</param>
        /// <returns>The <see cref="List{(string SqlStatement, int DependancyLevel)}"/>.</returns>
        public static List<(string SqlStatement, int DependancyLevel)> CreateTablesSQL(Type T, int ParentHashKey = 0, string AssumePK = "ID", int DefaultNvarcharSize = -1)
        {
            if (ParentHashKey == 0) { _SQL_Exececution_Position = 0; }

            List<(string SqlStatement, int DependancyLevel)> _tmpReturn = new List<(string SqlStatement, int DependancyLevel)>();

            bool IsFromParent = ParentHashKey > 0;
            string _tmpMainTable = _TableCreate;

            bool? _IsGuidID = null;
            string _TmpPK = "";
            List<string> RelationshipsToCreate = new List<string>();
            foreach (var Prop in (T).GetProperties())
            {
                Type _type = Prop.GetType();

                if (Prop.PropertyType == typeof(string))
                {
                    _tmpMainTable += _tmpString_Column_SQLTemplate.Replace("###COLUMN_NAME###", Prop.Name);
                }
                else if (Prop.PropertyType == typeof(int?) || Prop.PropertyType == typeof(long?) || Prop.PropertyType == typeof(int) || Prop.PropertyType == typeof(byte) || Prop.PropertyType == typeof(char) || Prop.PropertyType == typeof(long) || Prop.PropertyType == typeof(uint) || Prop.PropertyType == typeof(ulong) || Prop.PropertyType == typeof(short) || Prop.PropertyType == typeof(ushort))
                {
                    string _tI = _tmpWholeNumber_Column_SQLTemplate;

                    if (_IsGuidID == null && Prop.Name == AssumePK)
                    {
                        _TmpPK = Prop.Name; _IsGuidID = false; _tI = _tI.Replace("###CANBENULL###", "NOT NULL").Replace("###TABLENAME###", T.Name).Replace("###IDENTITY###", "IDENTITY(1,1)");
                    }
                    else { _tI = _tI.Replace("###CANBENULL###", "NULL").Replace("###IDENTITY###", ""); }

                    _tmpMainTable += _tI.Replace("###COLUMN_NAME###", Prop.Name);

                }
                else if (Prop.PropertyType == typeof(byte[]) || Prop.PropertyType == typeof(List<byte>))
                {
                    _tmpMainTable += _tmpBinary_Column_SQLTemplate.Replace("###COLUMN_NAME###", Prop.Name);
                }
                else if (Prop.PropertyType == typeof(float) || Prop.PropertyType == typeof(decimal) || Prop.PropertyType == typeof(double) ||
                    Prop.PropertyType == typeof(float?) || Prop.PropertyType == typeof(decimal?) || Prop.PropertyType == typeof(double?))
                {
                    _tmpMainTable += _tmpRealNumber_Column_SQLTemplate.Replace("###COLUMN_NAME###", Prop.Name);
                }
                else if (Prop.PropertyType == typeof(bool) || Prop.PropertyType == typeof(bool?))
                {
                    _tmpMainTable += _tmpBoolean_Column_SQLTemplate.Replace("###COLUMN_NAME###", Prop.Name);
                }
                else if (Prop.PropertyType == typeof(Guid))
                {
                    string _tI = _tmpGuid_Column_SQLTemplate;

                    if (_IsGuidID == null && Prop.Name == AssumePK) { _TmpPK = Prop.Name; _IsGuidID = true; _tI = _tI.Replace("###CANBENULL###", "NOT NULL").Replace("###TABLENAME###", T.Name); ; }
                    else { _tI = _tI.Replace("###CANBENULL###", "NULL"); }

                    _tmpMainTable += _tI.Replace("###COLUMN_NAME###", Prop.Name);
                }
                else if (Prop.PropertyType == typeof(DateTime) || Prop.PropertyType == typeof(DateTime?))
                {
                    _tmpMainTable += _tmpDateTime_Column_SQLTemplate.Replace("###COLUMN_NAME###", Prop.Name);
                }
                else if (Prop.PropertyType == typeof(List<string>))
                {
                    RelationshipsToCreate.Add(Prop.Name);
                }
                else if (Prop.PropertyType.IsGenericType)
                {
                    int _HashCode = 0;
                    if (ParentHashKey == 0) { _HashCode = (Prop.Name + (T).Name).GetHashCode(StringComparison.CurrentCulture); }
                    else { _HashCode = (_ReferencingTableData[ParentHashKey].Item2 + Prop.Name + (T).Name).GetHashCode(StringComparison.CurrentCulture); }

                    _ReferencingTableData.Add(_HashCode, (Prop.Name, (T).Name));

                    _tmpReturn.AddRange(CreateTablesSQL(Prop.PropertyType.GenericTypeArguments[0], _HashCode));
                }
                else if (Prop.GetType().IsClass)
                {
                    // CREATE RELATIONSHIP HERE AND RECURSIVELY CALL THIS METHOD.
                    _SQL_Exececution_Position = _SQL_Exececution_Position + 1;
                    int _HashCode = 0;
                    if (ParentHashKey == 0) { _HashCode = (Prop.Name + (T).Name).GetHashCode(StringComparison.CurrentCulture); }
                    else { _HashCode = (_ReferencingTableData[ParentHashKey].Item2 + Prop.Name + (T).Name).GetHashCode(StringComparison.CurrentCulture); }

                    _ReferencingTableData.Add(_HashCode, (Prop.Name, (T).Name));

                    _tmpReturn.AddRange(CreateTablesSQL(Prop.PropertyType, _HashCode));
                }
            }

            if (_IsGuidID != null)
            {
                if (_IsGuidID == false)
                {
                    _tmpMainTable = _tmpMainTable + _tmpTableWholeNumber_PK_CONSTRAINT_SQLTemplate.Replace("###PKFIELDNAME###", _TmpPK).Replace("###TABLENAME###", T.Name);
                }
                else
                {
                    _tmpMainTable = _tmpMainTable + _tmpTableGuid_PK_CONSTRAINT_SQLTemplate.Replace("###PKFIELDNAME###", _TmpPK).Replace("###TABLENAME###", T.Name);
                }

                if (RelationshipsToCreate.Count > 0)
                {
                    foreach (var _PropertyToCreateRelationshipWith in RelationshipsToCreate)
                    {
                        foreach (var ItemCreatedString in Create_LIST_String_LookupTable(T.Name, _PropertyToCreateRelationshipWith, _TmpPK))
                        {
                            _tmpReturn.Add(ItemCreatedString);
                        }
                    }
                }

                _tmpMainTable = _tmpMainTable.Replace("###TABLE_NAME###", T.Name);
                _tmpReturn.Add((_tmpMainTable, _SQL_Exececution_Position));

                if (IsFromParent)
                {
                    string _tmpRelations = @"ALTER TABLE[dbo].[" + _ReferencingTableData[ParentHashKey].ParentName + "] ADD CONSTRAINT FK_" + _ReferencingTableData[ParentHashKey].ParentName + "_" +
                        _ReferencingTableData[ParentHashKey].FieldName + " FOREIGN KEY(" + _ReferencingTableData[ParentHashKey].FieldName + "_ID) REFERENCES[dbo].[" + T.Name + "] (" + _TmpPK + ") ";

                    _tmpReturn.Add((_tmpRelations, _SQL_Exececution_Position + 1));
                }
            }

            return _tmpReturn;
        }

        /// <summary>
        /// Generates the Tables needed to lookup based on a property of type List<string>.
        /// </summary>
        /// <param name="ParentObjectName">Base Object - That contains the List<string>.</param>
        /// <param name="PropertyName">Object Property that is a List<string>.</param>
        /// <param name="ObjectPrimaryKeyName">Base Object Primary Key Property Name, I.e "UD".</param>
        /// <returns>.</returns>
        public static List<(string, int)> Create_LIST_String_LookupTable(string ParentObjectName, string PropertyName, string ObjectPrimaryKeyName)
        {
            // CREATE PRIMARY_TO_PROPERTY (CREATE KINGUIDPRODUCT_TO_DEVS)
            string _TableSecondary = _TableCreate.Replace("###TABLE_NAME###", ParentObjectName + "_To_" + PropertyName);
            _TableSecondary = _TableSecondary + _tmpWholeNumber_Column_SQLTemplate.Replace("###COLUMN_NAME###", "ID").Replace("###CANBENULL###", "NOT NULL").Replace("###IDENTITY###", "IDENTITY(1,1)");
            _TableSecondary = _TableSecondary + _tmpWholeNumber_Column_SQLTemplate.Replace("###COLUMN_NAME###", ParentObjectName + "_" + ObjectPrimaryKeyName).Replace("###CANBENULL###", "NOT NULL").Replace("###IDENTITY###", "");
            _TableSecondary = _TableSecondary + _tmpWholeNumber_Column_SQLTemplate.Replace("###COLUMN_NAME###", PropertyName + "_ID").Replace("###CANBENULL###", "NOT NULL").Replace("###IDENTITY###", "");
            _TableSecondary = _TableSecondary + _tmpTableWholeNumber_PK_CONSTRAINT_SQLTemplate.Replace("###TABLENAME###", ParentObjectName + "_To_" + PropertyName).Replace("###PKFIELDNAME###", "ID");

            // CREATE PROPERTY TABLE (CREATE DEVS)
            string _TableMain = _TableCreate.Replace("###TABLE_NAME###", PropertyName);
            _TableMain = _TableMain + _tmpWholeNumber_Column_SQLTemplate.Replace("###COLUMN_NAME###", "ID").Replace("###CANBENULL###", "NOT NULL").Replace("###IDENTITY###", "IDENTITY(1,1)");
            _TableMain = _TableMain + _tmpString_Column_SQLTemplate.Replace("###COLUMN_NAME###", "Name").Replace("###CANBENULL###", "NULL");
            _TableMain = _TableMain + _tmpTableWholeNumber_PK_CONSTRAINT_SQLTemplate.Replace("###TABLENAME###", PropertyName).Replace("###PKFIELDNAME###", "ID");

            string _FirstSQLRelationship = @"ALTER TABLE[dbo].[" + ParentObjectName + "_To_" + PropertyName + "] ADD CONSTRAINT FK_" + ParentObjectName + "_" + PropertyName +
                " FOREIGN KEY(" + ParentObjectName + "_" + ObjectPrimaryKeyName + ") REFERENCES[dbo].[" + ParentObjectName + "] (" + ObjectPrimaryKeyName + ") ";

            string _SecondSQLRelationship = @"ALTER TABLE[dbo].[" + ParentObjectName + "_To_" + PropertyName + "] ADD CONSTRAINT FK_" + PropertyName + "_ID" +
                " FOREIGN KEY(" + PropertyName + "_ID) REFERENCES[dbo].[" + PropertyName + "] (ID) ";


            return new List<(string SqlStatement, int DependancyLevel)>() { (_TableMain, _SQL_Exececution_Position + 1), (_TableSecondary, _SQL_Exececution_Position + 2),
                    (_FirstSQLRelationship, _SQL_Exececution_Position + 3), (_SecondSQLRelationship, _SQL_Exececution_Position + 3) };
        }
    }
}
//static string _tmpRelationship_SQL_Template =