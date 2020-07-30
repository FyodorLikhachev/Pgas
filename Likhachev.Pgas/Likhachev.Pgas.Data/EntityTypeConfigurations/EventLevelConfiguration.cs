using Likhachev.Pgas.Core.DictionaryTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    class EventLevelConfiguration : IEntityTypeConfiguration<EventLevel>
    {
        public void Configure(EntityTypeBuilder<EventLevel> entity) 
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK_event_levels_ev_lvl_id");

            entity.ToTable("event_levels");

            entity.HasIndex(e => e.EvLvlName)
                .HasName("KEY_event_levels_ev_lvl_name")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("ev_lvl_id");

            entity.Property(e => e.EvLvlName)
                .IsRequired()
                .HasColumnName("ev_lvl_name")
                .HasMaxLength(100);
        }
    }
}
