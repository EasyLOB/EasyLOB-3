using System.Linq;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Persistence;

namespace EasyLOB.AuditTrail.Persistence
{
    public class AuditTrailAuditTrailConfigurationRepositoryLINQ2DB : AuditTrailGenericRepositoryLINQ2DB<AuditTrailConfiguration>
    {
        #region Methods

        public AuditTrailAuditTrailConfigurationRepositoryLINQ2DB(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<AuditTrailConfiguration> Join(IQueryable<AuditTrailConfiguration> query)
        {
            return
                from auditTrailConfiguration in query
                select new AuditTrailConfiguration
                {
                    Id = auditTrailConfiguration.Id,
                    Domain = auditTrailConfiguration.Domain,
                    Entity = auditTrailConfiguration.Entity,
                    LogOperations = auditTrailConfiguration.LogOperations,
                    LogMode = auditTrailConfiguration.LogMode
                };
        }

        #endregion Methods
    }
}

