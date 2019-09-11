using EasyLOB.Identity.Data;
using EasyLOB.Persistence;
using Microsoft.AspNet.Identity;
using System;

namespace EasyLOB.Identity.Persistence
{
    public class IdentityRoleRepository : IdentityGenericRepositoryNH<Role>
    {
        #region Methods

        public IdentityRoleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override bool Create(ZOperationResult operationResult, Role entity)
        {
            try
            {
                ApplicationRole role = new ApplicationRole { Name = entity.Name };
                IdentityResult identityResult = IdentityHelperNH.RoleManager.Create(role);
                if (!identityResult.Succeeded)
                {
                    operationResult.ParseIdentityResult(identityResult);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionNHibernate(exception);
            }

            return operationResult.Ok;
        }

        public override bool Delete(ZOperationResult operationResult, Role entity)
        {
            try
            {
                ApplicationRole role = IdentityHelperNH.RoleManager.FindById(entity.Id);
                if (role != null)
                {
                    IdentityResult identityResult = IdentityHelperNH.RoleManager.Delete(role);
                    if (!identityResult.Succeeded)
                    {
                        operationResult.ParseIdentityResult(identityResult);
                    }
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionNHibernate(exception);
            }

            return operationResult.Ok;
        }

        public override bool Update(ZOperationResult operationResult, Role entity)
        {
            try
            {
                ApplicationRole role = IdentityHelperNH.RoleManager.FindById(entity.Id);
                role.Name = entity.Name;
                IdentityResult identityResult = IdentityHelperNH.RoleManager.Update(role);
                if (!identityResult.Succeeded)
                {
                    operationResult.ParseIdentityResult(identityResult);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseExceptionNHibernate(exception);
            }

            return operationResult.Ok;
        }

        #endregion Methods
    }
}