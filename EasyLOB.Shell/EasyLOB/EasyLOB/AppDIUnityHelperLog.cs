using EasyLOB.Log;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupLog()
        {
            // DIHelper
            //Container.RegisterType(typeof(ILogManager), typeof(LogManagerMock), AppLifetimeManager);
            Container.RegisterType(typeof(ILogManager), typeof(LogManagerNLog), AppLifetimeManager);
        }
    }
}