using EasyLOB.Environment;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace EasyLOB.Identity.Persistence
{
    public static class IdentityFactory
    {
        #region Fields

        private static object _lock = new object();

        #endregion Fields

        #region Properties

        //public static string ConnectionString { get { return "Identity"; } }
        public static string ConnectionString { get { return MultiTenantHelper.GetConnectionName("Identity"); } } // !?! Multi-Tenant

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
                            .ConnectionString(x => x.FromConnectionStringWithKey(ConnectionString)))
                        .ExposeConfiguration(x => new SchemaExport(x).Create(false, false))
                        .Mappings(x => x.FluentMappings
                            .Add<RoleMap>()
                            .Add<UserClaimMap>()
                            .Add<UserLoginMap>()
                            .Add<UserRoleMap>()
                            .Add<UserMap>()
                        )
                        //.Mappings(x => x.FluentMappings.AddFromAssemblyOf<?Map>())
                        //.Mappings(x => x.FluentMappings.AddFromAssembly(typeof(Activity.?Map).Assembly))
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

        #endregion Properties
    }
}