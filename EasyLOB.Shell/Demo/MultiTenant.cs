using EasyLOB.Environment;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void MultiTenantDemo()
        {
            Console.WriteLine("\nMulti-Tenant Demo");
            AppTenant tenant = MultiTenantHelper.Tenant;
            if (tenant != null)
            {
                Console.WriteLine(String.Format("\nName: {0}", tenant.Name));
            }
            else
            {
                Console.WriteLine("\nName: ?");
            }
        }
    }
}