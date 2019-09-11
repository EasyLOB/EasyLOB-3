using FluentNHibernate.Mapping;
using EasyLOB.Identity.Data;

namespace EasyLOB.Identity.Persistence
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            #region Class

            Table("AspNetRoles");

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

            Map(x => x.Discriminator)
                .Column("Discriminator")
                .CustomSqlType("varchar")
                .Length(128)
                .Not.Nullable();

            #endregion Properties

            #region Collections (PK)

            HasMany(x => x.UserRoles)
                .KeyColumn("RoleId");

            #endregion Collections (PK)
        }
    }
}