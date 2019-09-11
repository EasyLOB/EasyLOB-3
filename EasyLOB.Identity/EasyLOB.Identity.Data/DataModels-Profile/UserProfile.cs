using EasyLOB.Data;

namespace EasyLOB.Identity.Data
{
    public partial class User
    {        
        #region Methods
        
        public static void OnSetupProfile(IZProfile profile)
        {
            profile.Lookup = "UserName";
            profile.LINQOrderBy = "UserName";
        }

        #endregion Methods
    }
}
