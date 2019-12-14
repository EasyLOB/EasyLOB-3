using System;
using System.ComponentModel;
using System.Configuration;

namespace EasyLOB
{
    /// <summary>
    /// Configuration Helper.
    /// </summary>
    public static partial class ConfigurationHelper
    {
        #region Methods

        /// <summary>
        /// Get AppSettings by setting name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T AppSettings<T>(string name)
        {
            var appSetting = ConfigurationManager.AppSettings[name];
            var converter = TypeDescriptor.GetConverter(typeof(T));

            return (T)(converter.ConvertFromInvariantString(appSetting ?? ""));
        }

        /// <summary>
        /// Get ConnectionStrings by connection name.
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static string ConnectionStrings(string connectionName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            if (connectionString == null)
            {
                throw new Exception(String.Format("ConnectionStrings[\"{0}\"] = \"?\"", connectionString));
            }

            return connectionString;
        }

        #endregion Methods
    }
}