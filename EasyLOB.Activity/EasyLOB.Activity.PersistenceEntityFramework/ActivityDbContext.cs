using EasyLOB.Activity.Data;
using EasyLOB.Environment;
using System.Data.Entity;

namespace EasyLOB.Activity.Persistence
{
    public partial class ActivityDbContext : DbContext
    {
        #region Properties

        //public DbSet<ModuleInfo> ModulesInfo { get; set; }

        public DbSet<EasyLOB.Activity.Data.Activity> Activities { get; set; }

        public DbSet<ActivityRole> ActivityRoles { get; set; }

        #endregion Properties

        #region Methods

        static ActivityDbContext()
        {
            /*
            // Refer to <configuration><entityframework><contexts> section in Web.config or App.config
            //Database.SetInitializer<ActivityDbContext>(null);
            //Database.SetInitializer<ActivityDbContext>(new CreateDatabaseIfNotExists<ActivityDbContext>());
             */
        }

        public ActivityDbContext()
            //: base("Name=Activity")
            : base("Name=" + MultiTenantHelper.GetConnectionName("Activity"))
        {
            Setup();
        }

        //public ActivityDbContext(string connectionString)
        //    : base(connectionString)
        //{
        //    Setup();
        //}

        //public ActivityDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
        //    : base(objectContext, dbContextOwnsObjectContext)
        //{
        //    Setup();
        //}

        //public ActivityDbContext(DbConnection connection)
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

            modelBuilder.Configurations.Add(new ActivityConfiguration());
            modelBuilder.Configurations.Add(new ActivityRoleConfiguration());
        }

        #endregion Methods
    }
}