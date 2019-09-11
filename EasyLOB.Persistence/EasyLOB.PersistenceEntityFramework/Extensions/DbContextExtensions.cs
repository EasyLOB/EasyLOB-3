using EasyLOB.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

// EntityKey Class
// https://msdn.microsoft.com/en-us/library/system.data.entitykey.aspx

// Working with Entity Keys
// https://msdn.microsoft.com/en-us/library/dd283139.aspx

namespace EasyLOB.Persistence
{
    public static class DbContextExtensions
    {
        public static IDbConnection GetConnection(this DbContext context)
        {
            IDbConnection connection = context.Database.Connection;

            return connection;
        }

        public static ZDBMS GetDBMS(this DbContext context)
        {
            ZDBMS dbms;

            string connectionType = context.GetConnection().GetType().Name;
            //string connectionType = context.GetConnection().GetType().FullName;
            switch (connectionType)
            {
                //case "":
                //    dbms = ZDBMS.Firebird;
                //    break;

                case "MySqlConnection": // "MySql.Data.MySqlClient.MySqlConnection"
                    dbms = ZDBMS.MySQL;
                    break;

                //case "":
                //    dbms = ZDBMS.Oracle;
                //    break;

                //case "":
                //    dbms = ZDBMS.PostgreSQL;
                //    break;

                case "SQLiteConnection": // System.Data.SQLite
                    dbms = ZDBMS.SQLite;
                    break;

                case "SqlConnection": // "System.Data.SqlClient.SqlConnection":
                    dbms = ZDBMS.SQLServer;
                    break;

                default:
                    dbms = ZDBMS.Unknown;
                    break;
            }

            return dbms;
        }

        public static IEnumerable<string> GetEntityKeyNames<TEntity>(this DbContext context)
            where TEntity : class, IZDataBase
        {
            var set = (context as IObjectContextAdapter).ObjectContext.CreateObjectSet<TEntity>();
            var entitySet = set.EntitySet;
            var keys = entitySet.ElementType.KeyMembers;

            return keys.Select(x => x.Name).ToList<string>();
        }

        public static IEnumerable<object> GetEntityKeyValues<TEntity>(this DbContext context, TEntity entity)
          where TEntity : class, IZDataBase
        {
            var type = typeof(TEntity);
            var set = (context as IObjectContextAdapter).ObjectContext.CreateObjectSet<TEntity>();
            var entitySet = set.EntitySet;
            var keys = entitySet.ElementType.KeyMembers;
            var properties = keys.Select(x => type.GetProperty(x.Name));

            return properties.Select(x => x.GetValue(entity)).ToList<object>();
        }
    }
}