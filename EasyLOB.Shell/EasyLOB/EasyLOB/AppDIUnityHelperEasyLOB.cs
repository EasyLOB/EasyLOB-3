using EasyLOB.Application;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupEasyLOB()
        {
            Container.RegisterType(typeof(IEasyLOBApplication), typeof(EasyLOBApplication), AppLifetimeManager);
        }
    }
}