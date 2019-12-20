using Autofac;
using EasyLOB.Log;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupLog(ContainerBuilder containerBuilder)
        {
            // DIHelper
            //containerBuilder.RegisterType<LogManagerMock>().As<ILogManager>();
            containerBuilder.RegisterType<LogManagerNLog>().As<ILogManager>();
        }
    }
}