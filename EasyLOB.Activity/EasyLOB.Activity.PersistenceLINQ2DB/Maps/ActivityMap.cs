using LinqToDB.Mapping;
using EasyLOB.Activity.Data;

namespace EasyLOB.Activity.Persistence
{
    public static partial class ActivityLINQ2DBMap
    {
        public static void ActivityMap(MappingSchema mappingSchema)
        {
            mappingSchema.GetFluentMappingBuilder().Entity<EasyLOB.Activity.Data.Activity>()
                .HasTableName("EasyLOBActivity")

                .Property(x => x.Id)
                    .IsPrimaryKey()
                    .HasColumnName("Id")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(128)
                    .IsNullable(false)

                .Property(x => x.Name)
                    .HasColumnName("Name")
                    .HasDataType(LinqToDB.DataType.VarChar)
                    .HasLength(256)
                    .IsNullable(false)

                .Property(x => x.ActivityRoles)
                    .IsNotColumn()
            
                .Property(x => x.LookupText)
                    .IsNotColumn()                    
                ;    
        }
    }
}
