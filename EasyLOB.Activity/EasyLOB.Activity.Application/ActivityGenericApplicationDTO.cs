using EasyLOB.Application;

namespace EasyLOB.Activity.Application
{
    public class ActivityGenericApplicationDTO<TEntityDTO, TEntity> : GenericApplicationDTO<TEntityDTO, TEntity>, IActivityGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public ActivityGenericApplicationDTO(IActivityUnitOfWork unitOfWork,
            IAuditTrailManager auditTrailManager,
            IAuthorizationManager authorizationManager)
            : base(unitOfWork, auditTrailManager, authorizationManager)
        {
        }

        #endregion Methods
    }
}