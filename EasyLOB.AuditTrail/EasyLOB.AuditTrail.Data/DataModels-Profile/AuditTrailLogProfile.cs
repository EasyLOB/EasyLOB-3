using EasyLOB.Data;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailLog
    {        
        #region Methods
        
        public static void OnSetupProfile(IZProfile profile)
        {
            profile.LINQOrderBy = "LogTime DESC";
        }

        #endregion Methods
    }
}

