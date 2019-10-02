using EasyLOB.Extensions.Edm;
using EasyLOB.Extensions.Mail;
using Unity;
using Unity.Injection;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupExtensions()
        {
            //Container.RegisterType(typeof(IEdmManager), typeof(EdmManagerMock), AppLifetimeManager);
            Container.RegisterType(typeof(IEdmManager), typeof(EdmManagerFileSystem), AppLifetimeManager, new InjectionConstructor());
            //Container.RegisterType(typeof(IEdmManager), typeof(EdmFtpSystem), AppLifetimeManager, new InjectionConstructor());

            //Container.RegisterType(typeof(IIniManager), typeof(IniManagerMock), AppLifetimeManager);
            //Container.RegisterType(typeof(IIniManager), typeof(IniManager), AppLifetimeManager, new InjectionConstructor());

            //Container.RegisterType(typeof(IMailManager), typeof(MailManagerMock), AppLifetimeManager);
            Container.RegisterType(typeof(IMailManager), typeof(MailManager), AppLifetimeManager, new InjectionConstructor());
        }
    }
}