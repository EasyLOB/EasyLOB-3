using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void CRUDDemo()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("CRUD Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<1> CRUD Application Demo");
                Console.WriteLine("<2> CRUD Persistence Demo");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        CRUDApplication();
                        break;

                    case ('2'):
                        CRUDPersistence();
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