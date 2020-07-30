using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    using Core.Activities;
    class AuthorWorkConfiguration : IEntityTypeConfiguration<AuthorWork>
    {
        public void Configure(EntityTypeBuilder<AuthorWork> entity) 
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__author_w__F4223E6AC3186CB0");

            entity.ToTable("author_works");

            entity.HasIndex(e => e.ActivityId)
                .HasName("IDX_author_works_activity_id");

            entity.Property(e => e.Id).HasColumnName("author_work_id");

            entity.Property(e => e.ActivityId).HasColumnName("activity_id");

            entity.Property(e => e.CreativeEndeavorId).HasColumnName("creative_endeavor_id");

            //entity.HasOne(d => d.Activity)
            //    .WithOne(p => p.AuthorWork)
            //    .HasForeignKey<AuthorWork>(d => d.ActivityId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__author_wo__activ__4E88ABD4");

            entity.HasOne(d => d.CreativeEndeavor)
                .WithMany(p => p.AuthorWorks)
                .HasForeignKey(d => d.CreativeEndeavorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__author_wo__creat__4F7CD00D");
        }
    }
}
