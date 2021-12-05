using ACT.Core.Extensions;
using IVolt.Kinguin.API.Enums;
using IVolt.Kinguin.API.Security;
namespace IVolt.Kinguin.ManagementConsole
{
    class Program
    {
        static void DownloadAll()
        {
            int _LastPage = 1;
            int _TotalDownloadsFound = 0;
            int _CurrentPageTry = 0;
            // The While Loop is For When An Error Occurs. As Long as 1 Product Downloaded We Try Again
            // Rules Are - Page Size Try Twice Then Move On _LastPage++;
            // TotalDownloads Doesnt Increase After 5 Tries Abort And Throw Hard Error
            string _PathToDownloadTo =
                FileSecurity.GetConfigurationFile(Protected_Files.KinguinLocalDownloadFolder);
            while (IVolt.Kinguin.API.Products.V1.Products_API_Client
                                  .DownloadAllProducts(1, _PathToDownloadTo).totalDownloads > -1)
            {
                Console.WriteLine("Downloaded Page: " + _LastPage.ToString());
                _LastPage++;
            }

            Console.WriteLine("Completed Download");
            return;
        }

        static void Main(string[] args)
        {
            MainMenu();
            return;

            #region OLD CODE
            /*

		    string _Dest = FileSecurity.KinguinProcessedFilesFolder_Protected.EnsureDirectoryFormat ();
		                  


            var _Start = DateTime.Now;
		    var _O = ACT.Core.CurrentCore<I_QueryResult>.GetCurrent();
		   Kinguin_API_LIB.Local.Import_Json_Files_Into_Database.Process ();
            //Import_Json_Files_Into_Database.LoadAllMetaData(_Files.GetRange (0,1000));

            //for (int x = 0; x < 100; x++)
            // {

            //    var t = Kinguin_Product.FromJson (System.IO.File.ReadAllText(_Files[x]));
            //  Kinguin_API_LIB.Local.Import_Json_Files_Into_Database.AddProductToLocalDatabase (t, _Files[x]);
            // }

            var _end = DateTime.Now;

            Console.WriteLine((_end-_Start).TotalSeconds.ToString());
            Console.ReadKey ();

	        return;


            int _LastPage = 1;
	        int _TotalDownloadsFound = 0;
	        int _CurrentPageTry = 0;
	        // The While Loop is For When An Error Occurs. As Long as 1 Product Downloaded We Try Again
	        // Rules Are - Page Size Try Twice Then Move On _LastPage++;
	        // TotalDownloads Doesnt Increase After 5 Tries Abort And Throw Hard Error
	        string _PathToDownloadTo =
		        FileSecurity.GetConfigurationFile(Protected_Files.KinguinLocalDownloadFolder);
	        while (Kinguin_API_LIB.Products.V1.Products_API_Client
	                              .DownloadAllProducts(1, _PathToDownloadTo).totalDownloads > -1)
	        {
		        Console.WriteLine("Downloaded Page: " + _LastPage.ToString());
		        _LastPage++;
	        }


            return;
            MainMenu();

            return;

            string BaseFilePth = @"D:\__Kinguin_Downloads\10-1-2021\";

            */
            #endregion
        }

        static void MainMenu()
        {

        mainMenu:
            Console.Clear();
            Console.WriteLine("Kinguin API - Console Admin Menu");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Download All Products");
            Console.WriteLine("2. Import Products Into Kinguin DB");
            Console.WriteLine("3. Push Products To NOP Commerce");
            Console.WriteLine("4. Cleanup Product Files");
            Console.WriteLine("5. Revert Product Cleanup");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("6. ");
            Console.WriteLine("7. Exit");

            string _Action = Console.ReadLine();

            _Action = _Action.Trim().Replace(".", "");

            int _ActionNumber = 0;
            try { _ActionNumber = Convert.ToInt32(_Action); }
            catch
            {
                ShowConsoleError("Invalid Selection: Please Enter a Number 1-6 followed by the enter key");
                goto mainMenu;
            }

            switch (_ActionNumber)
            {
                case 1:
                    DownloadAll();
                    goto mainMenu;
                case 2:
                    Console.WriteLine("===========================");
                    Console.WriteLine("Starting The Main Process");
                    Console.WriteLine("===========================");
                    IVolt.Kinguin.API.Local.JSON_File_Importer.Process();
                    Console.WriteLine("===========================");
                    Console.WriteLine("Completed The Main Process");
                    Console.WriteLine("===========================");
                    Console.ReadKey();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                five:
                    Console.WriteLine("Source Path");
                    var _Source = Console.ReadLine();
                    Console.WriteLine("Desc Path");
                    var _Dest = Console.ReadLine();

                    if (_Source.DirectoryExists() == false) { goto five; }
                    if (_Dest.DirectoryExists() == false) { goto five; }

                    IVolt.Kinguin.API.Local.JSON_File_Importer.ReverseCleanupProcessedFile(_Source, _Dest);
                    break;
                case 6:
                    break;
                case 7:
                    return;
                default:
                    break;
            }

        }

        static void ShowConsoleError(string Msg)
        {
            var _Original = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Msg);
            Console.WriteLine("Press Any Key To Continue.");
            Console.ForegroundColor = _Original;
            Console.ReadKey();
        }

        static void ShowConsoleSuccessMessage(string Msg)
        {
            var _Original = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Msg);
            Console.WriteLine("Press Any Key To Continue.");
            Console.ForegroundColor = _Original;
            Console.ReadKey();
        }

        #region Menu Processors

        static void FileCleanupMenu()
        {
        mainMenu:
            Console.Clear();
            Console.WriteLine("Kinguin API - Main Menu -> JSON File Maintenance");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Cleanup Files");
            Console.WriteLine("2. Archive Processed Files");
            Console.WriteLine("3. Process Remaining Files");
            Console.WriteLine("4. Back");
            Console.Write("Choice: ");

            var _ActionNumber = GetChoice(4);
            if (_ActionNumber == -1) { ShowConsoleError("Invalid Selection: Please Enter a Number 1-4 followed by the enter key"); goto mainMenu; }

            switch (_ActionNumber)
            {
                case 1:

                    goto mainMenu;
                case 2:
                    // TODO
                    break;
                case 3:
                    IVolt.Kinguin.API.Local.JSON_File_Importer.Process();
                    break;
                case 4:
                    return;
                default:
                    return;
            }
        }

        static int GetChoice(int Max)
        {
        start:
            string _Action = Console.ReadLine();
            if (_Action == null) { goto start; }

            _Action = _Action.Trim().Replace(".", "");
            int _ActionNumber = 0;
            try { _ActionNumber = Convert.ToInt32(_Action); }
            catch { return -1; }
            if (Max < _ActionNumber) { return -1; }
            return _ActionNumber;
        }

        static void FileSecurityProcessor()
        {
            return;
        mainMenu:
            Console.Clear();
            Console.WriteLine("Kinguin API - Main Menu -> File Security");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Protect Files");
            Console.WriteLine("2. Un-Protect Files");
            Console.WriteLine("3. Back");
            Console.Write("Choice: ");

            var _ActionNumber = GetChoice(3);
            if (_ActionNumber == -1) { ShowConsoleError("Invalid Selection: Please Enter a Number 1-6 followed by the enter key"); goto mainMenu; }

            switch (_ActionNumber)
            {
                case 1:
                    //  Kinguin_API_LIB.Security.FileSecurity.ProtectFiles();
                    Console.WriteLine("Files Protected!");
                    break;
                case 2:
                    Console.WriteLine("------------- UnProtect ---------------");
                unProtectPath:
                    Console.Write("Unprotect Files To Path: ");
                    var _Path = Console.ReadLine();
                    if (System.IO.File.Exists(_Path) == false)
                    {
                        ShowConsoleError("Path Doesn't Exist");
                        goto unProtectPath;
                    }

                    //   Kinguin_API_LIB.Security.FileSecurity.UnProtect_ToDirectory(
                    //       Kinguin_API_LIB.Enums.Protected_Files.ALL, _Path);
                    ShowConsoleSuccessMessage("Success - Check Output Path");
                    Console.ReadKey();
                    goto mainMenu;
                case 3:
                    return;
                default:
                    break;
            }

        }
        // TODO LEFT OFF HERE !!! START HERE
        static void ProductMenuProcessor()
        {
        mainMenu:
            Console.Clear();
            Console.WriteLine("Product Menu - Main Menu -> File Security");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Download All Products");
            Console.WriteLine("2. Search For Product");
            Console.WriteLine("3. Update All Products");
            Console.WriteLine("------------------------");
            Console.WriteLine("4. Back");
            Console.Write("Choice: ");

            int _Action = GetChoice(4);

            if (_Action == -1)
            {
                ShowConsoleError("Invalid Selection: Please Enter a Number 1-4 followed by the enter key");
                goto mainMenu;
            }

            switch (_Action)
            {
                case 1:
                    int _LastPage = 1;
                    int _TotalDownloadsFound = 0;
                    int _CurrentPageTry = 0;
                    // The While Loop is For When An Error Occurs. As Long as 1 Product Downloaded We Try Again
                    // Rules Are - Page Size Try Twice Then Move On _LastPage++;
                    // TotalDownloads Doesnt Increase After 5 Tries Abort And Throw Hard Error
                    string _PathToDownloadTo =
                        FileSecurity.GetConfigurationFile(IVolt.Kinguin.API.Enums.Protected_Files.KinguinLocalDownloadFolder);
                    while (IVolt.Kinguin.API.Products.V1.Products_API_Client
                                          .DownloadAllProducts(1, _PathToDownloadTo).totalDownloads > -1)
                    {
                        Console.WriteLine("Downloaded Page: " + _LastPage.ToString());
                        _LastPage++;
                    }

                    Console.WriteLine("Files Protected!");
                    break;
                case 2:
                    Console.WriteLine("------------- UnProtect ---------------");
                unProtectPath:
                    Console.Write("Unprotect Files To Path: ");
                    var _Path = Console.ReadLine();
                    if (System.IO.File.Exists(_Path) == false)
                    {
                        ShowConsoleError("Path Doesn't Exist");
                        goto unProtectPath;
                    }

                    //Kinguin_API_LIB.Security.FileSecurity.UnProtect_ToDirectory(Kinguin_API_LIB.Enums.Protected_Files.ALL, _Path);
                    ShowConsoleSuccessMessage("Success - Check Output Path");
                    Console.ReadKey();
                    goto mainMenu;
                case 3:
                    return;
                default:
                    break;
            }

        }



    }
}

#endregion