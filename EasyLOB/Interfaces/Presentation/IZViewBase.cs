namespace EasyLOB
{
    /// <summary>
    /// IZViewBase.
    /// </summary>
    /// <typeparam name="TEntityView">View type</typeparam>
    /// <typeparam name="TEntity">Data type</typeparam>
    public interface IZViewBase<TEntityView, TEntity>
    {
        #region Properties

        /// <summary>
        /// Lookup text.
        /// </summary>
        string LookupText { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Convert data entity to view entity.
        /// </summary>
        /// <param name="dataModel">Data entity</param>
        void FromData(IZDataBase dataModel);

        void OnConstructor();

        /// <summary>
        /// Convert view entity to data entity.
        /// </summary>
        /// <returns></returns>
        IZDataBase ToData();

        #endregion Methods
    }
}