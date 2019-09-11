using EasyLOB.Data;
using EasyLOB.Persistence;

namespace EasyLOB.Identity.Persistence
{
    public class IdentityGenericRepositoryNH<TEntity> : GenericRepositoryNH<TEntity>, IIdentityGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public IdentityGenericRepositoryNH(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Session = (unitOfWork as IdentityUnitOfWorkNH).Session;
        }

        #endregion Methods
    }
}