using System;

namespace EasyLOB
{
    /// <summary>
    /// IAuditTrailManager.
    /// </summary>
    public interface IAuditTrailManager : IDisposable
    {
        #region Methods

        /// <summary>
        /// Audit Trail.
        /// </summary>
        /// <param name="operationResult">Operation result</param>
        /// <param name="logUserName">User name</param>
        /// <param name="logDomain">Domain</param>
        /// <param name="logEntity">Entity</param>
        /// <param name="logOperation">Operation</param>
        /// <param name="entityBefore">Entity before operation</param>
        /// <param name="entityAfter">Entity after operation</param>
        /// <returns></returns>
        bool AuditTrail(ZOperationResult operationResult, string logUserName, string logDomain, string logEntity, string logOperation, IZDataBase entityBefore, IZDataBase entityAfter);

        /// <summary>
        /// Is Audit Trail enabled ?
        /// </summary>
        /// <param name="logDomain">Domain</param>
        /// <param name="logEntity">Entity</param>
        /// <param name="logOperation">Operation</param>
        /// <param name="logMode">Mode</param>
        /// <returns></returns>
        bool IsAuditTrail(string logDomain, string logEntity, string logOperation, out string logMode);

        #endregion Methods
    }
}