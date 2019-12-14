namespace EasyLOB.AuditTrail
{
    /// <summary>
    /// Audit Trail Helper.
    /// </summary>
    public static partial class AuditTrailHelper
    {
        #region Properties

        /// <summary>
        /// Is Audit Trail enabled ?
        /// </summary>
        public static bool IsAuditTrail
        {
            get
            {
                return ConfigurationHelper.AppSettings<bool>("EasyLOB.AuditTrail");
            }
        }

        #endregion Properties
    }
}