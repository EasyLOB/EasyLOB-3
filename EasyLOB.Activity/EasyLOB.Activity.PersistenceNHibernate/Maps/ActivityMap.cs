using FluentNHibernate.Mapping;
using EasyLOB.Activity.Data;

namespace EasyLOB.Activity.Persistence
{
    public class ActivityMap : ClassMap<EasyLOB.Activity.Data.Activity>
    {
        public ActivityMap()
        {
            #region Class

            Table("EasyLOBActivity");

            Id(x => x.Id)
                .Column("Id")
                .CustomSqlType("varchar")
                .GeneratedBy.Assigned()
                .Length(128)
                .Not.Nullable();

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties

            Map(x => x.Name)
                .Column("Name")
                .CustomSqlType("varchar")
                .Length(256)
                .Not.Nullable();

            #endregion Properties


            #region Collections (PK)

            HasMany(x => x.ActivityRoles)
                .KeyColumn("ActivityId");

            #endregion Collections (PK)
        }
    }
}