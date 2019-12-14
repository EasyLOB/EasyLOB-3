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
                ActivityDTO dto = DIHelper.Mapper.Map<ActivityDTO>(data);
                data = DIHelper.Mapper.Map<EasyLOB.Activity.Data.Activity>(dto);
            }

            {
                Console.WriteLine("ActivityRole");
                ActivityRole data = new ActivityRole();
                ActivityRoleDTO dto = DIHelper.Mapper.Map<ActivityRoleDTO>(data);
                data = DIHelper.Mapper.Map<ActivityRole>(dto);
            }
        }
    }
}
