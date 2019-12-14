using Autofac;
using EasyLOB.Extensions.Edm;
using EasyLOB.Extensions.Ini;
using EasyLOB.Extensions.Mail;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupExtensions()
        {
            //ContainerBuilder.RegisterType<EdmManagerMock>().As<IEdmManager>();
            ContainerBuilder.RegisterType<EdmManagerFileSystem>().As<IEdmManager>();
            //ContainerBuilder.RegisterType<EdmManagerFTP>().As<IEdmManager>();

            //ContainerBuilder.RegisterType<IniManagerMock>().As<IIniManager>();
            ContainerBuilder.RegisterType<IniManager>().As<IIniManager>();

            // DIHelper
            //ContainerBuilder.RegisterType<MailManagerMock>().As<IMailManager>();
            ContainerBuilder.RegisterType<MailManager>().As<IMailManager>();
        }
    }
}