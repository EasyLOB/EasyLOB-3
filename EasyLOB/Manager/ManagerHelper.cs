namespace EasyLOB
{
    /// <summary>
    /// Manager helper.
    /// </summary>
    public static class ManagerHelper
    {
        #region Properties

        /// <summary>
        /// DI manager
        /// </summary>
        public static IDIManager DIManager { get; private set; }

        /// <summary>
        /// Environment manager
        /// </summary>
        public static IEnvironmentManager EnvironmentManager { get; private set; }

        /// <summary>
        /// Log manager
        /// </summary>
        public static ILogManager LogManager { get; private set; }

        #endregion Properties

        #region Methods

        public static void Setup(IDIManager diManager,
            IEnvironmentManager environmentManager,
            ILogManager logManager)
        {
            DIManager = diManager;
            EnvironmentManager = environmentManager;
            LogManager = logManager;
        }

        #endregion Methods
    }
}