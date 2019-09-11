using Owin;

namespace EasyLOB.Identity
{
    public static class IdentityConfigurator
    {
        public static void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
        }
    }
}