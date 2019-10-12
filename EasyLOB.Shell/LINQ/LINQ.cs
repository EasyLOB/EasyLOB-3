using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void LINQDemo()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<1> LINQ Application Demo");
                Console.WriteLine("<2> LINQ Persistence Demo");
                Console.WriteLine("<3> LINQ Entity Framework Demo");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        LINQApplication();
                        break;

                    case ('2'):
                        LINQPersistence();
                        break;

                    case ('3'):
                        LINQEF();
                        break;
                }
            }
        }
    }
}