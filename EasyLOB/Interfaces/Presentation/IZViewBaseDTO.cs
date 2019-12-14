namespace EasyLOB
{
    /// <summary>
    /// IZViewBase.
    /// </summary>
    /// <typeparam name="TEntityView">View type</typeparam>
    /// <typeparam name="TEntityDTO">DTO type</typeparam>
    /// <typeparam name="TEntity">Data type</typeparam>
    public interface IZViewBase<TEntityView, TEntityDTO, TEntity>
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

        /// <summary>
        /// Convert DTO entity to view entity.
        /// </summary>
        /// <param name="dto">DTO entity</param>
        void FromDTO(IZDTOBase<TEntityDTO, TEntity> dto);

        /// <summary>
        /// Convert DTO entity to view entity.
        /// </summary>
        /// <param name="dto"></param>
        void FromDTO(TEntityDTO dto);

        void OnConstructor();

        /// <summary>
        /// Convert view entity to data entity.
        /// </summary>
        /// <returns></returns>
        IZDataBase ToData();

        /// <summary>
        /// Convert view entity to DTO entity.
        /// </summary>
        /// <returns></returns>
        TEntityDTO ToDTO();

        #endregion Methods
    }
}