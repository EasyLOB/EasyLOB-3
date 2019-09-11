using System;
using System.Collections.Generic;
using System.Data;

namespace EasyLOB.Persistence
{
    /// <summary>
    /// Persistence Helper.
    /// </summary>
    public static partial class PersistenceHelper
    {
        #region Properties

        /// <summary>
        /// Is EasyLOB Transaction enabled ?
        /// </summary>
        public static bool IsTransaction
        {
            get
            {
                return ConfigurationHelper.AppSettings<bool>("EasyLOB.Transaction");
            }
        }

        /// <summary>
        /// Type to DbType conversion dictionary.
        /// </summary>
        public static Dictionary<Type, DbType> Type2DbType = new Dictionary<Type, DbType>()
        {
            { typeof(byte), DbType.Byte },
            { typeof(sbyte), DbType.SByte },
            { typeof(short), DbType.Int16 },
            { typeof(ushort), DbType.UInt16 },
            { typeof(int), DbType.Int32 },
            { typeof(uint), DbType.UInt32 },
            { typeof(long), DbType.Int64 },
            { typeof(ulong), DbType.UInt64 },
            { typeof(float), DbType.Single },
            { typeof(double), DbType.Double },
            { typeof(decimal), DbType.Decimal },
            { typeof(bool), DbType.Boolean },
            { typeof(string), DbType.String },
            { typeof(char), DbType.StringFixedLength },
            { typeof(Guid), DbType.Guid },
            { typeof(DateTime), DbType.DateTime },
            { typeof(DateTimeOffset), DbType.DateTimeOffset },
            { typeof(byte[]), DbType.Binary },
            { typeof(byte?), DbType.Byte },
            { typeof(sbyte?), DbType.SByte },
            { typeof(short?), DbType.Int16 },
            { typeof(ushort?), DbType.UInt16 },
            { typeof(int?), DbType.Int32 },
            { typeof(uint?), DbType.UInt32 },
            { typeof(long?), DbType.Int64 },
            { typeof(ulong?), DbType.UInt64 },
            { typeof(float?), DbType.Single },
            { typeof(double?), DbType.Double },
            { typeof(decimal?), DbType.Decimal },
            { typeof(bool?), DbType.Boolean },
            { typeof(char?), DbType.StringFixedLength },
            { typeof(Guid?), DbType.Guid },
            { typeof(DateTime?), DbType.DateTime },
            { typeof(DateTimeOffset?), DbType.DateTimeOffset }
            //{ typeof(System.Data.Linq.Binary), DbType.Binary }
        };

        #endregion Properties

        #region Methods DBMS

        /// <summary>
        /// Does DBMS generate Identity Ids ?
        /// </summary>
        /// <param name="database">Database</param>
        /// <returns>Generates ?</returns>
        public static bool GeneratesIdentity(ZDBMS database)
        {
            bool result;

            switch (database)
            {
                case ZDBMS.MySQL:
                case ZDBMS.SQLite:
                case ZDBMS.SQLServer:
                    result = true;
                    break;

                default:
                    result = false;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Does DBMS have Server-Side Joins ?
        /// </summary>
        /// <param name="database">Database</param>
        /// <returns>Has ?</returns>
        public static bool HasServerSideJoins(ZDBMS database)
        {
            bool result;

            switch (database)
            {
                case ZDBMS.Firebird:
                case ZDBMS.MySQL:
                case ZDBMS.Oracle:
                case ZDBMS.PostgreSQL:
                case ZDBMS.RavenDB:
                case ZDBMS.SQLite:
                case ZDBMS.SQLServer:
                    result = true;
                    break;

                default:
                    result = false;
                    break;
            }

            return result;
        }

        #endregion Methods DBMS
    }
}