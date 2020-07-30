using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    using Core.PgasClaims;
    class ReviewerRemarkConfiguration : IEntityTypeConfiguration<ReviewerRemark>
    {
        public void Configure(EntityTypeBuilder<ReviewerRemark> entity) 
        {
            entity.HasKey(e => e.Id)
                       .HasName("PK_reviewer_remarks_remark_id");

            entity.ToTable("reviewer_remarks");

            entity.Property(e => e.Id).HasColumnName("remark_id");

            entity.Property(e => e.Comment).HasColumnName("comment");

            entity.Property(e => e.NewMark)
                .HasColumnName("new_mark")
                .HasColumnType("numeric(6, 2)");

            entity.Property(e => e.PgasClaimId).HasColumnName("pgas_claim_id");

            entity.HasOne(d => d.PgasClaim)
                .WithMany(p => p.ReviewerRemarks)
                .HasForeignKey(d => d.PgasClaimId)
                .HasConstraintName("FK_reviewer_remarks_pgas_claim_id");
        }
    }
}
