using EasyLOB.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EasyLOB.Identity.Persistence
{
    public class UserLoginConfiguration : EntityTypeConfiguration<UserLogin>
    {
        public UserLoginConfiguration()
        {
            #region Class

            this.ToTable("AspNetUserLogins");

            this.HasKey(x => new { x.LoginProvider, x.ProviderKey, x.UserId });

            #endregion Class

            #region Properties

            this.Property(x => x.LoginProvider)
                .HasColumnName("LoginProvider")
                .HasColumnOrder(1)
                .HasColumnType("varchar")
                .HasMaxLength(128)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            this.Property(x => x.ProviderKey)
                .HasColumnName("ProviderKey")
                .HasColumnOrder(2)
                .HasColumnType("varchar")
                .HasMaxLength(128)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            this.Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnOrder(3)
                .HasColumnType("varchar")
                .HasMaxLength(128)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            #endregion Properties

            #region Associations (FK)

            this.HasRequired(x => x.User)
                .WithMany(x => x.UserLogins)
                .HasForeignKey(x => x.UserId);

            #endregion Associations (FK)
        }
    }
}