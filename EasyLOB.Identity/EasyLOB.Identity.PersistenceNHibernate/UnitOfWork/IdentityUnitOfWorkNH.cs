using EasyLOB.Identity.Data;
using EasyLOB.Persistence;

namespace EasyLOB.Identity.Persistence
{
    public class IdentityUnitOfWorkNH : UnitOfWorkNH, IIdentityUnitOfWork
    {
        #region Methods

        public IdentityUnitOfWorkNH(IAuthenticationManager authenticationManager)
            : base(IdentityFactory.Session, authenticationManager)
        {
            //Domain = "Identity"; // ???

            //ISession session = base.Session;

            Repositories.Add(typeof(Role), new IdentityRoleRepository(this));
            Repositories.Add(typeof(User), new IdentityUserRepository(this));
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new IdentityGenericRepositoryNH<TEntity>(this);
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
                    if (Session != null)
                    {
                        Session.Dispose();
                        Session = null;
                    }
                }

                disposed = true;

                base.Dispose(disposing);
            }
        }

        #endregion Methods IDispose
    }
}