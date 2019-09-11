using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Web;

namespace EasyLOB.Identity
{
    public static partial class IdentityHelperNH
    {
        #region Properties

        private static ApplicationRoleManager _roleManager = null;

        public static ApplicationRoleManager RoleManager
        {
            get
            {
                // System.ObjectDisposedException: Cannot access a disposed object
                // http://stackoverflow.com/questions/27337599/cannot-access-a-disposed-object-after-minor-code-modification
                //if (_roleManager == null) // ???
                //{
                    IOwinContext owinContext = HttpContext.Current.GetOwinContext();
                    _roleManager = owinContext.GetUserManager<ApplicationRoleManager>();
                //}

                return _roleManager;
            }
        }

        private static ApplicationUserManager _userManager = null;

        public static ApplicationUserManager UserManager
        {
            get
            {
                // System.ObjectDisposedException: Cannot access a disposed object
                // http://stackoverflow.com/questions/27337599/cannot-access-a-disposed-object-after-minor-code-modification
                //if (_userManager == null) // ???
                //{
                    IOwinContext owinContext = HttpContext.Current.GetOwinContext();
                    _userManager = owinContext.GetUserManager<ApplicationUserManager>();
                //}

                return _userManager;
            }
        }

        #endregion Properties

        #region Methods

        public static ApplicationRole GetRoleById(string id)
        {
            return RoleManager.FindById(id);
        }

        public static ApplicationRole GetRoleByName(string name)
        {
            return RoleManager.FindByName(name);
        }

        public static ApplicationUser GetUserById(string id)
        {
            return UserManager.FindById(id);
        }

        public static ApplicationUser GetUserByName(string name)
        {
            return UserManager.FindByName(name);
        }

        #endregion Methods
    }
}