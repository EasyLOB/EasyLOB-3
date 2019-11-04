using EasyLOB.Persistence;

namespace EasyLOB.Identity.Persistence
{
    public class IdentityGenericRepositoryEF<TEntity> : GenericRepositoryEF<TEntity>, IIdentityGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public IdentityGenericRepositoryEF(IIdentityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Context = (unitOfWork as IdentityUnitOfWorkEF).Context;
        }

        #endregion Methods
    }
}