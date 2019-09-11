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
                AuditTrailConfigurationDTO dto = Mapper.Map<AuditTrailConfigurationDTO>(data);
                data = Mapper.Map<AuditTrailConfiguration>(dto);
            }

            {
                Console.WriteLine("AuditTrailLog");
                AuditTrailLog data = new AuditTrailLog();
                AuditTrailLogDTO dto = Mapper.Map<AuditTrailLogDTO>(data);
                data = Mapper.Map<AuditTrailLog>(dto);
            }
        }
    }
}
