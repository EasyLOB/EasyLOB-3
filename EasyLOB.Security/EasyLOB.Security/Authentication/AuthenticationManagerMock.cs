using System.Collections.Generic;
using System.Security.Principal;

namespace EasyLOB.Security
{
    public partial class AuthenticationManagerMock : IAuthenticationManager
    {
        #region Properties

        public bool IsAdministrator { get { return true; } }

        public bool IsAuthenticated { get { return true; } }

        public IPrincipal Principal { get { return null; } }

        public List<string> Roles { get { return new List<string>(); } }

        public string UserName { get { return ""; } }

        #endregion Properties

        #region Methods

        public virtual void Dispose()
        {
        }

        public bool IsInRole(string role)
        {
            return true;
        }

        #endregion Methods
    }
}