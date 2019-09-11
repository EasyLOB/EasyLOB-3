using EasyLOB.Activity.Data;
using AutoMapper;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void AutoMapperActivity123()
        {
            Console.WriteLine("\nApplication Activity DTO -> Data -> DTO\n");

            {
                Console.WriteLine("Activity");
                EasyLOB.Activity.Data.Activity data = new EasyLOB.Activity.Data.Activity();
                ActivityDTO dto = Mapper.Map<ActivityDTO>(data);
                data = Mapper.Map<EasyLOB.Activity.Data.Activity>(dto);
            }

            {
                Console.WriteLine("ActivityRole");
                ActivityRole data = new ActivityRole();
                ActivityRoleDTO dto = Mapper.Map<ActivityRoleDTO>(data);
                data = Mapper.Map<ActivityRole>(dto);
            }
        }
    }
}
