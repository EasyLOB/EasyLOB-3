using EasyLOB.Library;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace EasyLOB.Persistence
{
    /// <summary>
    /// AdoNet Helper.
    /// </summary>
    public static partial class AdoNetHelper
    {
        #region Methods Properties

        /// <summary>
        /// Sequence prefix.
        /// </summary>
        public static string SequencePrefix
        {
            get { return ConfigurationHelper.AppSettings<string>("EasyLOB.AdoNet.SequencePrefix"); }
        }

        /// <summary>
        /// Records by Search.
        /// </summary>
        public static int RecordsBySearch
        {
            get { return ConfigurationHelper.AppSettings<int>("EasyLOB.AdoNet.RecordsBySearch"); }
        }

        #endregion Methods Properties

        #region Methods Connection

        /// <summary>
        /// Get connection.
        /// </summary>
        /// <param name="connectionName">Connection name</param>
        /// <returns></returns>
        public static DbConnection GetConnection(string connectionName)
        {
            DbProviderFactory provider = GetProvider(connectionName);
            DbConnection connection = provider.CreateConnection();
            connection.ConnectionString = GetConnectionString(connectionName);

            return connection;
        }

        /// <summary>
        /// Get connection string by connection name.
        /// </summary>
        /// <param name="connectionName">Connection name</param>
        /// <returns></returns>
        public static string GetConnectionString(string connectionName)
        {
            string connectionString = ConfigurationHelper.ConnectionStrings(connectionName);

            return connectionString;
        }

        /// <summary>
        /// Get connection user and password.
        /// </summary>
        /// <param name="connectionName">Connection name</param>
        /// <returns></returns>
        public static string[] GetUserPassword(string connectionName)
        {
            string[] result = new string[] { "", "" };

            string connectionString = ConfigurationHelper.ConnectionStrings(connectionName);
            string[] tokens = connectionString.Split(';');

            for (var i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                if (token.StartsWith("User ID"))
                {
                    result[0] = token.Substring(token.IndexOf("=") + 1);
                }

                if (token.StartsWith("Password"))
                {
                    result[1] = token.Substring(token.IndexOf("=") + 1);
                }
            }

            // using System.Linq;
            //string connectionString = LibraryHelper.ConnectionStrings(connectionName);
            //var tokens = connectionString.Split(';').Select(x => x.Split('='));
            //string userId = tokens.First(n => n[0].Equals("User ID").Select(x => x[1]);
            //string password = tokens.First(n => n[0].Equals("Password")).Select(x => x[1]);

            return result;
        }

        #endregion Methods Connection

        #region Methods DBMS

        /// <summary>
        /// Get ZDBMS.
        /// </summary>
        /// <param name="dbConnection">Connection</param>
        /// <returns></returns>
        public static ZDBMS GetDBMS(DbConnection dbConnection)
        {
            string connectionType = dbConnection.GetType().FullName;

            return GetDBMS(connectionType);
        }

        /// <summary>
        /// Get ZDBMS.
        /// </summary>
        /// <param name="provider">Provider</param>
        /// <returns></returns>
        public static ZDBMS GetDBMS(DbProviderFactory provider)
        {
            string providerType = provider.GetType().FullName;

            return GetDBMS(providerType);
            /*
            switch (providerType)
            {
                // "FirebirdSql.Data.FirebirdClient.FirebirdClientFactory"
                case "firebirdsql.data.firebirdclient.firebirdclientfactory":
                    return ZDBMS.Firebird;

                // "MySql.Data.MySqlClient.MySqlClientFactory"
                case "mysql.data.mysqlclient.mysqlclientfactory":
                    return ZDBMS.MySQL;

                // "Oracle.DataAccess.Client.OracleClientFactory"
                // "System.Data.OracleClient.OracleClientFactory"
                case "oracle.dataaccess.client.oracleclientfactory":
                case "system.data.oracleclient.oracleclientfactory":
                    return ZDBMS.Oracle;

                // "Npgsql.NpgsqlFactory":
                case "npgsql.npgsqlfactory":
                    return ZDBMS.PostgreSQL;

                // "System.Data.SQLite.SQLiteFactory"
                case "system.data.sqlite.sqlitefactory":
                    return ZDBMS.SQLite;

                // "System.Data.SqlClient.SqlClientFactory"
                case "system.data.sqlclient.sqlclientfactory":
                    return ZDBMS.SQLServer;

                default:
                    return ZDBMS.Unknown;
            }
            */
        }

        /// <summary>
        /// Get ZDBMS.
        /// </summary>
        /// <param name="connection">Connection name | Connection string | Connection provider</param>
        /// <returns></returns>
        public static ZDBMS GetDBMS(string connection)
        {
            connection = connection.ToLower();

            if (connection.Contains("firebirdsql"))
            {
                return ZDBMS.Firebird;
            }
            else if (connection.Contains("mysql"))
            {
                return ZDBMS.MySQL;
            }
            else if (connection.Contains("oracle"))
            {
                return ZDBMS.Oracle;
            }
            else if (connection.Contains("npgsql"))
            {
                return ZDBMS.PostgreSQL;
            }
            else if (connection.Contains("sqlite"))
            {
                return ZDBMS.SQLite;
            }
            else if (connection.Contains("sqlclient"))
            {
                return ZDBMS.SQLServer;
            }
            else
            {
                return ZDBMS.Unknown;
            }
        }

        #endregion Methods DBMS

        #region Methods DbType

        /// <summary>
        /// Get database type.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public static DbType GetDbType(Type type)
        {
            return GetDbType(type.Name);
        }

        /// <summary>
        /// Get database type.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public static DbType GetDbType(string type)
        {
            switch (type)
            {
                case "System.DateTime":
                    return DbType.DateTime;

                case "System.Decimal":
                    return DbType.Decimal;

                case "System.Double":
                    return DbType.Double;

                case "System.Guid":
                    return DbType.Guid;

                case "System.Int16":
                    return DbType.Int16;

                case "System.Int32":
                    return DbType.Int32;

                case "System.Int64":
                    return DbType.Int64;

                case "System.String":
                    return DbType.String;

                default:
                    return DbType.String;
            }
        }

        #endregion Methods DbType

        #region Methods Id & Sequence

        /// <summary>
        /// Get Id generated by DBMS SQL.
        /// </summary>
        /// <param name="dbms"></param>
        /// <returns></returns>
        public static string GetIdSql(ZDBMS dbms)
        {
            switch (dbms)
            {
                case ZDBMS.MySQL:
                    return ";SELECT LAST_INSERT_ID();";

                case ZDBMS.PostgreSQL:
                    return ";LASTVAL();";

                case ZDBMS.SQLServer:
                    return ";SELECT SCOPE_IDENTITY();";

                default:
                    return "";
            }
        }

        /// <summary>
        /// Get Sequence SQL.
        /// </summary>
        /// <param name="dbms"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string GetSequenceSql(ZDBMS dbms, string entity)
        {
            switch (dbms)
            {
                case ZDBMS.Firebird:
                    // Firebird Generators: CREATE GENERATOR Generator
                    return "SELECT GEN_ID(" + SequencePrefix + entity + ", 1) FROM RDB$DATABASE";

                case ZDBMS.Oracle:
                    // Oracle Sequences: CREATE SEQUENCE Sequence
                    return "SELECT " + SequencePrefix + entity + ".NEXTVAL FROM DUAL";

                case ZDBMS.PostgreSQL:
                    // PostgreSQL Sequences: CREATE SEQUENCE Sequence
                    return "SELECT NEXTVAL('" + SequencePrefix + entity + "')";

                default:
                    return "";
            }
        }

        /// <summary>
        /// Get Sequence generated by DBMS..
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static object GetSequence(string entity, string connectionName)
        {
            object value = null;

            DbConnection connection = null;

            try
            {
                DbProviderFactory provider = AdoNetHelper.GetProvider(connectionName);
                connection = provider.CreateConnection();
                connection.ConnectionString = AdoNetHelper.GetConnectionString(connectionName);
                connection.Open();

                DbCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = GetSequenceSql(GetDBMS(provider), entity);
                if (command.CommandText != "")
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    try
                    {
                        value = LibraryHelper.ObjectToInt32(command.ExecuteScalar());
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GetId", exception);
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            return value;
        }

        #endregion Methods Id & Sequence

        #region Methods Provider

        /// <summary>
        /// Get provider.
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static DbProviderFactory GetProvider(string connectionName)
        {
            string providerName = GetProviderName(connectionName);
            DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);

            return provider;
        }

        /// <summary>
        /// Get provider name.
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public static string GetProviderName(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ProviderName;
        }

        public static DateTime GetDateTime(DbProviderFactory provider)
        {
            DateTime now = DateTime.Now;
            ZDBMS db = GetDBMS(provider);
            switch (db)
            {
                case ZDBMS.Firebird:
                    return now;

                case ZDBMS.MySQL:
                    return new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);

                case ZDBMS.Oracle:
                    return now;

                case ZDBMS.PostgreSQL:
                    return now;

                case ZDBMS.SQLite:
                    return now;

                case ZDBMS.SQLServer:
                    return now;

                default:
                    return now;
            }
        }

        #endregion Methods Provider

        #region Methods SQL

        /// <summary>
        /// Convert "#" parameter token to database specific parameter token.
        /// </summary>
        /// <param name="command">Database command</param>
        /// <param name="provider">Database provider</param>
        public static void SqlParameters(DbCommand command, DbProviderFactory provider)
        {
            ZDBMS db = GetDBMS(provider);
            switch (db)
            {
                case ZDBMS.Firebird:
                    command.CommandText = command.CommandText.Replace("#", "@");
                    command.CommandText = command.CommandText.Replace("@Value IS NULL", "CAST(@Value AS VARCHAR(10)) IS NULL");

                    foreach (DbParameter parameter in command.Parameters)
                    {
                        parameter.ParameterName = parameter.ParameterName.Replace("#", "@");
                    }

                    break;

                case ZDBMS.MySQL:
                    command.CommandText = command.CommandText.Replace("#", "@");

                    foreach (DbParameter parameter in command.Parameters)
                    {
                        parameter.ParameterName = parameter.ParameterName.Replace("#", "@");
                    }

                    break;

                case ZDBMS.Oracle:
                    command.CommandText = command.CommandText.Replace("#", ":");

                    foreach (DbParameter parameter in command.Parameters)
                    {
                        parameter.ParameterName = parameter.ParameterName.Replace("#", ":");
                    }

                    if (provider.GetType().FullName == "Oracle.DataAccess.Client.OracleClientFactory")
                    {
                        //((OracleCommand)command).BindByName = true;
                        command.GetType().GetProperty("BindByName").SetValue(command, true, null);
                    }

                    break;

                case ZDBMS.PostgreSQL:
                    command.CommandText = command.CommandText.Replace("#", ":");

                    foreach (DbParameter parameter in command.Parameters)
                    {
                        parameter.ParameterName = parameter.ParameterName.Replace("#", ":");
                    }

                    break;

                case ZDBMS.SQLite:
                    command.CommandText = command.CommandText.Replace("#", "@");

                    foreach (DbParameter parameter in command.Parameters)
                    {
                        parameter.ParameterName = parameter.ParameterName.Replace("#", "@");
                    }

                    break;

                case ZDBMS.SQLServer:
                    command.CommandText = command.CommandText.Replace("#", "@");

                    foreach (DbParameter parameter in command.Parameters)
                    {
                        parameter.ParameterName = parameter.ParameterName.Replace("#", "@");
                    }

                    break;
            }
        }

        /// <summary>
        /// Get SQL parameter token.
        /// </summary>
        /// <param name="provider">Database provider</param>
        /// <returns></returns>
        public static string SqlParameterToken(DbProviderFactory provider)
        {
            string parameter;

            ZDBMS db = GetDBMS(provider);
            switch (db)
            {
                case ZDBMS.Firebird:
                    parameter = "@";
                    break;

                case ZDBMS.MySQL:
                    parameter = "@";
                    break;

                case ZDBMS.Oracle:
                    parameter = ":";
                    break;

                case ZDBMS.PostgreSQL:
                    parameter = ":";
                    break;

                case ZDBMS.SQLite:
                    parameter = "@";
                    break;

                case ZDBMS.SQLServer:
                    parameter = "@";
                    break;

                default:
                    parameter = "";
                    break;
            }

            return parameter;
        }

        /// <summary>
        /// Get SQL limited by N records.
        /// </summary>
        /// <param name="command">Database command</param>
        /// <param name="provider">Database provider</param>
        public static void SqlRecords(DbCommand command, DbProviderFactory provider)
        {
            SqlRecords(command, provider, RecordsBySearch);
        }

        /// <summary>
        /// Get SQL limited by N records.
        /// </summary>
        /// <param name="command">Database command</param>
        /// <param name="provider">Database provider</param>
        /// <param name="records">Records</param>
        public static void SqlRecords(DbCommand command, DbProviderFactory provider, int? records)
        {
            if (records == null || records <= 0)
            {
                records = RecordsBySearch;
            }

            if (records != Int32.MaxValue)
            {
                ZDBMS db = GetDBMS(provider);
                switch (db)
                {
                    case ZDBMS.Firebird:
                        if (!command.CommandText.Contains(" FIRST "))
                        {
                            command.CommandText = command.CommandText.ReplaceFirst("SELECT ", "SELECT FIRST " + records.ToString() + " ");
                        }
                        break;

                    case ZDBMS.MySQL:
                        if (!command.CommandText.Contains(" LIMIT "))
                        {
                            command.CommandText = command.CommandText + " LIMIT " + records.ToString();
                        }
                        break;

                    case ZDBMS.Oracle:
                        if (!command.CommandText.Contains(" ROWNUM <"))
                        {
                            command.CommandText = "SELECT * FROM (" + command.CommandText + ") WHERE ROWNUM <= " + records.ToString();
                        }
                        break;

                    case ZDBMS.PostgreSQL:
                        if (!command.CommandText.Contains(" LIMIT "))
                        {
                            command.CommandText = command.CommandText + " LIMIT " + records.ToString();
                        }
                        break;

                    case ZDBMS.SQLite:
                        if (!command.CommandText.Contains(" LIMIT "))
                        {
                            command.CommandText = "SELECT * FROM (" + command.CommandText + ") ORDER BY ROWID ASC LIMIT " + records.ToString();
                        }
                        break;

                    case ZDBMS.SQLServer:
                        if (!command.CommandText.Contains(" TOP "))
                        {
                            command.CommandText = command.CommandText.ReplaceFirst("SELECT ", "SELECT TOP " + records.ToString() + " ");
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Get isolation level SQL.
        /// </summary>
        /// <param name="dbms">DBMS</param>
        /// <param name="isolationLevel">Isolation level</param>
        /// <returns></returns>
        public static string SqlIsolationLevel(ZDBMS dbms, IsolationLevel isolationLevel)
        {
            string result = "";

            switch(dbms)
            {
                case ZDBMS.SQLServer:

                    // SET TRANSACTION ISOLATION LEVEL (Transact-SQL)
                    // https://docs.microsoft.com/en-us/sql/t-sql/statements/set-transaction-isolation-level-transact-sql?view=sql-server-2017

                    if (isolationLevel == IsolationLevel.ReadUncommitted)
                    {
                        result = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED";
                    }

                    break;
            }

            return result;
        }

        #endregion Methods SQL
    }
}