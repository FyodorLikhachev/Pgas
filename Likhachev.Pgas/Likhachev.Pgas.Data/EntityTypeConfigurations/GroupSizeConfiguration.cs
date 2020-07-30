using Likhachev.Pgas.Core.DictionaryTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    class GroupSizeConfiguration : IEntityTypeConfiguration<GroupSize>
    {
        public void Configure(EntityTypeBuilder<GroupSize> entity) 
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__group_si__1B0DBAF7452337BC");

            entity.ToTable("group_sizes");

            entity.HasIndex(e => e.GroupSizeName)
                .HasName("KEY_group_sizes_group_size_name")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("group_size_id");

            entity.Property(e => e.GroupSizeName)
                .IsRequired()
                .HasColumnName("group_size_name")
                .HasMaxLength(100);
        }
    }
}
