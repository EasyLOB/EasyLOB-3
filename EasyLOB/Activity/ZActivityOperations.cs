namespace EasyLOB
{
    /// <summary>
    /// ZActivityOperations.
    /// </summary>
    public class ZActivityOperations
    {
        #region Properties

        /// <summary>
        /// Activity name.
        /// </summary>
        public string Activity { get; set; }

        /// <summary>
        /// Is Index ( open Grid from menu ) allowed ?
        /// </summary>
        public bool IsIndex { get; set; }

        /// <summary>
        /// Is Search ( open Grid from menu or lookup ) allowed ?
        /// </summary>
        public bool IsSearch { get; set; }

        /// <summary>
        /// Is Create allowed ?
        /// </summary>
        public bool IsCreate { get; set; }

        /// <summary>
        /// Is Read allowed ?
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// Is Update allowed ?
        /// </summary>
        public bool IsUpdate { get; set; }

        /// <summary>
        /// Is Delete allowed ?
        /// </summary>
        public bool IsDelete { get; set; }

        /// <summary>
        /// Is Export allowed ?
        /// </summary>
        public bool IsExport { get; set; }

        /// <summary>
        /// Is Task ( used for Tasks ) allowed ?
        /// </summary>
        public bool IsExecute { get; set; }

        #endregion Properties
    }
}
