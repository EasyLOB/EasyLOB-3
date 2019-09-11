using EasyLOB.Log;
using Newtonsoft.Json.Serialization;
using NHibernate.Proxy;
using System;
using System.IO;

// NHibernateContractResolver
// "Error getting value from 'DefaultValue' on 'NHibernate.Type.DateTimeOffsetType'."
// JsonSerializationException on lazy loaded nHibernate object in WebApi when called from Angularjs service
// http://stackoverflow.com/questions/25011406/jsonserializationexception-on-lazy-loaded-nhibernate-object-in-webapi-when-calle
// Global.asax.cs
// GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new NHibernateContractResolver();

namespace EasyLOB.Persistence
{
    /// <summary>
    /// NHibernate Helper.
    /// </summary>
    public static partial class NHibernateHelper
    {
        #region Methods

        /// <summary>
        /// Log
        /// </summary>
        /// <param name="log">Log message</param>
        /// <param name="databaseLogger">Database logger</param>
        public static void Log(string log, ZDatabaseLogger databaseLogger)
        {
            if (log != "\r\n")
            {
                switch (databaseLogger)
                {
                    case ZDatabaseLogger.File:
                        {
                            string filePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/NHibernate.log";
                            File.AppendAllText(filePath, log);
                        }
                        break;

                    case ZDatabaseLogger.NLog:
                        ILogManager logManager = new LogManagerNLog();
                        logManager.Trace(log);
                        break;
                }
            }
        }

        #endregion Methods
    }

    /// <summary>
    /// NHibernate Contract Resolver.
    /// </summary>
    public class NHibernateContractResolver : DefaultContractResolver // ???
    {
        /// <summary>
        /// Create contract from type
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        protected override JsonContract CreateContract(Type type)
        {
            if (typeof(INHibernateProxy).IsAssignableFrom(type))
            {
                return base.CreateContract(type.BaseType);
            }

            return base.CreateContract(type);
        }
    }
}