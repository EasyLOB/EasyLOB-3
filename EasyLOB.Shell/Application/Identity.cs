using EasyLOB.Data;
using EasyLOB.Identity;
using EasyLOB.Identity.Application;
using EasyLOB.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void ApplicationIdentityDemo()
        {
            Console.WriteLine("\nApplication Identity Demo\n");

            ApplicationIdentityData<Role>();
            ApplicationIdentityDTO<RoleDTO, Role>();

            ApplicationIdentityData<UserClaim>();
            ApplicationIdentityDTO<UserClaimDTO, UserClaim>();

            ApplicationIdentityData<UserLogin>();
            ApplicationIdentityDTO<UserLoginDTO, UserLogin>();

            ApplicationIdentityData<UserRole>();
            ApplicationIdentityDTO<UserRoleDTO, UserRole>();

            ApplicationIdentityData<User>();
            ApplicationIdentityDTO<UserDTO, User>();
        }

        private static void ApplicationIdentityData<TEntity>()
            where TEntity : ZDataBase
        {
            IIdentityGenericApplication<TEntity> application =
                DIHelper.DIManager.GetService<IIdentityGenericApplication<TEntity>>();
            ZOperationResult operationResult = new ZOperationResult();
            IEnumerable<TEntity> enumerable = application.SearchAll(operationResult);
            Console.WriteLine(typeof(TEntity).Name + ": {0}", enumerable.Count());
        }

        private static void ApplicationIdentityDTO<TEntityDTO, TEntity>()
            where TEntityDTO : ZDTOBase<TEntityDTO, TEntity>
            where TEntity : ZDataBase
        {
            IIdentityGenericApplicationDTO<TEntityDTO, TEntity> application =
                DIHelper.DIManager.GetService<IIdentityGenericApplicationDTO<TEntityDTO, TEntity>>();
            ZOperationResult operationResult = new ZOperationResult();
            IEnumerable<TEntityDTO> enumerable = application.SearchAll(operationResult);
            Console.WriteLine(typeof(TEntity).Name + "DTO: {0}", enumerable.Count());
        }
    }
}