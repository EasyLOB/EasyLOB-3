using EasyLOB.Activity;
using EasyLOB.Activity.Application;
using EasyLOB.Activity.Persistence;
using EasyLOB.Security;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupActivity()
        {
            Container.RegisterType(typeof(IAuthorizationManager), typeof(AuthorizationManagerMock), AppLifetimeManager);
            //Container.RegisterType(typeof(IAuthorizationManager), typeof(AuthorizationManager), AppLifetimeManager);

            Container.RegisterType(typeof(IActivityGenericApplication<>), typeof(ActivityGenericApplication<>), AppLifetimeManager);
            Container.RegisterType(typeof(IActivityGenericApplicationDTO<,>), typeof(ActivityGenericApplicationDTO<,>), AppLifetimeManager);

            // Entity Framework
            Container.RegisterType(typeof(IActivityUnitOfWork), typeof(ActivityUnitOfWorkEF), AppLifetimeManager);
            Container.RegisterType(typeof(IActivityGenericRepository<>), typeof(ActivityGenericRepositoryEF<>), AppLifetimeManager);

            // LINQ to DB
            //Container.RegisterType(typeof(IActivityUnitOfWork), typeof(ActivityUnitOfWorkLINQ2DB), AppLifetimeManager);
            //Container.RegisterType(typeof(IActivityGenericRepository<>), typeof(ActivityGenericRepositoryLINQ2DB<>), AppLifetimeManager);

            // NHibernate
            //Container.RegisterType(typeof(IActivityUnitOfWork), typeof(ActivityUnitOfWorkNH), AppLifetimeManager);
            //Container.RegisterType(typeof(IActivityGenericRepository<>), typeof(ActivityGenericRepositoryNH<>), AppLifetimeManager);
        }
    }
}