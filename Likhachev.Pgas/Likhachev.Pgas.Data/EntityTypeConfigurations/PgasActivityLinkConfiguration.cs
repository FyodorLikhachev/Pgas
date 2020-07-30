using Likhachev.Pgas.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    class PgasActivityLinkConfiguration : IEntityTypeConfiguration<PgasActivityLink>
    {
        public void Configure(EntityTypeBuilder<PgasActivityLink> entity) 
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__pgas_act__93B0078CCD33AAE0");

            entity.ToTable("pgas_activity_links");

            entity.HasIndex(e => new { e.PgasClaimId, e.ActivityId })
                .HasName("IDX_pgas_activity_links");

            entity.Property(e => e.Id).HasColumnName("link_id");

            entity.Property(e => e.ActivityId).HasColumnName("activity_id");

            entity.Property(e => e.PgasClaimId).HasColumnName("pgas_claim_id");

            entity.HasOne(d => d.Activity)
                .WithMany(p => p.PgasActivityLinks)
                .HasForeignKey(d => d.ActivityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pgas_acti__activ__4D94879B");

            entity.HasOne(d => d.PgasClaim)
                .WithMany(p => p.PgasActivityLinks)
                .HasForeignKey(d => d.PgasClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__pgas_acti__pgas___4CA06362");
        }
    }
}
