using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EasyLOB.AuditTrail.Data;

namespace EasyLOB.AuditTrail.Persistence
{
    public class AuditTrailLogConfiguration : EntityTypeConfiguration<AuditTrailLog>
    {
        public AuditTrailLogConfiguration()
        {
            #region Class
            
            this.ToTable("EasyLOBAuditTrailLog");            

            this.HasKey(x => x.Id);

            #endregion Class

            #region Properties
        
            this.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();
        
            this.Property(x => x.LogDate)
                .HasColumnName("LogDate")
                .HasColumnType("datetime");
        
            this.Property(x => x.LogTime)
                .HasColumnName("LogTime")
                .HasColumnType("datetime");
        
            this.Property(x => x.LogUserName)
                .HasColumnName("LogUserName")
                .HasColumnType("varchar")
                .HasMaxLength(256);
        
            this.Property(x => x.LogDomain)
                .HasColumnName("LogDomain")
                .HasColumnType("varchar")
                .HasMaxLength(256);
        
            this.Property(x => x.LogEntity)
                .HasColumnName("LogEntity")
                .HasColumnType("varchar")
                .HasMaxLength(256);
        
            this.Property(x => x.LogOperation)
                .HasColumnName("LogOperation")
                .HasColumnType("varchar")
                .HasMaxLength(1);
        
            this.Property(x => x.LogId)
                .HasColumnName("LogId")
                .HasColumnType("varchar")
                .HasMaxLength(4096);
        
            this.Property(x => x.LogEntityBefore)
                .HasColumnName("LogEntityBefore")
                .HasColumnType("varchar")
                .HasMaxLength(4096);
        
            this.Property(x => x.LogEntityAfter)
                .HasColumnName("LogEntityAfter")
                .HasColumnType("varchar")
                .HasMaxLength(4096);

            #endregion Properties
        }
    }
}
