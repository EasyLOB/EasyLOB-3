using Autofac;
using EasyLOB.Log;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupLog()
        {
            // DIHelper
            //ContainerBuilder.RegisterType<LogManagerMock>().As<ILogManager>();
            ContainerBuilder.RegisterType<LogManagerNLog>().As<ILogManager>();
        }
    }
}