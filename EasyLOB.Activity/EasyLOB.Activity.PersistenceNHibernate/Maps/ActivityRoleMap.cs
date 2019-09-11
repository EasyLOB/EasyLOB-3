using FluentNHibernate.Mapping;
using EasyLOB.Activity.Data;

namespace EasyLOB.Activity.Persistence
{
    public class ActivityRoleMap : ClassMap<ActivityRole>
    {
        public ActivityRoleMap()
        {
            #region Class

            Table("EasyLOBActivityRole");

            CompositeId()
                .KeyProperty(x => x.ActivityId, "ActivityId")
                .KeyProperty(x => x.RoleName, "RoleName");

            #endregion Class

            #region Properties

            Map(x => x.Operations)
                .Column("Operations")
                .CustomSqlType("varchar")
                .Length(256);

            #endregion Properties

            #region Associations (FK)

            References(x => x.Activity)
                .Column("ActivityId");

            #endregion Associations (FK)
        }
    }
}