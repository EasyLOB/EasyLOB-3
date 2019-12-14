using EasyLOB.AuditTrail.Data;
using AutoMapper;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void AutoMapperAuditTrail123()
        {
            Console.WriteLine("\nApplication AuditTrail DTO -> Data -> DTO\n");

            {
                Console.WriteLine("AuditTrailConfiguration");
                AuditTrailConfiguration data = new AuditTrailConfiguration();
                AuditTrailConfigurationDTO dto = DIHelper.Mapper.Map<AuditTrailConfigurationDTO>(data);
                data = DIHelper.Mapper.Map<AuditTrailConfiguration>(dto);
            }

            {
                Console.WriteLine("AuditTrailLog");
                AuditTrailLog data = new AuditTrailLog();
                AuditTrailLogDTO dto = DIHelper.Mapper.Map<AuditTrailLogDTO>(data);
                data = DIHelper.Mapper.Map<AuditTrailLog>(dto);
            }
        }
    }
}
