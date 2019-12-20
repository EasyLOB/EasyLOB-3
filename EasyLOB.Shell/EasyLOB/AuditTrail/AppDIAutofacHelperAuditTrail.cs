using Autofac;
using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Application;
using EasyLOB.AuditTrail.Persistence;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupAuditTrail(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<AuditTrailManagerMock>().As<IAuditTrailManager>();
            //containerBuilder.RegisterType<AuditTrailManager>().As<IAuditTrailManager>();

            containerBuilder.RegisterGeneric(typeof(AuditTrailGenericApplication<>)).As(typeof(IAuditTrailGenericApplication<>));
            containerBuilder.RegisterGeneric(typeof(AuditTrailGenericApplicationDTO<,>)).As(typeof(IAuditTrailGenericApplicationDTO<,>));

            // Entity Framework
            containerBuilder.RegisterType<AuditTrailUnitOfWorkEF>().As<IAuditTrailUnitOfWork>();
            containerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryEF<>)).As(typeof(IAuditTrailGenericRepository<>));

            // LINQ to DB
            //containerBuilder.RegisterType<AuditTrailUnitOfWorkLINQ2DB>().As<IAuditTrailUnitOfWork>();
            //containerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryLINQ2DB<>)).As(typeof(IAuditTrailGenericRepository<>));

            // NHibernate
            //containerBuilder.RegisterType<AuditTrailUnitOfWorkEF>().As<IAuditTrailUnitOfWork>();
            //containerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryEF<>)).As(typeof(IAuditTrailGenericRepository<>));
        }
    }
}