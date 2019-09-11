using LinqToDB;
using LinqToDB.Data;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Environment;

namespace EasyLOB.AuditTrail.Persistence
{
    public class AuditTrailLINQ2DB : DataConnection
    {
        #region Methods
        public AuditTrailLINQ2DB()
            //: base("AuditTrail")
            : base(MultiTenantHelper.GetConnectionName("AuditTrail")) // !?! Multi-Tenant
        {
            AuditTrailLINQ2DBMap.AuditTrailConfigurationMap(MappingSchema);
            AuditTrailLINQ2DBMap.AuditTrailLogMap(MappingSchema);
        }

        public ITable<AuditTrailConfiguration> AuditTrailConfiguration
        {
            get { return GetTable<AuditTrailConfiguration>(); }
        }

        public ITable<AuditTrailLog> AuditTrailLog
        {
            get { return GetTable<AuditTrailLog>(); }
        }

        #endregion Methods
    }
}