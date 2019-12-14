using AutoMapper;

namespace EasyLOB
{
    /// <summary>
    /// DI Helper.
    /// </summary>
    public static class DIHelper
    {
        #region Properties

        /// <summary>
        /// DI Manager.
        /// </summary>
        public static IDIManager DIManager { get; private set; }

        /// <summary>
        /// Environment manager.
        /// </summary>
        public static IEnvironmentManager EnvironmentManager { get; private set; }

        /// <summary>
        /// Log manager.
        /// </summary>
        public static ILogManager LogManager { get; private set; }

        /// <summary>
        /// Mail manager.
        /// </summary>
        public static IMailManager MailManager { get; private set; }

        /// <summary>
        /// AutoMapper Mapper.
        /// </summary>
        public static IMapper Mapper { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Setup.
        /// </summary>
        /// <param name="diManager">DI Manager</param>
        /// <param name="environmentManager">Environment Manager</param>
        /// <param name="logManager">Log Manager</param>
        /// <param name="mailManager">Mail Manager</param>
        /// <param name="mapper">AutoMapper Mapper</param>
        public static void Setup(IDIManager diManager,
            IEnvironmentManager environmentManager,
            ILogManager logManager,
            IMailManager mailManager,
            IMapper mapper)
        {
            DIManager = diManager;
            EnvironmentManager = environmentManager;
            LogManager = logManager;
            MailManager = mailManager;
            Mapper = mapper;
        }

        #endregion Methods
    }
}