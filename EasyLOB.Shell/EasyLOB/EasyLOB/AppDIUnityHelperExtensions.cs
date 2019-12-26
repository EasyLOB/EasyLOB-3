using EasyLOB.Extensions.Edm;
using EasyLOB.Extensions.Ini;
using EasyLOB.Extensions.Mail;
using Unity;
using Unity.Injection;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupExtensions(IUnityContainer container)
        {
            //container.RegisterType(typeof(IEdmManager), typeof(EdmManagerMock), AppLifetimeManager);
            container.RegisterType(typeof(IEdmManager), typeof(EdmManagerFileSystem), AppLifetimeManager, new InjectionConstructor());
            //container.RegisterType(typeof(IEdmManager), typeof(EdmFtpSystem), AppLifetimeManager, new InjectionConstructor());

            //container.RegisterType(typeof(IIniManager), typeof(IniManagerMock), AppLifetimeManager);
            container.RegisterType(typeof(IIniManager), typeof(IniManager), AppLifetimeManager, new InjectionConstructor());

            //container.RegisterType(typeof(IMailManager), typeof(MailManagerMock), AppLifetimeManager);
            container.RegisterType(typeof(IMailManager), typeof(MailManager), AppLifetimeManager, new InjectionConstructor());
        }
    }
}