using System;
using System.Data;
using System.Data.Common;

/*

System.Data.IsolationLevel

Chaos
  The pending changes from more highly isolated transactions cannot be overwritten.
ReadCommitted
  Shared locks are held while the data is being read to avoid dirty reads,
  but the data can be changed before the end of the transaction,
  resulting in non-repeatable reads or phantom data.
ReadUncommitted
  A dirty read is possible, meaning that no shared locks are issued
  and no exclusive locks are honored.
RepeatableRead
  Locks are placed on all data that is used in a query,
  preventing other users from updating the data.
  Prevents non-repeatable reads but phantom rows are still possible.
Serializable
  A range lock is placed on the DataSet,
  preventing other users from updating or inserting rows into the dataset
  until the transaction is complete.
Snapshot
  Reduces blocking by storing a version of data that one application can read
  while another is modifying the same data.
  Indicates that from one transaction you cannot see changes made in other transactions,
  even if you requery.
Unspecified

 */

namespace EasyLOB.Persistence
{
    /// <summary>
    /// DbCommand Extensions.
    /// </summary>
    public static class DbCommandExtensions
    {
        /// <summary>
        /// Add parameters with value.
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="parameterName">Parameter name</param>
        /// <param name="parameterValue">Parameter value</param>
        public static void AddParameterWithValue(this DbCommand command,
            string parameterName, object parameterValue)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;
            command.Parameters.Add(parameter);
        }

        /// <summary>
        /// Execute Reader.
        /// </summary>
        /// <param name="dbCommand">Command</param>
        /// <param name="isolationLevel">Isolation level</param>
        /// <returns>Data Reader</returns>
        public static DbDataReader ExecuteReader(this DbCommand dbCommand,
            IsolationLevel isolationLevel)
        {
            if (ConfigurationHelper.AppSettings<bool>("EasyLOB.AdoNet.IsolationLevel"))
            {
                ZDBMS dbms = AdoNetHelper.GetDBMS(dbCommand.Connection);
                string sql = AdoNetHelper.SqlIsolationLevel(dbms, isolationLevel);
                dbCommand.CommandText = (String.IsNullOrEmpty(sql) ? "" : sql + Environment.NewLine)
                    + dbCommand.CommandText;
            }

            return dbCommand.ExecuteReader();
        }

        /// <summary>
        /// Execute Reader.
        /// </summary>
        /// <param name="dbCommand">Command</param>
        /// <param name="commandBehavior">Command behavior</param>
        /// <param name="isolationLevel">Isolation level</param>
        /// <returns>Data Reader</returns>
        public static DbDataReader ExecuteReader(this DbCommand dbCommand,
            CommandBehavior commandBehavior,
            IsolationLevel isolationLevel)
        {
            if (isolationLevel == IsolationLevel.ReadUncommitted)
            {
                if (AdoNetHelper.GetDBMS(dbCommand.Connection) == ZDBMS.SQLServer)
                {
                    dbCommand.CommandText =
                        "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED" + Environment.NewLine
                        + dbCommand.CommandText;
                }
            }

            return dbCommand.ExecuteReader(commandBehavior);
        }

        /// <summary>
        /// Execute Scalar.
        /// </summary>
        /// <param name="dbCommand">Command</param>
        /// <param name="isolationLevel">Isolation level</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(this DbCommand dbCommand,
            IsolationLevel isolationLevel)
        {
            if (isolationLevel == IsolationLevel.ReadUncommitted)
            {
                if (AdoNetHelper.GetDBMS(dbCommand.Connection) == ZDBMS.SQLServer)
                {
                    dbCommand.CommandText =
                        "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED" + Environment.NewLine
                        + dbCommand.CommandText;
                }
            }

            return dbCommand.ExecuteScalar();
        }
    }
}
