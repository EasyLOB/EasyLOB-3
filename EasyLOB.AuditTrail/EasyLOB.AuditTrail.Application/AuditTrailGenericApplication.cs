using EasyLOB.Application;

namespace EasyLOB.AuditTrail.Application
{
    public class AuditTrailGenericApplication<TEntity>
        : GenericApplication<TEntity>, IAuditTrailGenericApplication<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public AuditTrailGenericApplication(IAuditTrailUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion Methods
    }
}
