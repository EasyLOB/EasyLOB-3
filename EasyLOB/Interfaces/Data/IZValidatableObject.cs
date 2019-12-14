namespace EasyLOB
{
    /// <summary>
    /// IZValidatableObject.
    /// </summary>
    public interface IZValidatableObject
    {
        #region Methods

        /// <summary>
        /// Validate.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <returns></returns>
        bool Validate(ZOperationResult operationResult);

        #endregion Methods
    }
}