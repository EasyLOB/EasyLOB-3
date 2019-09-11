using EasyLOB.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EasyLOB.Identity.Persistence
{
    public class UserRoleConfiguration : EntityTypeConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            #region Class

            this.ToTable("AspNetUserRoles");

            this.HasKey(x => new { x.UserId, x.RoleId });

            #endregion Class

            #region Properties

            this.Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnOrder(1)
                .HasColumnType("varchar")
                .HasMaxLength(128)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            this.Property(x => x.RoleId)
                .HasColumnName("RoleId")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .HasMaxLength(128)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            #endregion Properties

            #region Associations (FK)

            this.HasRequired(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId);

            this.HasRequired(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId);

            #endregion Associations (FK)
        }
    }
}