namespace EasyLOB
{
    /// <summary>
    /// IZDTOBase.
    /// </summary>
    /// <typeparam name="TEntityDTO">DTO type</typeparam>
    /// <typeparam name="TEntity">Data type</typeparam>
    public interface IZDTOBase<TEntityDTO, TEntity>
    {
        #region Properties

        /// <summary>
        /// Lookup text.
        /// </summary>
        string LookupText { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Convert data entity do DTO entity.
        /// </summary>
        /// <param name="dataModel">Data entity</param>
        void FromData(IZDataBase dataModel);

        /// <summary>
        /// Convert to data entity.
        /// </summary>
        /// <returns></returns>
        IZDataBase ToData();

        #endregion Methods
    }
}