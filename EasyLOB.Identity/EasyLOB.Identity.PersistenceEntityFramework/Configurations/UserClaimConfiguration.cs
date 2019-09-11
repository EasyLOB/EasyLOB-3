using EasyLOB.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EasyLOB.Identity.Persistence
{
    public class UserClaimConfiguration : EntityTypeConfiguration<UserClaim>
    {
        public UserClaimConfiguration()
        {
            #region Class

            this.ToTable("AspNetUserClaims");

            this.HasKey(x => x.Id);

            #endregion Class

            #region Properties

            this.Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            this.Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("varchar")
                .HasMaxLength(128)
                .IsRequired();

            this.Property(x => x.ClaimType)
                .HasColumnName("ClaimType")
                .HasColumnType("varchar")
                .HasMaxLength(1024);

            this.Property(x => x.ClaimValue)
                .HasColumnName("ClaimValue")
                .HasColumnType("varchar")
                .HasMaxLength(1024);

            #endregion Properties

            #region Associations (FK)

            this.HasRequired(x => x.User)
                .WithMany(x => x.UserClaims)
                .HasForeignKey(x => x.UserId);

            #endregion Associations (FK)
        }
    }
}