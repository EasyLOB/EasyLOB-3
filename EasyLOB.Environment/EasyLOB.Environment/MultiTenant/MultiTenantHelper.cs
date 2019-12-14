using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace EasyLOB.Environment
{
    /// <summary>
    /// Multitenant Helper.
    /// </summary>
    public static class MultiTenantHelper
    {
        #region Fields

        /// <summary>
        /// Session name.
        /// </summary>
        private static string _sessionName = "EasyLOB.MultiTenant";

        #endregion Fields

        #region Properties

        /// <summary>
        /// Has tenants ?
        /// </summary>
        public static bool HasTenants
        {
            get { return IsMultiTenant && Tenants != null ? true : false; }
        }

        /// <summary>
        /// Is multitenant ?
        /// </summary>
        public static bool IsMultiTenant
        {
            get { return ConfigurationHelper.AppSettings<bool>("EasyLOB.MultiTenant"); }
        }

        /// <summary>
        /// Tenant.
        /// </summary>
        public static AppTenant Tenant
        {
            get
            {
                string tenantName = DIHelper.EnvironmentManager.WebSubDomain;

                return GetTenant(String.IsNullOrEmpty(tenantName) ? TenantName : tenantName);
            }
        }

        private static string _tenantName = "";

        /// <summary>
        /// Tenant name.
        /// </summary>
        public static string TenantName
        {
            get
            {
                if (String.IsNullOrEmpty(_tenantName))
                {
                    _tenantName = DIHelper.EnvironmentManager.WebSubDomain;
                }

                return _tenantName;
            }
        }

        /// <summary>
        /// Tenants.
        /// </summary>
        public static List<AppTenant> Tenants
        {
            get
            {
                List<AppTenant> tenants = (List<AppTenant>)DIHelper.EnvironmentManager.SessionRead(_sessionName);
                if (tenants == null || tenants.Count == 0)
                {
                    try
                    {
                        string filePath = Path.Combine(DIHelper.EnvironmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                            "JSON/MultiTenant.json");
                        string json = File.ReadAllText(filePath);
                        tenants = JsonConvert.DeserializeObject<List<AppTenant>>(json);
                    }
                    catch { }
                    tenants = tenants ?? new List<AppTenant>();

                    DIHelper.EnvironmentManager.SessionWrite(_sessionName, tenants);
                }

                return tenants;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Setup.
        /// </summary>
        /// <param name="tenantName"></param>
        public static void Setup(string tenantName)
        {
            _tenantName = tenantName;
        }

        /// <summary>
        /// Get connection name.
        /// </summary>
        /// <param name="defaultConnectionName">Default connection name</param>
        /// <returns></returns>
        public static string GetConnectionName(string defaultConnectionName)
        {
            string result = defaultConnectionName;

            if (Tenant != null)
            {
                foreach (AppTenantConnection appTenantConnection in Tenant.Connections)
                {
                    if (appTenantConnection.Name == defaultConnectionName)
                    {
                        result = appTenantConnection.ConnectionName;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Get connection string.
        /// </summary>
        /// <param name="defaultConnectionName">Default connection string</param>
        /// <returns></returns>
        public static string GetConnectionString(string defaultConnectionName)
        {
            return ConfigurationHelper.ConnectionStrings(GetConnectionName(defaultConnectionName));
        }

        /// <summary>
        /// Get tenant by name.
        /// </summary>
        /// <param name="name">Tenant name</param>
        /// <returns></returns>
        public static AppTenant GetTenant(string name)
        {
            AppTenant appTenant = null;

            if (IsMultiTenant)
            {
                if (Tenants.Count > 0)
                {
                    name = name.ToLower();
                    foreach (AppTenant t in Tenants)
                    {
                        if (name.StartsWith(t.Name.ToLower()))
                        //if (t.Name.Equals(name, System.StringComparison.CurrentCultureIgnoreCase))
                        {
                            appTenant = t;
                            break;
                        }
                    }
                }
            }

            if (appTenant == null && Tenants.Count > 0)
            {
                appTenant = Tenants[0];
            }

            appTenant = appTenant ?? new AppTenant();

            return appTenant;
        }

        #endregion Methods
    }
}