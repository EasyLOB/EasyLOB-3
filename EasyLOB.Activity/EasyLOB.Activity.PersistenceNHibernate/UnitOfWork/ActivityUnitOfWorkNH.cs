using EasyLOB.Persistence;

namespace EasyLOB.Activity.Persistence
{
    public class ActivityUnitOfWorkNH : UnitOfWorkNH, IActivityUnitOfWork
    {
        #region Methods

        public ActivityUnitOfWorkNH(IAuthenticationManager authenticationManager)
            : base(ActivityFactory.Session, authenticationManager)
        {
            //Domain = "Activity"; // ???

            //ISession session = base.Session;
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new ActivityGenericRepositoryNH<TEntity>(this);
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