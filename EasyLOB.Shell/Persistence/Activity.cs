using EasyLOB.Activity;
using EasyLOB.Activity.Data;
using EasyLOB.Data;
using System;
using System.Linq;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void PersistenceActivityDemo()
        {
            Console.WriteLine("\nPersistence Activity Demo\n");

            IActivityUnitOfWork unitOfWork = DIHelper.DIManager.GetService<IActivityUnitOfWork>();
            Console.WriteLine(unitOfWork.GetType().FullName + " with " + unitOfWork.DBMS.ToString() + "\n");

            PersistenceActivityData<EasyLOB.Activity.Data.Activity>(unitOfWork);
            PersistenceActivityData<ActivityRole>(unitOfWork);
        }

        private static void PersistenceActivityData<TEntity>(IActivityUnitOfWork unitOfWork)
            where TEntity : ZDataBase
        {
            IGenericRepository<TEntity> repository = unitOfWork.GetRepository<TEntity>();
            TEntity entity = repository.Query().FirstOrDefault();
            Console.WriteLine(typeof(TEntity).Name + ": " + repository.CountAll());
        }
    }
}