using EasyLOB.Environment;
using Newtonsoft.Json;

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

        #endregion Methods
    }
}