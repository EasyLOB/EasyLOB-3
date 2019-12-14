using EasyLOB.Identity.Data;
using AutoMapper;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void AutoMapperIdentity123()
        {
            Console.WriteLine("\nApplication Identity DTO -> Data -> DTO\n");

            {
                Console.WriteLine("Role");
                Role data = new Role();
                RoleDTO dto = DIHelper.Mapper.Map<RoleDTO>(data);
                data = DIHelper.Mapper.Map<Role>(dto);
            }

            {
                Console.WriteLine("UserClaim");
                UserClaim data = new UserClaim();
                UserClaimDTO dto = DIHelper.Mapper.Map<UserClaimDTO>(data);
                data = DIHelper.Mapper.Map<UserClaim>(dto);
            }

            {
                Console.WriteLine("UserLogim");
                UserLogin data = new UserLogin();
                UserLoginDTO dto = DIHelper.Mapper.Map<UserLoginDTO>(data);
                data = DIHelper.Mapper.Map<UserLogin>(dto);
            }

            {
                Console.WriteLine("UserRole");
                UserRole data = new UserRole();
                UserRoleDTO dto = DIHelper.Mapper.Map<UserRoleDTO>(data);
                data = DIHelper.Mapper.Map<UserRole>(dto);
            }

            {
                Console.WriteLine("User");
                User data = new User();
                UserDTO dto = DIHelper.Mapper.Map<UserDTO>(data);
                data = DIHelper.Mapper.Map<User>(dto);
            }
        }
    }
}
