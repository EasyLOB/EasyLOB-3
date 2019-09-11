using EasyLOB.Log;
using System.IO;

namespace EasyLOB.Persistence
{
    /// <summary>
    /// Entity Framework Helper.
    /// </summary>
    public static partial class EntityFrameworkHelper
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
                            string filePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/EntityFramework.log";
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
}