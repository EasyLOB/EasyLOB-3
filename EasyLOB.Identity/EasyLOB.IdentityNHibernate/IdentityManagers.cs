using EasyLOB.Environment;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using NHibernate;
using NHibernate.AdoNet;
using NHibernate.AspNet.Identity;
using NHibernate.AspNet.Identity.Helpers;
using NHibernate.Driver;
using System;
using System.Data;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EasyLOB.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>, IDisposable
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store)
            : base(store)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context) // ???
        {
            var entities = new[]
            {
                typeof(ApplicationRole)
            };
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration
                    .MsSql2008
                    //.ConnectionString(x => x.FromConnectionStringWithKey("Identity"))
                    .ConnectionString(x => x.FromConnectionStringWithKey(MultiTenantHelper.GetConnectionName("Identity"))) // !?! Multi-Tenant
                    .Driver<SqlClientDriverEasyLOB>
                )
                .ExposeConfiguration(x =>
                {
                    x.AddDeserializedMapping(MappingHelper.GetIdentityMappings(entities), null);
                })
                ;
            ISessionFactory factory = configuration.BuildSessionFactory();
            ISession session = factory.OpenSession();

            return new ApplicationRoleManager(new RoleStore<ApplicationRole>(session));
        }
    }

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, Microsoft.Owin.Security.IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) // ???
        {
            var entities = new[]
            {
                typeof(ApplicationUser)
            };
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration
                    .MsSql2008
                    //.ConnectionString(x => x.FromConnectionStringWithKey("Identity"))
                    .ConnectionString(x => x.FromConnectionStringWithKey(MultiTenantHelper.GetConnectionName("Identity"))) // !?! Multi-Tenant
                    .Driver<SqlClientDriverEasyLOB>
                )
                .ExposeConfiguration(x =>
                {
                    x.AddDeserializedMapping(MappingHelper.GetIdentityMappings(entities), null);
                })
                ;
            ISessionFactory factory = configuration.BuildSessionFactory();
            ISession session = factory.OpenSession();

            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(session));

            manager.PasswordValidator = new CustomPasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true
            };

            manager.UserValidator = new CustomUserValidator(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();

            return manager;
        }
    }

    public class SqlClientDriverEasyLOB : SqlClientDriver, IEmbeddedBatcherFactoryProvider // ???
    {
        // This method is similar to the OnBeforePrepare(IDbCommand) but, instead be called just before execute the command(that can be a batch) is executed before add each single command to the batcher and before OnBeforePrepare(IDbCommand).
        // If you have to adjust parameters values/type(when the command is full filled) this is a good place where do it.
        //public override void AdjustCommand(IDbCommand command)
        //{
        //    base.AdjustCommand(command);
        //}

        protected override void OnBeforePrepare(IDbCommand command)
        {
            command.CommandText = command.CommandText
                .Replace(" ApplicationUser", " AspNetUsers")
                .Replace(" ApplicationRole", " AspNetRoles");
            base.OnBeforePrepare(command);
        }
    }
}