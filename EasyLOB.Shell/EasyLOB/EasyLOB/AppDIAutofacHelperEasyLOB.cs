using Autofac;
using EasyLOB.Application;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupEasyLOB(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<EasyLOBApplication>().As<IEasyLOBApplication>();
        }
    }
}