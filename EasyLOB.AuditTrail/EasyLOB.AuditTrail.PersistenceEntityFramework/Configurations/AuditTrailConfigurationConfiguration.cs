using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EasyLOB.AuditTrail.Data;

namespace EasyLOB.AuditTrail.Persistence
{
    public class AuditTrailConfigurationConfiguration : EntityTypeConfiguration<AuditTrailConfiguration>
    {
        public AuditTrailConfigurationConfiguration()
        {
            #region Class
            
            this.ToTable("EasyLOBAuditTrailConfiguration");            

            this.HasKey(x => x.Id);

            #endregion Class

            #region Properties
        
            this.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        
            this.Property(x => x.Domain)
                .HasColumnName("Domain")
                .HasColumnType("varchar")
                .HasMaxLength(256)
                .IsRequired();
        
            this.Property(x => x.Entity)
                .HasColumnName("Entity")
                .HasColumnType("varchar")
                .HasMaxLength(256)
                .IsRequired();
        
            this.Property(x => x.LogOperations)
                .HasColumnName("LogOperations")
                .HasColumnType("varchar")
                .HasMaxLength(256);
        
            this.Property(x => x.LogMode)
                .HasColumnName("LogMode")
                .HasColumnType("varchar")
                .HasMaxLength(1);

            #endregion Properties
        }
    }
}
