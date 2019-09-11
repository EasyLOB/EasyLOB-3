using System.Linq;
using EasyLOB.Activity.Data;
using EasyLOB.Persistence;

namespace EasyLOB.Activity.Persistence
{
    public class ActivityActivityRepositoryLINQ2DB : ActivityGenericRepositoryLINQ2DB<EasyLOB.Activity.Data.Activity>
    {
        #region Methods

        public ActivityActivityRepositoryLINQ2DB(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<EasyLOB.Activity.Data.Activity> Join(IQueryable<EasyLOB.Activity.Data.Activity> query)
        {
            return
                from activity in query
                select new EasyLOB.Activity.Data.Activity
                {
                    Id = activity.Id,
                    Name = activity.Name
                };
        }

        #endregion Methods
    }
}

