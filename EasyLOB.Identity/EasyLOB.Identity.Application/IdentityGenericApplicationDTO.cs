using EasyLOB.Application;

namespace EasyLOB.Identity.Application
{
    public class IdentityGenericApplicationDTO<TEntityDTO, TEntity> : GenericApplicationDTO<TEntityDTO, TEntity>, IIdentityGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public IdentityGenericApplicationDTO(IIdentityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion Methods
    }
}