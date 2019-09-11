using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void PersistenceDemo()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Persistence Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<1> Activity Demo");
                Console.WriteLine("<2> Audit Trail Demo");
                Console.WriteLine("<3> Identity Demo");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        PersistenceActivityDemo();
                        break;

                    case ('2'):
                        PersistenceAuditTrailDemo();
                        break;

                    case ('3'):
                        PersistenceIdentityDemo();
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