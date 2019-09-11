using EasyLOB.Data;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailConfiguration
    {        
        #region Methods
        
        public static void OnSetupProfile(IZProfile profile)
        {
            profile.Lookup = "Entity";
            profile.LINQOrderBy = "Entity";
        }

        #endregion Methods
    }
}
