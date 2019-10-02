using AutoMapper;
using EasyLOB.Activity.Data;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Data;
using EasyLOB.Identity.Data;

namespace EasyLOB
{
    public static partial class AppHelper
    {
        #region Methods

        public static void Setup()
        {
            // Unity
            AppDIUnityHelper.SetupMyLOB(); // !!!

            // AutoMapper
            SetupMappers();

            // Profile
            SetupProfiles();
        }

        public static void SetupMappers()
        {
            Mapper.Initialize(cfg => {
                // ZDataModel
                // Activity
                cfg.AddProfile<ActivityDataAutoMapper>();
                // Audit Trail
                cfg.AddProfile<AuditTrailDataAutoMapper>();
                // Identity
                cfg.AddProfile<IdentityDataAutoMapper>();
            });

            Mapper.Configuration.CompileMappings();
            Mapper.Configuration.AssertConfigurationIsValid();
        }

        public static void SetupProfiles()
        {
            // ZDataModel
            // Activity
            DataHelper.SetupDataProfile("EasyLOB.Activity.Data");
            // Audit Trail
            DataHelper.SetupDataProfile("EasyLOB.AuditTrail.Data");
            // Identity
            DataHelper.SetupDataProfile("EasyLOB.Identity.Data");
        }

        #endregion Methods
    }
}