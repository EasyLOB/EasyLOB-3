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
                Console.WriteLine("Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<P> CRUD Persistence Demo");
                //Console.WriteLine("<A> CRUD Application Demo");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('p'):
                    case ('P'):
                        CRUDPersistence();
                        break;

                    //case ('a'):
                    //case ('A'):
                    //    CRUDApplication();
                    //    break;
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