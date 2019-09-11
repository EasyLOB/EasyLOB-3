using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void Demo()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<1> DIManager Demo");
                Console.WriteLine("<2> e-mail Demo");
                Console.WriteLine("<3> Environment Application Demo");
                Console.WriteLine("<4> Environment Session Demo");
                Console.WriteLine("<5> Multi-Tenant Demo");
                Console.WriteLine("<6> Log Demo");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        DIManagerDemo();
                        break;

                    case ('2'):
                        EMailDemo();
                        break;

                    case ('3'):
                        EnvironmentApplicationDemo();
                        break;

                    case ('4'):
                        EnvironmentSessionDemo();
                        break;

                    case ('5'):
                        MultiTenantDemo();
                        break;

                    case ('6'):
                        LogDemo();
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