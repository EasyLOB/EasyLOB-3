using Autofac;
using EasyLOB.Extensions.Edm;
using EasyLOB.Extensions.Ini;
using EasyLOB.Extensions.Mail;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupExtensions(ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterType<EdmManagerMock>().As<IEdmManager>();
            containerBuilder.RegisterType<EdmManagerFileSystem>().As<IEdmManager>();
            //containerBuilder.RegisterType<EdmManagerFTP>().As<IEdmManager>();

            //containerBuilder.RegisterType<IniManagerMock>().As<IIniManager>();
            containerBuilder.RegisterType<IniManager>().As<IIniManager>();

            //containerBuilder.RegisterType<MailManagerMock>().As<IMailManager>();
            containerBuilder.RegisterType<MailManager>().As<IMailManager>();
        }
    }
}