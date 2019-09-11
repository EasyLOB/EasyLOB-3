using EasyLOB.Identity.Data;
using EasyLOB.Persistence;

namespace EasyLOB.Identity.Persistence
{
    public class IdentityUnitOfWorkEF : UnitOfWorkEF, IIdentityUnitOfWork
    {
        #region Methods

        public IdentityUnitOfWorkEF(IAuthenticationManager authenticationManager)
            : base(new IdentityDbContext(), authenticationManager)
        {
            //Domain = "Identity"; // ???

            //IdentityDbContext context = (IdentityDbContext)base.context;

            Repositories.Add(typeof(Role), new IdentityRoleRepository(this));
            Repositories.Add(typeof(User), new IdentityUserRepository(this));
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new IdentityGenericRepositoryEF<TEntity>(this);
                Repositories.Add(typeof(TEntity), repository);
            }

            return Repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
        }

        #endregion Methods

        #region Methods IDispose

        private bool disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (Context != null)
                    {
                        Context.Dispose();
                        Context = null;
                    }
                }

                disposed = true;

                base.Dispose(disposing);
            }
        }

        #endregion Methods IDispose
    }
}