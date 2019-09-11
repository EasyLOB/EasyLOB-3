using EasyLOB.Activity.Data;
using EasyLOB.Persistence;

namespace EasyLOB.Activity.Persistence
{
    public class ActivityUnitOfWorkLINQ2DB : UnitOfWorkLINQ2DB, IActivityUnitOfWork
    {
        #region Methods

        public ActivityUnitOfWorkLINQ2DB(IAuthenticationManager authenticationManager)
            : base(new ActivityLINQ2DB(), authenticationManager)
        {
            //Domain = "Activity"; // ???

            Repositories.Add(typeof(EasyLOB.Activity.Data.Activity), new ActivityActivityRepositoryLINQ2DB(this));            
            Repositories.Add(typeof(ActivityRole), new ActivityActivityRoleRepositoryLINQ2DB(this));            

            //ActivityLINQ2DB connection = (ActivityLINQ2DB)base.Connection;
        }

        public override IGenericRepository<TEntity> GetRepository<TEntity>()
        {
            if (!Repositories.Keys.Contains(typeof(TEntity)))
            {
                var repository = new ActivityGenericRepositoryLINQ2DB<TEntity>(this);
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
                    if (Connection != null)
                    {
                        Connection.Dispose();
                        Connection = null;
                    }
                }

                disposed = true;

                base.Dispose(disposing);
            }
        }

        #endregion Methods IDispose
    }
}

