using AutoMapper;
using System;
using System.IO;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void AutoMapperDemo()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("AutoMapper Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<1> Activity DTO -> Data -> DTO");
                Console.WriteLine("<2> Audit Trail DTO -> Data -> DTO");
                Console.WriteLine("<3> Identity DTO -> Data -> DTO");
                Console.WriteLine("<3> EasyLOB Export");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        AutoMapperActivity123();
                        break;

                    case ('2'):
                        AutoMapperAuditTrail123();
                        break;

                    case ('3'):
                        AutoMapperIdentity123();
                        break;

                    case ('4'):
                        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                            "AutoMapper.txt");

                        Console.WriteLine("\nAutoMapper EasyLOB Export: {0}", filePath);

                        using (StreamWriter stream = new StreamWriter(filePath))
                        {
                            TypeMap[] typeMaps = Mapper.Configuration.GetAllTypeMaps();
                            foreach (TypeMap typeMap in typeMaps)
                            {
                                stream.WriteLine("{0} -> {1}", typeMap.SourceType.ToString(), typeMap.DestinationType.ToString());
                            }
                        }

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