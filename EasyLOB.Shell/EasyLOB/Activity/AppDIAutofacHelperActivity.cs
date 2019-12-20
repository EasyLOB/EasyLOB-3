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
        public static void SetupActivity(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<AuthorizationManagerMock>().As<IAuthorizationManager>();
            //containerBuilder.RegisterType<AuthorizationManager>().As<IAuthorizationManager>();

            containerBuilder.RegisterGeneric(typeof(ActivityGenericApplication<>)).As(typeof(IActivityGenericApplication<>));
            containerBuilder.RegisterGeneric(typeof(ActivityGenericApplicationDTO<,>)).As(typeof(IActivityGenericApplicationDTO<,>));

            // Entity Framework
            containerBuilder.RegisterType<ActivityUnitOfWorkEF>().As<IActivityUnitOfWork>();
            containerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryEF<>)).As(typeof(IActivityGenericRepository<>));

            // LINQ to DB
            //containerBuilder.RegisterType<ActivityUnitOfWorkLINQ2DB>().As<IActivityUnitOfWork>();
            //containerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryLINQ2DB<>)).As(typeof(IActivityGenericRepository<>));

            // NHibernate
            //containerBuilder.RegisterType<ActivityUnitOfWorkEF>().As<IActivityUnitOfWork>();
            //containerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryEF<>)).As(typeof(IActivityGenericRepository<>));
        }
    }
}