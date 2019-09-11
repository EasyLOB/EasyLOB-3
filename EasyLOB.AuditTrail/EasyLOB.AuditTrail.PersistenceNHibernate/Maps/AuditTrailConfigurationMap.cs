using FluentNHibernate.Mapping;
using EasyLOB.AuditTrail.Data;

namespace EasyLOB.AuditTrail.Persistence
{
    public class AuditTrailConfigurationMap : ClassMap<AuditTrailConfiguration>
    {
        public AuditTrailConfigurationMap()
        {
            #region Class

            Table("EasyLOBAuditTrailConfiguration");

            Id(x => x.Id)
                .Column("Id")
                .CustomSqlType("int")
                .GeneratedBy.Identity()
                .Not.Nullable();            

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties
            
            Map(x => x.Domain)
                .Column("Domain")
                .CustomSqlType("varchar")
                .Length(256)
                .Not.Nullable();
            
            Map(x => x.Entity)
                .Column("Entity")
                .CustomSqlType("varchar")
                .Length(256)
                .Not.Nullable();
            
            Map(x => x.LogOperations)
                .Column("LogOperations")
                .CustomSqlType("varchar")
                .Length(256);
            
            Map(x => x.LogMode)
                .Column("LogMode")
                .CustomSqlType("varchar")
                .Length(1);

            #endregion Properties
        }
    }
}
