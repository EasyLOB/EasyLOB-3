using EasyLOB.Activity.Data;
using EasyLOB.Persistence;

namespace EasyLOB.Activity.Persistence
{
    public class ActivityUnitOfWorkEF : UnitOfWorkEF, IActivityUnitOfWork
    {     
        #region Methods

        public ActivityUnitOfWorkEF(IAuthenticationManager authenticationManager)
            : base(new ActivityDbContext(), authenticationManager)
        {
            //Domain = "Activity"; // ???

            //ActivityDbContext context = (ActivityDbContext)base.context;
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new ActivityGenericRepositoryEF<TEntity>(this);
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