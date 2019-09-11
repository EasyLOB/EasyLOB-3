using System.Linq;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Persistence;

namespace EasyLOB.AuditTrail.Persistence
{
    public class AuditTrailAuditTrailLogRepositoryLINQ2DB : AuditTrailGenericRepositoryLINQ2DB<AuditTrailLog>
    {
        #region Methods

        public AuditTrailAuditTrailLogRepositoryLINQ2DB(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<AuditTrailLog> Join(IQueryable<AuditTrailLog> query)
        {
            return
                from auditTrailLog in query
                select new AuditTrailLog
                {
                    Id = auditTrailLog.Id,
                    LogDate = auditTrailLog.LogDate,
                    LogTime = auditTrailLog.LogTime,
                    LogUserName = auditTrailLog.LogUserName,
                    LogDomain = auditTrailLog.LogDomain,
                    LogEntity = auditTrailLog.LogEntity,
                    LogOperation = auditTrailLog.LogOperation,
                    LogId = auditTrailLog.LogId,
                    LogEntityBefore = auditTrailLog.LogEntityBefore,
                    LogEntityAfter = auditTrailLog.LogEntityAfter
                };
        }

        #endregion Methods
    }
}

