using Autofac;
using EasyLOB.Extensions.Edm;
using EasyLOB.Extensions.Mail;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupExtensions()
        {
            //ContainerBuilder.RegisterType<EdmManagerMock>().As<IEdmManager>().SingleInstance();
            ContainerBuilder.RegisterType<EdmManagerFileSystem>().As<IEdmManager>().SingleInstance();
            //ContainerBuilder.RegisterType<EdmManagerFTP>().As<IEdmManager>().SingleInstance();

            //ContainerBuilder.RegisterType<IniManagerMock>().As<IIniManager>().SingleInstance();
            //ContainerBuilder.RegisterType<IniManager>().As<IIniManager>().SingleInstance();

            //ContainerBuilder.RegisterType<MailManagerMock>().As<IMailManager>().SingleInstance();
            ContainerBuilder.RegisterType<MailManager>().As<IMailManager>().SingleInstance();
        }
    }
}