namespace EasyLOB
{
    /// <summary>
    /// IDIManager.
    /// </summary>
    public interface IDIManager
    {
        #region Methods

        /// <summary>
        /// Get service
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns></returns>
        T GetService<T>();

        #endregion Methods
    }
}
