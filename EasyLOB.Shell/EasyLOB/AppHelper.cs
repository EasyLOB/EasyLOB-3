using AutoMapper;
using EasyLOB.Activity.Data;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Data;
using EasyLOB.Environment;
using EasyLOB.Identity.Data;
using Newtonsoft.Json;
using Unity;

namespace EasyLOB
{
    public static partial class AppHelper
    {
        #region Properties

        public static JsonSerializerSettings _jsonSettings;

        public static JsonSerializerSettings JsonSettings
        {
            get
            {
                if (_jsonSettings == null)
                {
                    _jsonSettings = new JsonSerializerSettings
                    {
                        Formatting = Formatting.None,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    };
                }

                return _jsonSettings;
            }
        }

        #endregion Properties

        #region Methods

        public static void Log(ZOperationResult operationResult, string url)
        {
            if (!operationResult.Ok)
            {
                string header =
                    url + System.Environment.NewLine
                    + MultiTenantHelper.Tenant.Name + System.Environment.NewLine
                    + ProfileHelper.Profile.UserName;
                (ManagerHelper.DIManager.GetService<ILogManager>()).OperationResult(operationResult, header);
            }
        }

        public static void Setup()
        {
            // AutoMapper
            SetupMappers();
            // Profile
            SetupProfiles();

            // Unity
            // EasyLOB.DIService
            AppDIUnityHelper.Setup(new UnityContainer());
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