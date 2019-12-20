using EasyLOB.Log;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupLog(IUnityContainer container)
        {
            // DIHelper
            //container.RegisterType(typeof(ILogManager), typeof(LogManagerMock), AppLifetimeManager);
            container.RegisterType(typeof(ILogManager), typeof(LogManagerNLog), AppLifetimeManager);
        }
    }
}