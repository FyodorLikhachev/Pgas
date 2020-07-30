using Likhachev.Pgas.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    using Core.Accounts;
    class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> entity) 
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__accounts__46A222CD931EE94F");

            entity.ToTable("accounts");

            entity.HasIndex(e => e.Login)
                .HasName("KEY_accounts_login")
                .IsUnique();

            entity.HasIndex(e => new { e.FatherName, e.Login, e.Password })
                .HasName("IDX_accounts");

            entity.Property(e => e.Id).HasColumnName("account_id");

            entity.Property(e => e.AccountTypeId).HasColumnName("account_type_id");

            entity.Property(e => e.FacultyId).HasColumnName("faculty_id");

            entity.Property(e => e.FatherName)
                .IsRequired()
                .HasColumnName("father_name")
                .HasMaxLength(100);

            entity.Property(e => e.Login)
                .IsRequired()
                .HasColumnName("login")
                .HasMaxLength(100);

            entity.Property(e => e.FirstName)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasMaxLength(100);

            entity.Property(e => e.Position)
                .HasColumnName("position")
                .HasMaxLength(100);

            entity.Property(e => e.SecondName)
                .HasColumnName("second_name")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.StudyGroup)
                .HasColumnName("study_group")
                .HasMaxLength(100);

            entity.HasOne(d => d.AccountType)
                .WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccountTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__accounts__accoun__634EBE90");
        }
    }
}
