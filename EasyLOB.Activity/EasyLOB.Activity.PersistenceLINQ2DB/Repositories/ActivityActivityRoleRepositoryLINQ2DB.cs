using System.Linq;
using EasyLOB.Activity.Data;
using EasyLOB.Persistence;

namespace EasyLOB.Activity.Persistence
{
    public class ActivityActivityRoleRepositoryLINQ2DB : ActivityGenericRepositoryLINQ2DB<ActivityRole>
    {
        #region Methods

        public ActivityActivityRoleRepositoryLINQ2DB(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public override IQueryable<ActivityRole> Join(IQueryable<ActivityRole> query)
        {
            return
                from activityRole in query
                join activity in UnitOfWork.GetQuery<EasyLOB.Activity.Data.Activity>() on activityRole.ActivityId equals activity.Id // INNER JOIN
                select new ActivityRole
                {
                    ActivityId = activityRole.ActivityId,
                    RoleName = activityRole.RoleName,
                    Operations = activityRole.Operations,
                    Activity = activity
                };
        }

        #endregion Methods
    }
}

