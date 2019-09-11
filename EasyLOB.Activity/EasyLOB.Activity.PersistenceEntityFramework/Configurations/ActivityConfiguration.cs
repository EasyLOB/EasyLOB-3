using EasyLOB.Activity.Data;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyLOB.Activity.Persistence
{
    public class ActivityConfiguration : EntityTypeConfiguration<EasyLOB.Activity.Data.Activity>
    {
        public ActivityConfiguration()
        {
            #region Class

            this.ToTable("EasyLOBActivity");

            this.HasKey(x => x.Id);

            #endregion Class

            #region Properties

            this.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("varchar")
                .HasMaxLength(128)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            this.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(256)
                .IsRequired();

            #endregion Properties
        }
    }
}