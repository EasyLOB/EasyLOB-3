using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace EasyLOB
{
    /// <summary>
    /// IAuthenticationManager.
    /// </summary>
    public interface IAuthenticationManager : IDisposable
    {
        #region Properties

        /// <summary>
        /// Is administrator ?
        /// </summary>
        bool IsAdministrator { get; }

        /// <summary>
        /// Is authenticated ?
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Principal.
        /// </summary>
        IPrincipal Principal { get; }

        /// <summary>
        /// Roles.
        /// </summary>
        List<string> Roles { get; }

        /// <summary>
        /// User name.
        /// </summary>
        string UserName { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Is in role.
        /// </summary>
        /// <param name="role">Role name</param>
        /// <returns></returns>
        bool IsInRole(string role);

        #endregion Methods
    }
}