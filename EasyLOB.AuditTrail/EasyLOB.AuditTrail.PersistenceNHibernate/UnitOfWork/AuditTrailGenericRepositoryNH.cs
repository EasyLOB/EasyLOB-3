using EasyLOB.Data;
using EasyLOB.Persistence;

namespace EasyLOB.AuditTrail.Persistence
{
    public class AuditTrailGenericRepositoryNH<TEntity> : GenericRepositoryNH<TEntity>, IAuditTrailGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public AuditTrailGenericRepositoryNH(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Session = (unitOfWork as AuditTrailUnitOfWorkNH).Session;
        }

        #endregion Methods
    }
}

