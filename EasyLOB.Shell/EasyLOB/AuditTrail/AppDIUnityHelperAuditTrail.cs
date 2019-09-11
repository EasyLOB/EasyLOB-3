using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Application;
using EasyLOB.AuditTrail.Persistence;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupAuditTrail()
        {
            Container.RegisterType(typeof(IAuditTrailManager), typeof(AuditTrailManagerMock), AppLifetimeManager);
            //Container.RegisterType(typeof(IAuditTrailManager), typeof(AuditTrailManager), AppLifetimeManager);

            Container.RegisterType(typeof(IAuditTrailGenericApplication<>), typeof(AuditTrailGenericApplication<>), AppLifetimeManager);
            Container.RegisterType(typeof(IAuditTrailGenericApplicationDTO<,>), typeof(AuditTrailGenericApplicationDTO<,>), AppLifetimeManager);

            // Entity Framework
            Container.RegisterType(typeof(IAuditTrailUnitOfWork), typeof(AuditTrailUnitOfWorkEF), AppLifetimeManager);
            Container.RegisterType(typeof(IAuditTrailGenericRepository<>), typeof(AuditTrailGenericRepositoryEF<>), AppLifetimeManager);

            // LINQ to DB
            //Container.RegisterType(typeof(IAuditTrailUnitOfWork), typeof(AuditTrailUnitOfWorkLINQ2DB), AppLifetimeManager);
            //Container.RegisterType(typeof(IAuditTrailGenericRepository<>), typeof(AuditTrailGenericRepositoryLINQ2DB<>), AppLifetimeManager);

            // NHibernate
            //Container.RegisterType(typeof(IAuditTrailUnitOfWork), typeof(AuditTrailUnitOfWorkNH), AppLifetimeManager);
            //Container.RegisterType(typeof(IAuditTrailGenericRepository<>), typeof(AuditTrailGenericRepositoryNH<>), AppLifetimeManager);
        }
    }
}