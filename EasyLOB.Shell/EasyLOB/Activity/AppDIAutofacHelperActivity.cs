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
            ContainerBuilder.RegisterType<AuthorizationManagerMock>().As<IAuthorizationManager>();
            //ContainerBuilder.RegisterType<AuthorizationManager>().As<IAuthorizationManager>();

            ContainerBuilder.RegisterGeneric(typeof(ActivityGenericApplication<>)).As(typeof(IActivityGenericApplication<>));
            ContainerBuilder.RegisterGeneric(typeof(ActivityGenericApplicationDTO<,>)).As(typeof(IActivityGenericApplicationDTO<,>));

            // Entity Framework
            ContainerBuilder.RegisterType<ActivityUnitOfWorkEF>().As<IActivityUnitOfWork>();
            ContainerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryEF<>)).As(typeof(IActivityGenericRepository<>));

            // LINQ to DB
            //ContainerBuilder.RegisterType<ActivityUnitOfWorkLINQ2DB>().As<IActivityUnitOfWork>();
            //ContainerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryLINQ2DB<>)).As(typeof(IActivityGenericRepository<>));

            // NHibernate
            //ContainerBuilder.RegisterType<ActivityUnitOfWorkEF>().As<IActivityUnitOfWork>();
            //ContainerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryEF<>)).As(typeof(IActivityGenericRepository<>));
        }
    }
}