using Autofac;
using EasyLOB.Identity;
using EasyLOB.Identity.Application;
using EasyLOB.Identity.Persistence;
using EasyLOB.Security;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupIdentity(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<AuthenticationManagerMock>().As<IAuthenticationManager>();
            //containerBuilder.RegisterType<AuthenticationManager>().As<IAuthenticationManager>();

            containerBuilder.RegisterGeneric(typeof(IdentityGenericApplication<>)).As(typeof(IIdentityGenericApplication<>));
            containerBuilder.RegisterGeneric(typeof(IdentityGenericApplicationDTO<,>)).As(typeof(IIdentityGenericApplicationDTO<,>));

            // Entity Framework
            containerBuilder.RegisterType<IdentityUnitOfWorkEF>().As<IIdentityUnitOfWork>();
            containerBuilder.RegisterGeneric(typeof(IdentityGenericRepositoryEF<>)).As(typeof(IIdentityGenericRepository<>));

            // NHibernate
            //containerBuilder.RegisterType<IdentityUnitOfWorkEF>().As<IIdentityUnitOfWork>();
            //containerBuilder.RegisterGeneric(typeof(IdentityGenericRepositoryEF<>)).As(typeof(IIdentityGenericRepository<>));
        }
    }
}