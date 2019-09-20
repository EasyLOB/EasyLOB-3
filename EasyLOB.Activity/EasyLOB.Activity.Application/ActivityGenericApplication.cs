using EasyLOB.Application;
using EasyLOB.Data;

namespace EasyLOB.Activity.Application
{
    public class ActivityGenericApplication<TEntity> : GenericApplication<TEntity>, IActivityGenericApplication<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public ActivityGenericApplication(IActivityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion Methods
    }
}