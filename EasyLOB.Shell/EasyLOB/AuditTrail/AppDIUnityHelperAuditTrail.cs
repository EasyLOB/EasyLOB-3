using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Application;
using EasyLOB.AuditTrail.Persistence;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupAuditTrail(IUnityContainer container)
        {
            container.RegisterType(typeof(IAuditTrailManager), typeof(AuditTrailManagerMock), AppLifetimeManager);
            //container.RegisterType(typeof(IAuditTrailManager), typeof(AuditTrailManager), AppLifetimeManager);

            container.RegisterType(typeof(IAuditTrailGenericApplication<>), typeof(AuditTrailGenericApplication<>), AppLifetimeManager);
            container.RegisterType(typeof(IAuditTrailGenericApplicationDTO<,>), typeof(AuditTrailGenericApplicationDTO<,>), AppLifetimeManager);

            // Entity Framework
            container.RegisterType(typeof(IAuditTrailUnitOfWork), typeof(AuditTrailUnitOfWorkEF), AppLifetimeManager);
            container.RegisterType(typeof(IAuditTrailGenericRepository<>), typeof(AuditTrailGenericRepositoryEF<>), AppLifetimeManager);

            // LINQ to DB
            //container.RegisterType(typeof(IAuditTrailUnitOfWork), typeof(AuditTrailUnitOfWorkLINQ2DB), AppLifetimeManager);
            //container.RegisterType(typeof(IAuditTrailGenericRepository<>), typeof(AuditTrailGenericRepositoryLINQ2DB<>), AppLifetimeManager);

            // NHibernate
            //container.RegisterType(typeof(IAuditTrailUnitOfWork), typeof(AuditTrailUnitOfWorkNH), AppLifetimeManager);
            //container.RegisterType(typeof(IAuditTrailGenericRepository<>), typeof(AuditTrailGenericRepositoryNH<>), AppLifetimeManager);
        }
    }
}