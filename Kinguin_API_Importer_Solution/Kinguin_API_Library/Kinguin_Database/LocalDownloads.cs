using ACT.Core.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IVolt.Kinguin.API.Local
{
	/// <summary>
    /// Defines the <see cref="LocalDownloads" />.
    /// </summary>
    public static class LocalDownloads
    {
        private static List<string> AllFiles = new List<string>();

        /// <summary>
        /// The ImportAllProducts.
        /// </summary>
        /// <param name="BaseDir">The BaseDir<see cref="string"/>.</param>
        /// <param name="OnlyLatestFolder">The OnlyLatestFolder<see cref="bool"/>.</param>
        /// <returns>The <see cref="List{string}"/>.</returns>
        public static List<string> GrabAllFilesDownloaded(string BaseDir, bool OnlyLatestFolder = false)
        {
	        List<string> DirectoriesWithData = new List<string>();

            Dictionary<string, DateTime> _DirectoryDateInfo = new Dictionary<string, DateTime>();

            foreach (string dir in System.IO.Directory.GetDirectories(BaseDir, "*", SearchOption.AllDirectories))
            {
                System.IO.DirectoryInfo _DI = new DirectoryInfo(dir);
                var _CurrentDirFiles = System.IO.Directory.GetFiles(dir, "*.json", SearchOption.TopDirectoryOnly);
                if (_CurrentDirFiles.Any()) { _DirectoryDateInfo.Add(dir, _DI.LastWriteTime); }
            }

            if (OnlyLatestFolder)
            {
	            _DirectoryDateInfo.OrderByDescending (x => x.Value).First ().Key.GetAllFilesFromPath (false).ForEach (AddAndEnsureNoDuplicatesAction);
            }
            else
            {
                DirectoriesWithData.AddRange(_DirectoryDateInfo.OrderByDescending(x => x.Value).Select(x => x.Key));
                foreach (string SPath in DirectoriesWithData)
                {
                    SPath.GetAllFilesFromPath(false).ForEach(AddAndEnsureNoDuplicatesAction);
                }
            }
            
            return AllFiles;
        }

        /// <summary>
        /// Action To Only Add JSON Files
        /// </summary>
        /// <param name="Obj"></param>
        private static void AddAndEnsureNoDuplicatesAction(string Obj)
        {
	        if (Obj.ToLower ().EndsWith (".json") == false) { return; }
	        if (AllFiles.Contains(Obj, true) == false) { AllFiles.Add(Obj); }
        }
    }
}

