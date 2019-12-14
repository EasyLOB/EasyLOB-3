using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Data;
using System;
using System.Linq;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void PersistenceAuditTrailDemo()
        {
            Console.WriteLine("\nPersistence AuditTrail Demo\n");

            IAuditTrailUnitOfWork unitOfWork = DIHelper.DIManager.GetService<IAuditTrailUnitOfWork>();
            Console.WriteLine(unitOfWork.GetType().FullName + " with " + unitOfWork.DBMS.ToString() + "\n");

            PersistenceAuditTrailData<AuditTrailConfiguration>(unitOfWork);
            PersistenceAuditTrailData<AuditTrailLog>(unitOfWork);
        }

        private static void PersistenceAuditTrailData<TEntity>(IAuditTrailUnitOfWork unitOfWork)
            where TEntity : class, IZDataBase
        {
            IGenericRepository<TEntity> repository = unitOfWork.GetRepository<TEntity>();
            TEntity entity = repository.Query().FirstOrDefault();
            Console.WriteLine(typeof(TEntity).Name + ": " + repository.CountAll());
        }
    }
}