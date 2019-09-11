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
                RoleDTO dto = Mapper.Map<RoleDTO>(data);
                data = Mapper.Map<Role>(dto);
            }

            {
                Console.WriteLine("UserClaim");
                UserClaim data = new UserClaim();
                UserClaimDTO dto = Mapper.Map<UserClaimDTO>(data);
                data = Mapper.Map<UserClaim>(dto);
            }

            {
                Console.WriteLine("UserLogim");
                UserLogin data = new UserLogin();
                UserLoginDTO dto = Mapper.Map<UserLoginDTO>(data);
                data = Mapper.Map<UserLogin>(dto);
            }

            {
                Console.WriteLine("UserRole");
                UserRole data = new UserRole();
                UserRoleDTO dto = Mapper.Map<UserRoleDTO>(data);
                data = Mapper.Map<UserRole>(dto);
            }

            {
                Console.WriteLine("User");
                User data = new User();
                UserDTO dto = Mapper.Map<UserDTO>(data);
                data = Mapper.Map<User>(dto);
            }
        }
    }
}
