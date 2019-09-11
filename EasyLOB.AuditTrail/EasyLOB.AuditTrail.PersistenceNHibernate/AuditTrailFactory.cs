using EasyLOB.Environment;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace EasyLOB.AuditTrail.Persistence
{
    public static class AuditTrailFactory
    {
        #region Fields

        private static object _lock = new object();

        #endregion Fields

        #region Properties

        //public static string ConnectionString { get { return "AuditTrail"; } }
        public static string ConnectionString { get { return MultiTenantHelper.GetConnectionName("AuditTrail"); } } // !?! Multi-Tenant

        private static ISessionFactory _sessionFactory = null;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration
                            .MsSql2008
                            .ConnectionString(x => x.FromConnectionStringWithKey(ConnectionString))
                        )
                        .ExposeConfiguration(x => new SchemaExport(x).Create(false, false))
                        .Mappings(x => x.FluentMappings
                            .Add<AuditTrailConfigurationMap>()
                            .Add<AuditTrailLogMap>()
                        )
                        //.Mappings(x => x.FluentMappings.AddFromAssemblyOf<?Map>())
                        //.Mappings(x => x.FluentMappings.AddFromAssembly(typeof(AuditTrail.?Map).Assembly))
                        //.Mappings(x => x.FluentMappings.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly()))
                        .BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        private static ISession _session = null;

        public static ISession Session
        {
            get
            {
                if (_session == null)
                {
                    lock (_lock) // Singleton
                    {
                        if (_session == null)
                        {
                            _session = SessionFactory.OpenSession();
                        }
                    }
                }

                return _session;
            }
        }

        #endregion
    }
}
