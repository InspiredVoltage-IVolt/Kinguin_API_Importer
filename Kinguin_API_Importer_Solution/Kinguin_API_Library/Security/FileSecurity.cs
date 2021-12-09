using ACT.Core.Extensions;
using IVolt.Kinguin.API.Enums;

namespace IVolt.Kinguin.API.Security
{
    /// <summary>
    /// Defines the <see cref="FileSecurity" />.
    /// </summary>
    public class FileSecurity
    {
        private static readonly byte[] _Entropy = new byte[] { 22, 67, 54, 90, 112, 4, 54, 32, 74, 37, 22, 12, 89 };

        public static string KinguinDatabase_ConnectionString_Protected = ACT.Core.SystemSettings.GetSettingByName("Kinguin_connectionstring").Value;
        public static string NopCommerce_ConnectionString_Protected = ACT.Core.SystemSettings.GetSettingByName("NopComm_connectionstring").Value;
        public static string KinguinLocalDownloadFolder_Protected = ACT.Core.SystemSettings.GetSettingByName("kinguinlocaldownloadfolder").Value;
        public static string KinguinProcessedFilesFolder_Protected = ACT.Core.SystemSettings.GetSettingByName("kinguinProcessedFilesfolder").Value;
        public static string KinguinApi_Protected = ACT.Core.SystemSettings.GetSettingByName("kinguinapikey").Value;
        public static string KinguinNewFileFolderFormat_Protected = ACT.Core.SystemSettings.GetSettingByName("kinguinnewdownloadfolderformat").Value;
        public static string KinguinProcessedFileFolderFormat_Protected = ACT.Core.SystemSettings.GetSettingByName("kinguinprocessedfilesfolderformat").Value;
        public static string Kinguin_ImageDownloadPath = ACT.Core.SystemSettings.GetSettingByName("Kinguin_ImageDownloadPath").Value;
        FileSecurity()
        {

        }

        public static string ProtectString(string DataToProtect)
        {
            return DataToProtect;
            //return System.Text.Encoding.Default.GetString(ProtectedData.Protect(System.Text.Encoding.Default.GetBytes(DataToProtect), _Entropy, DataProtectionScope.LocalMachine));
        }

        public static string UnProtectString(string DataToUnProtect)
        {
            return DataToUnProtect;
            //return System.Text.Encoding.Default.GetString(ProtectedData.Unprotect(System.IO.File.ReadAllBytes(DataToUnProtect), _Entropy, DataProtectionScope.LocalMachine));
        }

        public static string GetConfigurationFile(IVolt.Kinguin.API.Enums.Protected_Files FileToGet)
        {
            if (FileToGet == Protected_Files.KinguinLocalDownloadFolder)
            {
                return KinguinLocalDownloadFolder_Protected.EnsureDirectoryFormat();
            }
            else if (FileToGet == Protected_Files.KinguinApiKey) { return KinguinApi_Protected; }
            else if (FileToGet == Protected_Files.KinguinDbConnection) { return KinguinDatabase_ConnectionString_Protected; }
            else if (FileToGet == Protected_Files.KinguinProcessedFileFolder) { return KinguinProcessedFilesFolder_Protected; }
            else if (FileToGet == Protected_Files.NopCommerceConnection) { return KinguinApi_Protected; }
            else if (FileToGet == Protected_Files.NewFileFolderFormat) { return KinguinNewFileFolderFormat_Protected; }
            else if (FileToGet == Protected_Files.ProcessedFileFolderFormat) { return KinguinProcessedFileFolderFormat_Protected; }
            else { throw new ArgumentException("Invalid File Selected"); }
        }

    }
}
