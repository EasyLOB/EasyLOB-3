using LinqToDB.Mapping;
using EasyLOB.Activity.Data;

namespace EasyLOB.Activity.Persistence
{
    public static partial class ActivityLINQ2DBMap
    {
        public static void ActivityRoleMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<ActivityRole>()
                .HasTableName("EasyLOBActivityRole")

                .Property(x => x.ActivityId)
                    .IsPrimaryKey(1)
                    .HasColumnName("ActivityId")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(128)
                    .IsNullable(false)

                .Property(x => x.RoleName)
                    .IsPrimaryKey(2)
                    .HasColumnName("RoleName")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(256)
                    .IsNullable(false)

                .Property(x => x.Operations)
                    .HasColumnName("Operations")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(256)
                    .IsNullable(true)
            
                .Property(x => x.Activity)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
