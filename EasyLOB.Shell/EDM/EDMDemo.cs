using EasyLOB.Extensions.Edm;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void EDMDemo()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Library Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<1> EDM File System Engine { Entity + Key } Demo => C:\\EDM");
                Console.WriteLine("<2> EDM File System Engine { File Path } Demo => C:\\EDM");
                Console.WriteLine("<3> EDM FTP Engine { Entity + Key } Demo => ftp.easylob.com");
                Console.WriteLine("<4> EDM FTP Engine { File Path } Demo => ftp.easylob.com");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        EDMEntityKeyDemo(new EdmManagerFileSystem());
                        break;

                    case ('2'):
                        EDMFilePathDemo(new EdmManagerFileSystem());
                        break;

                    case ('3'):
                        EDMEntityKeyDemo(new EdmManagerFTP());
                        break;

                    case ('4'):
                        EDMFilePathDemo(new EdmManagerFTP());
                        break;
                }

                if (!exit)
                {
                    Console.Write("\nPress <KEY> to continue... ");
                    Console.ReadKey();
                }
            }
        }
    }
}