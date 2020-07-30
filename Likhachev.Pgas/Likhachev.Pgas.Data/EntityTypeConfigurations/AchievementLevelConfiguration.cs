using Likhachev.Pgas.Core.DictionaryTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    class AchievementLevelConfiguration : IEntityTypeConfiguration<AchievementLevel>
    {
        public void Configure(EntityTypeBuilder<AchievementLevel> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__achievem__55F18BFEC39B7827");

            entity.ToTable("achievement_levels");

            entity.HasIndex(e => e.AchieveLvlName)
                .HasName("KEY_achievement_levels_achieve_lvl_name")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("achieve_lvl_id");

            entity.Property(e => e.AchieveLvlName)
                .IsRequired()
                .HasColumnName("achieve_lvl_name")
                .HasMaxLength(100);
        }
    }
}
