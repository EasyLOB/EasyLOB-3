using EasyLOB.Persistence;

namespace EasyLOB.AuditTrail.Persistence
{
    public class AuditTrailUnitOfWorkEF : UnitOfWorkEF, IAuditTrailUnitOfWork
    {
        #region Methods

        public AuditTrailUnitOfWorkEF(IAuthenticationManager authenticationManager)
            : base(new AuditTrailDbContext(), authenticationManager)
        {
            //Domain = "AuditTrail"; // ???

            //AuditTrailDbContext context = (AuditTrailDbContext)base.context;
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new AuditTrailGenericRepositoryEF<TEntity>(this);
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

