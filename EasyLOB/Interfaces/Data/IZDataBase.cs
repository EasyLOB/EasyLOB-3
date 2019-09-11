namespace EasyLOB
{
    /// <summary>
    /// IZDataBase.
    /// </summary>
    public interface IZDataBase
    {
        #region Properties

        /// <summary>
        /// Lookup text
        /// </summary>
        string LookupText { get; set; } // ??? "LookupText" could be read-only, but OData needs "set"

        #endregion Properties

        #region Methods

        /// <summary>
        /// Get entity Id
        /// </summary>
        /// <returns></returns>
        object[] GetId();

        /// <summary>
        /// On constructor ( called from Constructor )
        /// </summary>
        void OnConstructor();

        /// <summary>
        /// Set entity Id
        /// </summary>
        /// <param name="ids"></param>
        void SetId(object[] ids);

        #endregion Methods

        #region Triggers

        /// <summary>
        /// Before create "trigger"
        /// </summary>
        /// <param name="operationResult">Operation Result</param>
        /// <returns></returns>
        bool BeforeCreate(ZOperationResult operationResult);

        /// <summary>
        /// After create "trigger"
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool AfterCreate(ZOperationResult operationResult);

        /// <summary>
        /// Before delete "trigger"
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool BeforeDelete(ZOperationResult operationResult);

        /// <summary>
        /// After delete "trigger"
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool AfterDelete(ZOperationResult operationResult);

        /// <summary>
        /// Before update "trigger"
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool BeforeUpdate(ZOperationResult operationResult);

        /// <summary>
        /// After update "trigger"
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool AfterUpdate(ZOperationResult operationResult);

        #endregion Triggers
    }
}