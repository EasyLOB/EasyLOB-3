using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void DemoEnvironmentApplication()
        {
            Console.WriteLine("\nAppDomain.CurrentDomain.BaseDirectory: {0}", AppDomain.CurrentDomain.BaseDirectory);

            string path = ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration");

            Console.WriteLine("\nApplication Demo");
            Console.WriteLine("\nApplicationDirectory: {0}", ManagerHelper.EnvironmentManager.ApplicationDirectory);
            Console.WriteLine("WebDirectory(path): {0}", ManagerHelper.EnvironmentManager.ApplicationPath(path));
            Console.WriteLine("IsWeb: {0}", ManagerHelper.EnvironmentManager.IsWeb.ToString());
            Console.WriteLine("WebUrl: {0}", ManagerHelper.EnvironmentManager.WebUrl);
            Console.WriteLine("WebPath: {0}", ManagerHelper.EnvironmentManager.WebPath);
            Console.WriteLine("WebDomain: {0}", ManagerHelper.EnvironmentManager.WebDomain);
            Console.WriteLine("WebSubDomain: {0}", ManagerHelper.EnvironmentManager.WebSubDomain);
        }
    }
}