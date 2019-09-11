using EasyLOB.Environment;
using EasyLOB.Identity.Data;
using System.Data.Entity;

namespace EasyLOB.Identity.Persistence
{
    public partial class IdentityDbContext : DbContext
    {
        #region Properties

        //public DbSet<ModuleInfo> ModulesInfo { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserClaim> UserClaims { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<User> Users { get; set; }

        #endregion Properties

        #region Methods

        static IdentityDbContext()
        {
            /*
            // Refer to <configuration><entityframework><contexts> section in Web.config or App.config
            //Database.SetInitializer<IdentityDbContext>(null);
            //Database.SetInitializer<IdentityDbContext>(new CreateDatabaseIfNotExists<IdentityDbContext>());
             */
        }

        public IdentityDbContext()
            //: base("Name=Identity")
            : base("Name=" + MultiTenantHelper.GetConnectionName("Identity"))
        {
            Setup();
        }

        //public IdentityDbContext(string connectionString)
        //    : base(connectionString)
        //{
        //    Setup();
        //}

        //public IdentityDbContext(ObjectContext objectContext, bool dbContextOwnsObjectContext)
        //    : base(objectContext, dbContextOwnsObjectContext)
        //{
        //    Setup();
        //}

        //public IdentityDbContext(DbConnection connection)
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

            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new UserClaimConfiguration());
            modelBuilder.Configurations.Add(new UserLoginConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }

        #endregion Methods
    }
}