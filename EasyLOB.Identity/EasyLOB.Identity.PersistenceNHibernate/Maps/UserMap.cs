using FluentNHibernate.Mapping;
using EasyLOB.Identity.Data;

namespace EasyLOB.Identity.Persistence
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            #region Class

            Table("AspNetUsers");

            Id(x => x.Id)
                .Column("Id")
                .CustomSqlType("varchar")
                .GeneratedBy.Assigned()
                .Length(128)
                .Not.Nullable();

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties

            Map(x => x.Email)
                .Column("Email")
                .CustomSqlType("varchar")
                .Length(256);

            Map(x => x.EmailConfirmed)
                .Column("EmailConfirmed")
                .CustomSqlType("bit")
                .Not.Nullable();

            Map(x => x.PasswordHash)
                .Column("PasswordHash")
                .CustomSqlType("varchar")
                .Length(1024);

            Map(x => x.SecurityStamp)
                .Column("SecurityStamp")
                .CustomSqlType("varchar")
                .Length(1024);

            Map(x => x.PhoneNumber)
                .Column("PhoneNumber")
                .CustomSqlType("varchar")
                .Length(1024);

            Map(x => x.PhoneNumberConfirmed)
                .Column("PhoneNumberConfirmed")
                .CustomSqlType("bit")
                .Not.Nullable();

            Map(x => x.TwoFactorEnabled)
                .Column("TwoFactorEnabled")
                .CustomSqlType("bit")
                .Not.Nullable();

            Map(x => x.LockoutEndDateUtc)
                .Column("LockoutEndDateUtc")
                .CustomSqlType("datetime");

            Map(x => x.LockoutEnabled)
                .Column("LockoutEnabled")
                .CustomSqlType("bit")
                .Not.Nullable();

            Map(x => x.AccessFailedCount)
                .Column("AccessFailedCount")
                .CustomSqlType("int")
                .Not.Nullable();

            Map(x => x.UserName)
                .Column("UserName")
                .CustomSqlType("varchar")
                .Length(256)
                .Not.Nullable();

            #endregion Properties

            #region Collections (PK)

            HasMany(x => x.UserClaims)
                .KeyColumn("UserId");

            HasMany(x => x.UserLogins)
                .KeyColumn("UserId");

            HasMany(x => x.UserRoles)
                .KeyColumn("UserId");

            #endregion Collections (PK)
        }
    }
}