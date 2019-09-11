using EasyLOB.Data;
using NHibernate;
using NHibernate.Connection;
using System.Data;

namespace EasyLOB.Persistence
{
    public static class IDbContextExtensions
    {
        public static IDbConnection GetConnection(this ISession session)
        {
            IConnectionProvider provider = (session.SessionFactory as NHibernate.Engine.ISessionFactoryImplementor).ConnectionProvider;
            IDbConnection connection = provider.GetConnection();

            return connection;
        }

        public static ZDBMS GetDBMS(this ISession session)
        {
            ZDBMS dbms;

            string connectionType = session.GetConnection().GetType().Name;
            //string connectionType = session.GetConnection().GetType().FullName;
            switch (connectionType)
            {
                //case "":
                //    dbms = ZDBMS.Firebird;
                //    break;

                case "MySqlConnection":
                    //case "MySql.Data.MySqlClient.MySqlConnection"
                    dbms = ZDBMS.MySQL;
                    break;

                //case "":
                //    db = ZDBMS.Oracle;
                //    break;

                //case "":
                //    dbms = ZDBMS.PostgreSQL;
                //    break;

                case "SqlConnection":
                    //case "System.Data.SqlClient.SqlConnection":
                    dbms = ZDBMS.SQLServer;
                    break;

                default:
                    dbms = ZDBMS.Unknown;
                    break;
            }

            return dbms;
        }
    }
}