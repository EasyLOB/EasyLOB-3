using LinqToDB.Mapping;
using EasyLOB.AuditTrail.Data;

namespace EasyLOB.AuditTrail.Persistence
{
    public static partial class AuditTrailLINQ2DBMap
    {
        public static void AuditTrailLogMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<AuditTrailLog>()
                .HasTableName("EasyLOBAuditTrailLog")

                .Property(x => x.Id)
                    .IsPrimaryKey()
                    .IsIdentity()
                    .HasColumnName("Id")
                    .HasDataType(LinqToDB.DataType.Int32)
                    .IsNullable(false)

                .Property(x => x.LogDate)
                    .HasColumnName("LogDate")
                    .HasDataType(LinqToDB.DataType.DateTime)
                    .IsNullable(true)

                .Property(x => x.LogTime)
                    .HasColumnName("LogTime")
                    .HasDataType(LinqToDB.DataType.DateTime)
                    .IsNullable(true)

                .Property(x => x.LogUserName)
                    .HasColumnName("LogUserName")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(256)
                    .IsNullable(true)

                .Property(x => x.LogDomain)
                    .HasColumnName("LogDomain")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(256)
                    .IsNullable(true)

                .Property(x => x.LogEntity)
                    .HasColumnName("LogEntity")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(256)
                    .IsNullable(true)

                .Property(x => x.LogOperation)
                    .HasColumnName("LogOperation")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(1)
                    .IsNullable(true)

                .Property(x => x.LogId)
                    .HasColumnName("LogId")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(4096)
                    .IsNullable(true)

                .Property(x => x.LogEntityBefore)
                    .HasColumnName("LogEntityBefore")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(4096)
                    .IsNullable(true)

                .Property(x => x.LogEntityAfter)
                    .HasColumnName("LogEntityAfter")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(4096)
                    .IsNullable(true)
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
