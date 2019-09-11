using EasyLOB.AuditTrail.Data;
using EasyLOB.Environment;
using System.Data.Entity;

namespace EasyLOB.AuditTrail.Persistence
{
    public partial class AuditTrailDbContext : DbContext
    {
        #region Properties

        //public DbSet<ModuleInfo> ModulesInfo { get; set; }

        public DbSet<AuditTrailConfiguration> AuditTrailConfigurations { get; set; }

        public DbSet<AuditTrailLog> AuditTrailLogs { get; set; }

        #endregion
        
        #region Methods
        
        static AuditTrailDbContext()
        {
            /*
            // Refer to <configuration><entityframework><contexts> section in Web.config or App.config
            //Database.SetInitializer<AuditTrailDbContext>(null);
            //Database.SetInitializer<AuditTrailDbContext>(new CreateDatabaseIfNotExists<AuditTrailDbContext>());
             */
        }

        public AuditTrailDbContext()
            //: base("Name=AuditTrail")
            : base("Name=" + MultiTenantHelper.GetConnectionName("AuditTrail"))
        {
            Setup();
        }

        //public AuditTrailDbContext(string connectionString)
        //    : base(connectionString)
        //{
        //    Setup();
        //}

        //public AuditTrailDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
        //    : base(objectContext, dbContextOwnsObjectContext)
        //{
        //    Setup();
        //}        

        //public AuditTrailDbContext(DbConnection connection)
        //    : base(connection, false)
        //{
        //    Setup();
        //}

        private void Setup()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.Log = null;
            //Database.Log = Console.Write;
            //Database.Log = log => EntityFrameworkHelper.Log(log, EasyLOB.Persistence.ZDatabaseLogger.File);
            //Database.Log = log => EntityFrameworkHelper.Log(log, EasyLOB.Persistence.ZDatabaseLogger.NLog);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ModuleInfo>().Map(t =>
            //{
            //    t.ToTable("ModuleInfo");
            //});

            modelBuilder.Configurations.Add(new AuditTrailConfigurationConfiguration());
            modelBuilder.Configurations.Add(new AuditTrailLogConfiguration());
        }
        
        #endregion
    }
}
