using EasyLOB.Extensions.Ini;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace EasyLOB.Environment
{
    public class ResourcesManager
    {
        #region Properties

        private IIniManager IniManagerDashboard { get; }

        private IIniManager IniManagerMenu { get; }

        private IIniManager IniManagerReport { get; }

        #endregion Properties

        #region Methods

        public ResourcesManager()
        {
            IniManagerDashboard =
                new IniManager(Path.Combine(DIHelper.EnvironmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                    "INI/DashboardResources.ini"));

            IniManagerMenu =
                new IniManager(Path.Combine(DIHelper.EnvironmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                    "INI/MenuResources.ini"));

            IniManagerReport =
                new IniManager(Path.Combine(DIHelper.EnvironmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                    "INI/ReportResources.ini"));
        }

        public string GetDashboardResource(string resourceKey)
        {
            return GetINIResource(IniManagerDashboard, resourceKey);
        }

        public string GetMenuResource(string resourceKey)
        {
            return GetINIResource(IniManagerMenu, resourceKey);
        }

        public string GetReportResource(string resourceKey)
        {
            return GetINIResource(IniManagerReport, resourceKey);
        }

        private string GetINIResource(IIniManager iniManager, string resourceKey)
        {
            string resourceValue = iniManager.Read(CultureInfo.CurrentCulture.Name, resourceKey);

            if (string.IsNullOrEmpty(resourceValue))
            {
                resourceValue = iniManager.Read("culture", resourceKey);
            }

            if (string.IsNullOrEmpty(resourceValue))
            {
                resourceValue = "? " + resourceKey.Trim() + " ?";
            }

            return resourceValue;
        }

        public string GetResource(string resourceClass, string resourceKey)
        {
            string result = "";

            List<string> namespaces = new List<string>()
            {
                "EasyLOB.Activity.Resources",
                "EasyLOB.Activity.Data.Resources",
                "EasyLOB.AuditTrail.Resources",
                "EasyLOB.AuditTrail.Data.Resources",
                "EasyLOB.Extensions.Edm.Resources",
                "EasyLOB.Identity.Resources",
                "EasyLOB.Identity.Data.Resources",
                "EasyLOB.Library.Resources",
                "EasyLOB.Library.Syncfusion.Resources",
                "EasyLOB.Log.Resources",
                "EasyLOB.Resources",
                "EasyLOB.Security.Resources"
            };

            string[] resources = ConfigurationHelper.AppSettings<string>("EasyLOB.Resources").Split(',');
            foreach (string r in resources.Reverse())
            {
                namespaces.Insert(0, r);
            }

            Type type;
            foreach (string n in namespaces)
            {
                type = LibraryHelper.GetType(n + "." + resourceClass);
                if (type != null)
                {
                    try
                    {
                        result = (string)LibraryHelper.GetStaticPropertyValue(type, resourceKey);

                        break;
                    }
                    catch { }
                }
            }

            return result;
        }

        #endregion Methods
    }
}