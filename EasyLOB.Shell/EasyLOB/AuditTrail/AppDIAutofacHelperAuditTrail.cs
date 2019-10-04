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
            ContainerBuilder.RegisterType<AuditTrailManagerMock>().As<IAuditTrailManager>().SingleInstance();
            //ContainerBuilder.RegisterType<AuditTrailManager>().As<IAuditTrailManager>().SingleInstance();

            ContainerBuilder.RegisterGeneric(typeof(AuditTrailGenericApplication<>)).As(typeof(IAuditTrailGenericApplication<>)).SingleInstance();
            ContainerBuilder.RegisterGeneric(typeof(AuditTrailGenericApplicationDTO<,>)).As(typeof(IAuditTrailGenericApplicationDTO<,>)).SingleInstance();

            // Entity Framework
            ContainerBuilder.RegisterType<AuditTrailUnitOfWorkEF>().As<IAuditTrailUnitOfWork>().SingleInstance();
            ContainerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryEF<>)).As(typeof(IAuditTrailGenericRepository<>)).SingleInstance();

            // LINQ to DB
            //ContainerBuilder.RegisterType<AuditTrailUnitOfWorkLINQ2DB>().As<IAuditTrailUnitOfWork>().SingleInstance();
            //ContainerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryLINQ2DB<>)).As(typeof(IAuditTrailGenericRepository<>)).SingleInstance();

            // NHibernate
            //ContainerBuilder.RegisterType<AuditTrailUnitOfWorkEF>().As<IAuditTrailUnitOfWork>().SingleInstance();
            //ContainerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryEF<>)).As(typeof(IAuditTrailGenericRepository<>)).SingleInstance();
        }
    }
}