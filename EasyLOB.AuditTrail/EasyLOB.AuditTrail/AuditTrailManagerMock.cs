using EasyLOB.Data;

namespace EasyLOB.AuditTrail
{
    public class AuditTrailManagerMock : IAuditTrailManager
    {
        #region Methods

        public virtual void Dispose()
        {
        }

        public bool AuditTrail(ZOperationResult operationResult, string logUserName, string logDomain, string logEntity, string logOperation, IZDataBase entityBefore, IZDataBase entityAfter)
        {
            return true;
        }

        public bool IsAuditTrail(string logDomain, string logEntity, string logOperation, out string logMode)
        {
            logMode = "N";

            return false;
        }

        #endregion Methods
    }
}