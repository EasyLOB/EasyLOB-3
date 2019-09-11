using EasyLOB.Activity;
using EasyLOB.Activity.Data;
using EasyLOB.Data;
using EasyLOB.Persistence;
using System;
using System.Linq;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void PersistenceActivityDemo()
        {
            Console.WriteLine("\nPersistence Activity Demo\n");

            IUnitOfWork unitOfWork = ManagerHelper.DIManager.GetService<IActivityUnitOfWork>();
            Console.WriteLine(unitOfWork.GetType().FullName + " with " + unitOfWork.DBMS.ToString() + "\n");

            PersistenceIdentityData<EasyLOB.Activity.Data.Activity>(unitOfWork);
            PersistenceIdentityData<ActivityRole>(unitOfWork);
        }

        private static void PersistenceActivityData<TEntity>(IUnitOfWork unitOfWork)
            where TEntity : ZDataBase
        {
            IGenericRepository<TEntity> repository = unitOfWork.GetRepository<TEntity>();
            TEntity entity = repository.Query().FirstOrDefault();
            Console.WriteLine(typeof(TEntity).Name + ": " + repository.CountAll());
        }
    }
}