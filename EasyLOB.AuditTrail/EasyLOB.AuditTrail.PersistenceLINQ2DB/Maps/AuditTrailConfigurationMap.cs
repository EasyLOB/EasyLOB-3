using LinqToDB.Mapping;
using EasyLOB.AuditTrail.Data;

namespace EasyLOB.AuditTrail.Persistence
{
    public static partial class AuditTrailLINQ2DBMap
    {
        public static void AuditTrailConfigurationMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<AuditTrailConfiguration>()
                .HasTableName("EasyLOBAuditTrailConfiguration")

                .Property(x => x.Id)
                    .IsPrimaryKey()
                    .IsIdentity()
                    .HasColumnName("Id")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(false)

                .Property(x => x.Domain)
                    .HasColumnName("Domain")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(256)
                    .IsNullable(false)

                .Property(x => x.Entity)
                    .HasColumnName("Entity")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(256)
                    .IsNullable(false)

                .Property(x => x.LogOperations)
                    .HasColumnName("LogOperations")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(256)
                    .IsNullable(true)

                .Property(x => x.LogMode)
                    .HasColumnName("LogMode")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(1)
                    .IsNullable(true)
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
