using EasyLOB.Application;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupEasyLOB(IUnityContainer container)
        {
            container.RegisterType(typeof(IEasyLOBApplication), typeof(EasyLOBApplication), AppLifetimeManager);
        }
    }
}