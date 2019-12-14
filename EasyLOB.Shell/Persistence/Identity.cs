using EasyLOB.Data;
using EasyLOB.Identity;
using EasyLOB.Identity.Data;
using System;
using System.Linq;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void PersistenceIdentityDemo()
        {
            Console.WriteLine("\nPersistence Identity Demo\n");

            IIdentityUnitOfWork unitOfWork = DIHelper.DIManager.GetService<IIdentityUnitOfWork>();
            Console.WriteLine(unitOfWork.GetType().FullName + " with " + unitOfWork.DBMS.ToString() + "\n");

            PersistenceIdentityData<Role>(unitOfWork);
            PersistenceIdentityData<UserClaim>(unitOfWork);
            PersistenceIdentityData<UserLogin>(unitOfWork);
            PersistenceIdentityData<UserRole>(unitOfWork);
            PersistenceIdentityData<User>(unitOfWork);
        }

        private static void PersistenceIdentityData<TEntity>(IIdentityUnitOfWork unitOfWork)
            where TEntity : ZDataBase
        {
            IGenericRepository<TEntity> repository = unitOfWork.GetRepository<TEntity>();
            TEntity entity = repository.Query().FirstOrDefault();
            Console.WriteLine(typeof(TEntity).Name + ": " + repository.CountAll());
        }
    }
}