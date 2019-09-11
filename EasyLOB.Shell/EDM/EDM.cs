using EasyLOB.Extensions.Edm;
using EasyLOB.Library;
using System;
using System.IO;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void EDMEntityKeyDemo(IEdmManager edmManager)
        {
            Console.WriteLine("\nEDM { Entity + Key } Demo\n");

            string rootDirectory = ConfigurationHelper.AppSettings<string>("EDM.FileSystem.Directory");
            Console.WriteLine("IMPORTANT: Create \"" + rootDirectory + "\" directory !");
            Console.Write("\nPress <KEY> to continue... ");
            Console.ReadKey();
            Console.WriteLine("\n");

            string txtFilePath = LibraryHelper.AddDirectorySeparator(rootDirectory) + "txt.txt";
            using (StreamWriter writer = new StreamWriter(txtFilePath))
            {
                writer.Write("EasyLOB");
            }

            byte[] file;
            int key;
            string entityName = "Entity", exportPath;
            ZFileTypes fileType;

            // 1
            Console.WriteLine("1");

            key = 1;
            fileType = ZFileTypes.ftTXT;
            exportPath = LibraryHelper.AddDirectorySeparator(rootDirectory) + "txt.1.txt";

            Console.WriteLine("  Write TXT");
            edmManager.WriteFile(entityName, key, fileType, txtFilePath);
            Console.WriteLine("  Read TXT");
            file = edmManager.ReadFile(entityName, key, fileType);
            File.WriteAllBytes(exportPath, file);
            //Console.WriteLine("  Delete TXT");
            //edmManager.EdmEngine.DeleteFile(entityName, key, fileType);

            // 101
            Console.WriteLine("101");

            key = 101;
            fileType = ZFileTypes.ftTXT;
            exportPath = LibraryHelper.AddDirectorySeparator(rootDirectory) + "txt.101.txt";

            Console.WriteLine("  Write TXT");
            edmManager.WriteFile(entityName, key, fileType, txtFilePath);
            Console.WriteLine("  Read TXT");
            file = edmManager.ReadFile(entityName, key, fileType);
            File.WriteAllBytes(exportPath, file);
            //Console.WriteLine("  Delete TXT");
            //edmManager.edmEngine.DeleteFile(entityName, key, fileType);
        }

        private static void EDMFilePathDemo(IEdmManager edmManager)
        {
            Console.WriteLine("\nEDM { File Path } Demo\n");

            string rootDirectory = ConfigurationHelper.AppSettings<string>("EDM.FileSystem.Directory");
            Console.WriteLine("IMPORTANT: Create \"" + rootDirectory + "\" directory !");
            Console.Write("\nPress <KEY> to continue... ");
            Console.ReadKey();
            Console.WriteLine("\n");

            string txtFilePath = LibraryHelper.AddDirectorySeparator(rootDirectory) + "txt.txt";
            using (StreamWriter writer = new StreamWriter(txtFilePath))
            {
                writer.Write("EasyLOB");
            }

            byte[] file;
            string edmFilePath, exportPath;

            // 1
            Console.WriteLine("A/B/C");

            edmFilePath = "A/B/C/txt.txt";
            exportPath = LibraryHelper.AddDirectorySeparator(rootDirectory) + "txt.1.txt";

            Console.WriteLine("  Write TXT");
            edmManager.WriteFile(edmFilePath, txtFilePath);
            Console.WriteLine("  Read TXT");
            file = edmManager.ReadFile(edmFilePath);
            File.WriteAllBytes(exportPath, file);
            //Console.WriteLine("  Delete TXT");
            //edmManager.EdmEngine.DeleteFile(edmFilePath);

            // 101
            Console.WriteLine("101");

            edmFilePath = "A/D/E/txt.txt";
            exportPath = LibraryHelper.AddDirectorySeparator(rootDirectory) + "txt.101.txt";

            Console.WriteLine("  Write TXT");
            edmManager.WriteFile(edmFilePath, txtFilePath);
            Console.WriteLine("  Read TXT");
            file = edmManager.ReadFile(edmFilePath);
            File.WriteAllBytes(exportPath, file);
            //Console.WriteLine("  Delete TXT");
            //edmManager.EdmEngine.DeleteFile(edmFilePath);
        }
    }
}
