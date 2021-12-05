using ACT.Core.Extensions;
using IVolt.Kinguin.API.Security;

namespace IVolt.Kinguin.API.Local
{

    /// <summary>
    /// Defines the <see cref="JSON_File_Importer" />.
    /// </summary>
    public static partial class JSON_File_Importer
    {
        /// <summary>
        /// Renames and moves JSON Files
        /// </summary>
        /// <param name="File"></param>
        /// <returns></returns>
        private static bool CleanupProcessedFile(string File)
        {

            string _Dest = FileSecurity.KinguinProcessedFilesFolder_Protected.EnsureDirectoryFormat() +
                           File.GetDirectoryFromFileLocation().GetDirectoryName().EnsureDirectoryFormat();

            System.IO.Directory.CreateDirectory(_Dest);

            string _NewFileName = _Dest + File.GetFileNameFromFullPath().Replace(".json", ".processed").Replace(".JSON", ".processed");

            System.IO.File.Move(File, _NewFileName);
            if (System.IO.File.Exists(_NewFileName))
            {
                System.IO.File.Delete(File);
                return true;
            }
            else
            {
                ErrorLog.Add("ERROR RENAMING PROCESSED FILE: " + File);
                return false;
            }
        }

        /// <summary>
        /// Renames and moves JSON Files
        /// </summary>
        /// <param name="File"></param>
        /// <returns></returns>
        public static bool ReverseCleanupProcessedFile(string DirectoryFrom, string DirectoryTo)
        {
            System.IO.Directory.CreateDirectory(DirectoryTo);

            var _Files = DirectoryFrom.GetAllFilesFromPath(false);

            foreach (var file in _Files)
            {
                System.IO.File.Move(file, DirectoryTo.EnsureDirectoryFormat() + file.GetFileNameFromFullPath().Replace(".processed", "").Replace(".json", "") + ".json");
            }

            return true;
        }
    }
}
