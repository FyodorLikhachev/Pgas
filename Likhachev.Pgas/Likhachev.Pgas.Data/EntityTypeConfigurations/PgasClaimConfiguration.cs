using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    using Core.PgasClaims;
    class PgasClaimConfiguration : IEntityTypeConfiguration<PgasClaim>
    {
        public void Configure(EntityTypeBuilder<PgasClaim> entity) 
        {
            entity.ToTable("pgas_claim");

            entity.HasIndex(e => new { e.Mark, e.ReviewerId, e.StatusId, e.AccountId, e.Date })
                .HasName("IDX_pgas_claim");

            entity.Property(e => e.Id).HasColumnName("pgas_claim_id");

            entity.Property(e => e.AccountId).HasColumnName("account_id");

            entity.Property(e => e.Date)
                .HasColumnName("date")
                .HasColumnType("datetime");

            entity.Property(e => e.Mark)
                .HasColumnName("mark")
                .HasColumnType("numeric(6, 2)");

            entity.Property(e => e.ReviewerId).HasColumnName("reviewer_id");

            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Account)
                .WithMany(p => p.PgasClaimAccount)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pgas_claim_account_id");

            entity.HasOne(d => d.Reviewer)
                .WithMany(p => p.PgasClaimReviewer)
                .HasForeignKey(d => d.ReviewerId)
                .HasConstraintName("FK_pgas_claim_reviewer_id");

            entity.HasOne(d => d.Status)
                .WithMany(p => p.PgasClaim)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pgas_clai__statu__4BAC3F29");
        }
    }
}
