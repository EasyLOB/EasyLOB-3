using FluentNHibernate.Mapping;
using EasyLOB.Identity.Data;

namespace EasyLOB.Identity.Persistence
{
    public class UserClaimMap : ClassMap<UserClaim>
    {
        public UserClaimMap()
        {
            #region Class

            Table("AspNetUserClaims");

            Id(x => x.Id)
                .Column("Id")
                .CustomSqlType("int")
                .GeneratedBy.Identity()
                .Not.Nullable();

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties

            Map(x => x.UserId)
                .Column("UserId")
                .CustomSqlType("varchar")
                .Length(128)
                .Not.Nullable();

            Map(x => x.ClaimType)
                .Column("ClaimType")
                .CustomSqlType("varchar")
                .Length(1024);

            Map(x => x.ClaimValue)
                .Column("ClaimValue")
                .CustomSqlType("varchar")
                .Length(1024);

            #endregion Properties

            #region Associations (FK)

            References(x => x.User)
                .Column("UserId");

            #endregion Associations (FK)
        }
    }
}