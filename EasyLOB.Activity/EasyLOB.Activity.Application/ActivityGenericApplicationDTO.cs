using EasyLOB.Application;
using EasyLOB.Data;

namespace EasyLOB.Activity.Application
{
    public class ActivityGenericApplicationDTO<TEntityDTO, TEntity> : GenericApplicationDTO<TEntityDTO, TEntity>, IActivityGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public ActivityGenericApplicationDTO(IActivityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion Methods
    }
}