using Likhachev.Pgas.Core.DictionaryTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    class CreativeEndeavorConfiguration : IEntityTypeConfiguration<CreativeEndeavor>
    {
        public void Configure(EntityTypeBuilder<CreativeEndeavor> entity) 
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__creative__C399DD56639C46C0");

            entity.ToTable("creative_endeavors");

            entity.HasIndex(e => e.CreativeEndeavorName)
                .HasName("KEY_creative_endeavors_creative_endeavor_name")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("creative_endeavor_id");

            entity.Property(e => e.CreativeEndeavorName)
                .IsRequired()
                .HasColumnName("creative_endeavor_name")
                .HasMaxLength(100);
        }
    }
}
