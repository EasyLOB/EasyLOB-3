using EasyLOB.Extensions.Ini;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace EasyLOB.Environment
{
    public static class ResourcesHelper
    {
        #region Properties

        private static IIniManager IniManagerDashboard { get; }

        private static IIniManager IniManagerMenu { get; }

        private static IIniManager IniManagerReport { get; }

        private static List<string> Namespaces { get; }

        #endregion Properties

        #region Methods

        static ResourcesHelper()
        {
            string iniPath;

            iniPath = Path.Combine(DIHelper.EnvironmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                "INI/DashboardResources.ini");
            IniManagerDashboard = DIHelper.DIManager.GetService<IIniManager>();
            IniManagerDashboard.Load(iniPath);

            iniPath = Path.Combine(DIHelper.EnvironmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                "INI/MenuResources.ini");
            IniManagerMenu = DIHelper.DIManager.GetService<IIniManager>();
            IniManagerMenu.Load(iniPath);

            iniPath = Path.Combine(DIHelper.EnvironmentManager.ApplicationPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration")),
                "INI/ReportResources.ini");
            IniManagerReport = DIHelper.DIManager.GetService<IIniManager>();
            IniManagerReport.Load(iniPath);

            Namespaces = new List<string>()
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
                Namespaces.Insert(0, r);
            }
        }

        public static string GetDashboardResource(string resourceKey)
        {
            return GetINIResource(IniManagerDashboard, resourceKey);
        }

        public static string GetMenuResource(string resourceKey)
        {
            return GetINIResource(IniManagerMenu, resourceKey);
        }

        public static string GetReportResource(string resourceKey)
        {
            return GetINIResource(IniManagerReport, resourceKey);
        }

        private static string GetINIResource(IIniManager iniManager, string resourceKey)
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

        public static string GetResource(string resourceClass, string resourceKey)
        {
            string result = "";

            Type type;
            foreach (string n in Namespaces)
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