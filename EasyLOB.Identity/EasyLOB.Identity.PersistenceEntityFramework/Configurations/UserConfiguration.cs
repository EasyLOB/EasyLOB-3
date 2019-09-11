using EasyLOB.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EasyLOB.Identity.Persistence
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            #region Class

            this.ToTable("AspNetUsers");

            this.HasKey(x => x.Id);

            #endregion Class

            #region Properties

            this.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("varchar")
                .HasMaxLength(128)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired();

            this.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(256);

            this.Property(x => x.EmailConfirmed)
                .HasColumnName("EmailConfirmed")
                .HasColumnType("bit")
                .IsRequired();

            this.Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("varchar")
                .HasMaxLength(1024);

            this.Property(x => x.SecurityStamp)
                .HasColumnName("SecurityStamp")
                .HasColumnType("varchar")
                .HasMaxLength(1024);

            this.Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("varchar")
                .HasMaxLength(1024);

            this.Property(x => x.PhoneNumberConfirmed)
                .HasColumnName("PhoneNumberConfirmed")
                .HasColumnType("bit")
                .IsRequired();

            this.Property(x => x.TwoFactorEnabled)
                .HasColumnName("TwoFactorEnabled")
                .HasColumnType("bit")
                .IsRequired();

            this.Property(x => x.LockoutEndDateUtc)
                .HasColumnName("LockoutEndDateUtc")
                .HasColumnType("datetime");

            this.Property(x => x.LockoutEnabled)
                .HasColumnName("LockoutEnabled")
                .HasColumnType("bit")
                .IsRequired();

            this.Property(x => x.AccessFailedCount)
                .HasColumnName("AccessFailedCount")
                .HasColumnType("int")
                .IsRequired();

            this.Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasColumnType("varchar")
                .HasMaxLength(256)
                .IsRequired();

            #endregion Properties
        }
    }
}