using Autofac;
using EasyLOB.Environment;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        #region Properties

        private static ContainerBuilder _containerBuilder;

        public static ContainerBuilder ContainerBuilder
        {
            get { return _containerBuilder; }
        }

        private static IContainer _container;

        public static IContainer Container
        {
            get { return _container; }
        }

        #endregion Properties

        #region Methods

        public static void Setup(ContainerBuilder containerBuilder)
        {
            _containerBuilder = containerBuilder;

            SetupActivity();
            SetupAuditTrail();
            SetupEasyLOB();
            SetupExtensions();
            SetupIdentity();
            SetupLog();

            SetupApplication(); // !!!

            ContainerBuilder.RegisterType<EnvironmentManagerDesktop>().As<IEnvironmentManager>().SingleInstance();
            //ContainerBuilder.RegisterType<EnvironmentManagerWeb>().As<IEnvironmentManager>().SingleInstance();

            _container = _containerBuilder.Build();

            AppHelper.SetupMappers();
            AppHelper.SetupProfiles();

            ManagerHelper.Setup(new DIManagerAutofac(Container),
                Container.Resolve<IEnvironmentManager>(),
                Container.Resolve<ILogManager>());
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        #endregion Methods
    }
}