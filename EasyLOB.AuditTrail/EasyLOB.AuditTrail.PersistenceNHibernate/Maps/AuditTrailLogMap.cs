using FluentNHibernate.Mapping;
using EasyLOB.AuditTrail.Data;

namespace EasyLOB.AuditTrail.Persistence
{
    public class AuditTrailLogMap : ClassMap<AuditTrailLog>
    {
        public AuditTrailLogMap()
        {
            #region Class

            Table("EasyLOBAuditTrailLog");

            Id(x => x.Id)
                .Column("Id")
                .CustomSqlType("int")
                .GeneratedBy.Identity()
                .Not.Nullable();            

            Not.LazyLoad(); // GetById() EntityProxy => Entity

            #endregion Class

            #region Properties
            
            Map(x => x.LogDate)
                .Column("LogDate")
                .CustomSqlType("datetime");
            
            Map(x => x.LogTime)
                .Column("LogTime")
                .CustomSqlType("datetime");
            
            Map(x => x.LogUserName)
                .Column("LogUserName")
                .CustomSqlType("varchar")
                .Length(256);
            
            Map(x => x.LogDomain)
                .Column("LogDomain")
                .CustomSqlType("varchar")
                .Length(256);
            
            Map(x => x.LogEntity)
                .Column("LogEntity")
                .CustomSqlType("varchar")
                .Length(256);
            
            Map(x => x.LogOperation)
                .Column("LogOperation")
                .CustomSqlType("varchar")
                .Length(1);
            
            Map(x => x.LogId)
                .Column("LogId")
                .CustomSqlType("varchar")
                .Length(4096);
            
            Map(x => x.LogEntityBefore)
                .Column("LogEntityBefore")
                .CustomSqlType("varchar")
                .Length(4096);
            
            Map(x => x.LogEntityAfter)
                .Column("LogEntityAfter")
                .CustomSqlType("varchar")
                .Length(4096);

            #endregion Properties
        }
    }
}
