using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void ApplicationDemo()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Application Demo\n");
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
                        ApplicationActivityDemo();
                        break;

                    case ('2'):
                        ApplicationAuditTrailDemo();
                        break;

                    case ('3'):
                        ApplicationIdentityDemo();
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