using EasyLOB.Identity;
using EasyLOB.Identity.Application;
using EasyLOB.Identity.Persistence;
using EasyLOB.Security;
using System.Security.Principal;
using System.Threading;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupIdentity()
        {
            // App
            Container.RegisterFactory<IPrincipal>(x => Thread.CurrentPrincipal);
            //Container.RegisterType<IPrincipal>(new InjectionFactory(x => Thread.CurrentPrincipal)); // DEPRECATED
            // Web
            //Container.RegisterFactory<IPrincipal>(x => new HttpContextAccessor().HttpContext.User);
            //Container.RegisterType<IPrincipal>(new InjectionFactory(x => new HttpContextAccessor().HttpContext.User)); // DEPRECATED

            Container.RegisterType(typeof(IAuthenticationManager), typeof(AuthenticationManagerMock), AppLifetimeManager);
            //Container.RegisterType(typeof(IAuthenticationManager), typeof(AuthenticationManager), AppLifetimeManager);

            Container.RegisterType(typeof(IIdentityGenericApplication<>), typeof(IdentityGenericApplication<>), AppLifetimeManager);
            Container.RegisterType(typeof(IIdentityGenericApplicationDTO<,>), typeof(IdentityGenericApplicationDTO<,>), AppLifetimeManager);

            // Entity Framework
            Container.RegisterType(typeof(IIdentityUnitOfWork), typeof(IdentityUnitOfWorkEF), AppLifetimeManager);
            Container.RegisterType(typeof(IIdentityGenericRepository<>), typeof(IdentityGenericRepositoryEF<>), AppLifetimeManager);

            // NHibernate
            //Container.RegisterType(typeof(IIdentityUnitOfWork), typeof(IdentityUnitOfWorkNH), AppLifetimeManager);
            //Container.RegisterType(typeof(IIdentityGenericRepository<>), typeof(IdentityGenericRepositoryNH<>), AppLifetimeManager);
        }
    }
}