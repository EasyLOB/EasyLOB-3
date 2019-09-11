using System.Collections.Generic;

namespace EasyLOB.Environment
{
    public class AppTenant
    {
        #region Properties

        public string Name { get; set; }

        public string Description { get; set; }

        public List<AppTenantConnection> Connections { get; set; }

        public string Custom { get; set; }

        #endregion Properties

        #region Methods

        public AppTenant()
        {
            Name = "";
            Description = "";
            Connections = new List<AppTenantConnection>();
            Custom = "";
        }

        #endregion Methods
    }

    public class AppTenantConnection
    {
        #region Properties

        public string Name { get; set; }

        public string ConnectionName { get; set; }

        #endregion Properties

        #region Methods

        public AppTenantConnection()
        {
            Name = "";
            ConnectionName = "";
        }

        #endregion Methods
    }
}