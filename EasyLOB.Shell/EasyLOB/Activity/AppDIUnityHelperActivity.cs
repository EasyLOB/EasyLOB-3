using EasyLOB.Activity;
using EasyLOB.Activity.Application;
using EasyLOB.Activity.Persistence;
using EasyLOB.Security;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupActivity(IUnityContainer container)
        {
            container.RegisterType(typeof(IAuthorizationManager), typeof(AuthorizationManagerMock), AppLifetimeManager);
            //container.RegisterType(typeof(IAuthorizationManager), typeof(AuthorizationManager), AppLifetimeManager);

            container.RegisterType(typeof(IActivityGenericApplication<>), typeof(ActivityGenericApplication<>), AppLifetimeManager);
            container.RegisterType(typeof(IActivityGenericApplicationDTO<,>), typeof(ActivityGenericApplicationDTO<,>), AppLifetimeManager);

            // Entity Framework
            container.RegisterType(typeof(IActivityUnitOfWork), typeof(ActivityUnitOfWorkEF), AppLifetimeManager);
            container.RegisterType(typeof(IActivityGenericRepository<>), typeof(ActivityGenericRepositoryEF<>), AppLifetimeManager);

            // LINQ to DB
            //container.RegisterType(typeof(IActivityUnitOfWork), typeof(ActivityUnitOfWorkLINQ2DB), AppLifetimeManager);
            //container.RegisterType(typeof(IActivityGenericRepository<>), typeof(ActivityGenericRepositoryLINQ2DB<>), AppLifetimeManager);

            // NHibernate
            //container.RegisterType(typeof(IActivityUnitOfWork), typeof(ActivityUnitOfWorkNH), AppLifetimeManager);
            //container.RegisterType(typeof(IActivityGenericRepository<>), typeof(ActivityGenericRepositoryNH<>), AppLifetimeManager);
        }
    }
}