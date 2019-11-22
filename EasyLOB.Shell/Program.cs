using Autofac;
using EasyLOB.Environment;
using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace EasyLOB.Shell
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // Autofac
            AppDIAutofacHelper.Setup(new ContainerBuilder());

            // Unity
            //AppDIUnityHelper.Setup(new UnityContainer());

            AppHelper.Setup();
            MultiTenantHelper.Setup("MyLOB");

            // EF 6.0 Log
            //DbInterception.Add(new NLogCommandInterceptor());

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("EasyLOB Shell\n");
                Console.WriteLine("<0> EXIT");
                Console.WriteLine("<1> Application Demo");
                Console.WriteLine("<2> Persistence Demo");
                Console.WriteLine("<3> AutoMapper Demo");
                Console.WriteLine("<4> CRUD Demo");
                Console.WriteLine("<5> LINQ Demo");
                Console.WriteLine("<6> EDM Demo");
                Console.WriteLine("<7> Demo");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        ApplicationDemo();
                        break;

                    case ('2'):
                        PersistenceDemo();
                        break;

                    case ('3'):
                        AutoMapperDemo();
                        break;

                    case ('4'):
                        CRUDDemo();
                        break;

                    case ('5'):
                        LINQDemo();
                        break;

                    case ('6'):
                        EDMDemo();
                        break;

                    case ('7'):
                        Demo();
                        break;
                }

                //if (!exit && "".IndexOf(key.KeyChar) >= 0)
                //{
                //    Console.Write("\nPress <KEY> to continue... ");
                //    Console.ReadKey();
                //}
            }
        }

        #region  Methods Write

        private static void Write(string s)
        {
            Console.WriteLine(s);
        }

        private static void WriteException(Exception exception)
        {
            Console.WriteLine(exception.Message, "");
        }

        private static void WriteException(Exception exception, string spaces)
        {
            Console.WriteLine(exception.Message);
            if (exception.InnerException != null)
            {
                WriteException(exception.InnerException, spaces + "  ");
            }
        }

        private static void WriteJSON(Object o)
        {
            string json = JsonConvert.SerializeObject(o, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void WriteObject(Object o)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(o))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(o);
                if (name != "ExtensionData")
                {
                    Console.WriteLine("{0} = {1}", name, value);
                }
            }
        }

        private static void WriteOperationResult(ZOperationResult operationResult)
        {
            Console.WriteLine(operationResult.Text);
        }

        #endregion Methods Write
    }
}
