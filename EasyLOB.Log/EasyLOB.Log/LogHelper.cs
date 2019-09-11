namespace EasyLOB.Log
{
    /// <summary>
    /// Log Helper.
    /// </summary>
    public static partial class LogHelper
    {
        #region Properties

        /// <summary>
        /// Is Log enabled ?
        /// </summary>
        public static bool IsLog
        {
            get
            {
                return ConfigurationHelper.AppSettings<bool>("EasyLOB.Log");
            }
        }

        #endregion Properties
    }
}