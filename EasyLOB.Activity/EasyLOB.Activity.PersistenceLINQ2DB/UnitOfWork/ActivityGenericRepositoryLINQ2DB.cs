using EasyLOB.Data;
using EasyLOB.Persistence;

namespace EasyLOB.Activity.Persistence
{
    public class ActivityGenericRepositoryLINQ2DB<TEntity> : GenericRepositoryLINQ2DB<TEntity>, IActivityGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public ActivityGenericRepositoryLINQ2DB(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Connection = (unitOfWork as ActivityUnitOfWorkLINQ2DB).Connection;
        }

        #endregion Methods
    }
}

