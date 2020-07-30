using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    using Core.Activities;
    class AchievementConfiguration : IEntityTypeConfiguration<Achievement>
    {
        public void Configure(EntityTypeBuilder<Achievement> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__achievem__3C492E83CA9C2F51");

            entity.ToTable("achievements");

            entity.HasIndex(e => e.ActivityId)
                .HasName("IDX_achievements_activity_id");

            entity.Property(e => e.Id).HasColumnName("achievement_id");

            entity.Property(e => e.AchieveLvlId).HasColumnName("achieve_lvl_id");

            entity.Property(e => e.ActivityId).HasColumnName("activity_id");

            entity.Property(e => e.EvLvlId).HasColumnName("ev_lvl_id");

            entity.Property(e => e.EventLink)
                .HasColumnName("event_link")
                .HasMaxLength(100);

            entity.Property(e => e.GroupSizeId).HasColumnName("group_size_id");

            entity.HasOne(d => d.AchieveLvl)
                .WithMany(p => p.Achievements)
                .HasForeignKey(d => d.AchieveLvlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_achievements_achieve_lvl_id");

            entity.HasOne(d => d.EvLvl)
                .WithMany(p => p.Achievements)
                .HasForeignKey(d => d.EvLvlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_achievements_ev_lvl_id");

            entity.HasOne(d => d.GroupSize)
                .WithMany(p => p.Achievements)
                .HasForeignKey(d => d.GroupSizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__achieveme__group__48CFD27E");
        }
    }
}
