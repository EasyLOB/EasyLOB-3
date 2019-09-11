using EasyLOB.Identity.Data;
using EasyLOB.Persistence;
using Microsoft.AspNet.Identity;
using System;

namespace EasyLOB.Identity.Persistence
{
    public class IdentityUserRepository : IdentityGenericRepositoryNH<User>
    {
        #region Methods

        public IdentityUserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override bool Create(ZOperationResult operationResult, User entity)
        {
            try
            {
                ApplicationUser user = new ApplicationUser { UserName = entity.UserName, Email = entity.Email };
                IdentityResult identityResult = IdentityHelperNH.UserManager.Create(user, entity.PasswordHash);
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

        public override bool Delete(ZOperationResult operationResult, User entity)
        {
            try
            {
                ApplicationUser user = IdentityHelperNH.UserManager.FindById(entity.Id);
                if (user != null)
                {
                    IdentityResult identityResult = IdentityHelperNH.UserManager.Delete(user);
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

        public override bool Update(ZOperationResult operationResult, User entity)
        //public override async void Update(ZOperationResult operationResult, User entity)
        {
            try
            {
                ApplicationUser user = IdentityHelperNH.UserManager.FindById(entity.Id);

                user.Email = entity.Email;
                IdentityResult validEmail = new IdentityResult();
                //validEmail = await IdentityHelperNH.UserManager.UserValidator.ValidateAsync(user);
                if (!validEmail.Succeeded)
                {
                    operationResult.ParseIdentityResult(validEmail);
                }

                IdentityResult validPassword = new IdentityResult();
                if (!String.IsNullOrEmpty(entity.PasswordHash))
                {
                    //validPassword = await IdentityHelperNH.UserManager.PasswordValidator.ValidateAsync(entity.PasswordHash);
                    if (validPassword.Succeeded)
                    {
                        user.PasswordHash = IdentityHelperNH.UserManager.PasswordHasher.HashPassword(entity.PasswordHash);
                    }
                    else
                    {
                        operationResult.ParseIdentityResult(validPassword);
                    }
                }

                if (validEmail.Succeeded && validPassword.Succeeded)
                {
                    IdentityResult identityResult = IdentityHelperNH.UserManager.Update(user);
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

        #endregion Methods
    }
}