using EasyLOB.Library;
using Newtonsoft.Json;
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
                Console.WriteLine("<1> DI Demo");
                Console.WriteLine("<2> e-mail Demo");
                Console.WriteLine("<3> Environment Application Demo");
                Console.WriteLine("<4> Environment Session Demo");
                Console.WriteLine("<5> Multi-Tenant Demo");
                Console.WriteLine("<6> Log Demo");
                Console.WriteLine("<7> ZOperationResult Serialization");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        DemoDI();
                        break;

                    case ('2'):
                        DemoEMail();
                        break;

                    case ('3'):
                        DemoEnvironmentApplication();
                        break;

                    case ('4'):
                        DemoEnvironmentSession();
                        break;

                    case ('5'):
                        DemoMultiTenant();
                        break;

                    case ('6'):
                        DemoLog();
                        break;

                    case ('7'):
                        ZOperationResult operationResult = new ZOperationResult();

                        operationResult.InformationCode = "1";
                        operationResult.InformationMessage = "Information";
                        operationResult.WarningCode = "2";
                        operationResult.WarningMessage = "Warning";
                        operationResult.ErrorCode = "3";
                        operationResult.ErrorMessage = "Error";
                        operationResult.Data = "123";
                        operationResult.AddOperationInformation("11", "Information");
                        operationResult.AddOperationWarning("22", "Warning");
                        operationResult.AddOperationError("33", "Error");
                        operationResult.ParseException(new Exception("Exception"));

                        string json = JsonConvert.SerializeObject(operationResult);
                        operationResult = JsonConvert.DeserializeObject<ZOperationResult>(json);
                        int i = operationResult.Data.ToInt32();

                        WriteObject(operationResult);

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