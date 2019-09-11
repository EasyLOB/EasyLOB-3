using EasyLOB.Data;
using EasyLOB.Persistence;

namespace EasyLOB.Activity.Persistence
{
    public class ActivityGenericRepositoryEF<TEntity> : GenericRepositoryEF<TEntity>, IActivityGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public ActivityGenericRepositoryEF(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Context = (unitOfWork as ActivityUnitOfWorkEF).Context;
        }

        #endregion Methods
    }
}