using Autofac;
using EasyLOB.Identity;
using EasyLOB.Identity.Application;
using EasyLOB.Identity.Persistence;
using EasyLOB.Security;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupIdentity()
        {
            ContainerBuilder.RegisterType<AuthenticationManagerMock>().As<IAuthenticationManager>().SingleInstance();
            //ContainerBuilder.RegisterType<AuthenticationManager>().As<IAuthenticationManager>();

            ContainerBuilder.RegisterGeneric(typeof(IdentityGenericApplication<>)).As(typeof(IIdentityGenericApplication<>)).SingleInstance();
            ContainerBuilder.RegisterGeneric(typeof(IdentityGenericApplicationDTO<,>)).As(typeof(IIdentityGenericApplicationDTO<,>)).SingleInstance();

            // Entity Framework
            ContainerBuilder.RegisterType<IdentityUnitOfWorkEF>().As<IIdentityUnitOfWork>().SingleInstance();
            ContainerBuilder.RegisterGeneric(typeof(IdentityGenericRepositoryEF<>)).As(typeof(IIdentityGenericRepository<>)).SingleInstance();

            // NHibernate
            //ContainerBuilder.RegisterType<IdentityUnitOfWorkEF>().As<IIdentityUnitOfWork>().SingleInstance();
            //ContainerBuilder.RegisterGeneric(typeof(IdentityGenericRepositoryEF<>)).As(typeof(IIdentityGenericRepository<>)).SingleInstance();
        }
    }
}