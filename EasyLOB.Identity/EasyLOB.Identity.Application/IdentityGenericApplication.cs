using EasyLOB.Application;

namespace EasyLOB.Identity.Application
{
    public class IdentityGenericApplication<TEntity> : GenericApplication<TEntity>, IIdentityGenericApplication<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public IdentityGenericApplication(IIdentityUnitOfWork unitOfWork,
            IAuditTrailManager auditTrailManager,
            IAuthorizationManager authorizationManager)
            : base(unitOfWork, auditTrailManager, authorizationManager)
        {
        }

        #endregion Methods
    }
}