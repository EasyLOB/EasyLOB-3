using Autofac;
using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Application;
using EasyLOB.AuditTrail.Persistence;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupAuditTrail()
        {
            ContainerBuilder.RegisterType<AuditTrailManagerMock>().As<IAuditTrailManager>();
            //ContainerBuilder.RegisterType<AuditTrailManager>().As<IAuditTrailManager>();

            ContainerBuilder.RegisterGeneric(typeof(AuditTrailGenericApplication<>)).As(typeof(IAuditTrailGenericApplication<>));
            ContainerBuilder.RegisterGeneric(typeof(AuditTrailGenericApplicationDTO<,>)).As(typeof(IAuditTrailGenericApplicationDTO<,>));

            // Entity Framework
            ContainerBuilder.RegisterType<AuditTrailUnitOfWorkEF>().As<IAuditTrailUnitOfWork>();
            ContainerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryEF<>)).As(typeof(IAuditTrailGenericRepository<>));

            // LINQ to DB
            //ContainerBuilder.RegisterType<AuditTrailUnitOfWorkLINQ2DB>().As<IAuditTrailUnitOfWork>();
            //ContainerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryLINQ2DB<>)).As(typeof(IAuditTrailGenericRepository<>));

            // NHibernate
            //ContainerBuilder.RegisterType<AuditTrailUnitOfWorkEF>().As<IAuditTrailUnitOfWork>();
            //ContainerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryEF<>)).As(typeof(IAuditTrailGenericRepository<>));
        }
    }
}