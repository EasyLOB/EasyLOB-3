using EasyLOB.Data;
using EasyLOB.Identity;
using EasyLOB.Identity.Data;
using EasyLOB.Persistence;
using System;
using System.Linq;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void PersistenceIdentityDemo()
        {
            Console.WriteLine("\nPersistence Identity Demo\n");

            IUnitOfWork unitOfWork = ManagerHelper.DIManager.GetService<IIdentityUnitOfWork>();
            Console.WriteLine(unitOfWork.GetType().FullName + " with " + unitOfWork.DBMS.ToString() + "\n");

            PersistenceIdentityData<Role>(unitOfWork);
            PersistenceIdentityData<UserClaim>(unitOfWork);
            PersistenceIdentityData<UserLogin>(unitOfWork);
            PersistenceIdentityData<UserRole>(unitOfWork);
            PersistenceIdentityData<User>(unitOfWork);
        }

        private static void PersistenceIdentityData<TEntity>(IUnitOfWork unitOfWork)
            where TEntity : ZDataBase
        {
            IGenericRepository<TEntity> repository = unitOfWork.GetRepository<TEntity>();
            TEntity entity = repository.Query().FirstOrDefault();
            Console.WriteLine(typeof(TEntity).Name + ": " + repository.CountAll());
        }
    }
}