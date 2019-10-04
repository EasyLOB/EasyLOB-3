using Autofac;
using EasyLOB.Activity;
using EasyLOB.Activity.Application;
using EasyLOB.Activity.Persistence;
using EasyLOB.Security;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupActivity()
        {
            ContainerBuilder.RegisterType<AuthorizationManagerMock>().As<IAuthorizationManager>().SingleInstance();
            //ContainerBuilder.RegisterType<AuthorizationManager>().As<IAuthorizationManager>().SingleInstance();

            ContainerBuilder.RegisterGeneric(typeof(ActivityGenericApplication<>)).As(typeof(IActivityGenericApplication<>)).SingleInstance();
            ContainerBuilder.RegisterGeneric(typeof(ActivityGenericApplicationDTO<,>)).As(typeof(IActivityGenericApplicationDTO<,>)).SingleInstance();

            // Entity Framework
            ContainerBuilder.RegisterType<ActivityUnitOfWorkEF>().As<IActivityUnitOfWork>().SingleInstance();
            ContainerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryEF<>)).As(typeof(IActivityGenericRepository<>)).SingleInstance();

            // LINQ to DB
            //ContainerBuilder.RegisterType<ActivityUnitOfWorkLINQ2DB>().As<IActivityUnitOfWork>().SingleInstance();
            //ContainerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryLINQ2DB<>)).As(typeof(IActivityGenericRepository<>)).SingleInstance();

            // NHibernate
            //ContainerBuilder.RegisterType<ActivityUnitOfWorkEF>().As<IActivityUnitOfWork>().SingleInstance();
            //ContainerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryEF<>)).As(typeof(IActivityGenericRepository<>)).SingleInstance();
        }
    }
}