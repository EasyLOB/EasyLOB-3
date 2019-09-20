using EasyLOB.Application;

namespace EasyLOB.AuditTrail.Application
{
    public class AuditTrailGenericApplicationDTO<TEntityDTO, TEntity>
        : GenericApplicationDTO<TEntityDTO, TEntity>, IAuditTrailGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public AuditTrailGenericApplicationDTO(IAuditTrailUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion Methods
    }
}