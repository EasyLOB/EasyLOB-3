using Autofac;
using EasyLOB.Log;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupLog()
        {
            //ContainerBuilder.RegisterType<LogManagerMock>().As<ILogManager>().SingleInstance();
            ContainerBuilder.RegisterType<LogManagerNLog>().As<ILogManager>().SingleInstance();
        }
    }
}