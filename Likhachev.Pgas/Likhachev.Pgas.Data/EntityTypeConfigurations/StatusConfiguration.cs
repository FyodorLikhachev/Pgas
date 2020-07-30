using Likhachev.Pgas.Core.DictionaryTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> entity) 
        {
            entity.ToTable("status");

            entity.HasIndex(e => e.StatusName)
                .HasName("KEY_status_status_name")
                .IsUnique();

            entity.Property(e => e.Id).HasColumnName("status_id");

            entity.Property(e => e.StatusName)
                .IsRequired()
                .HasColumnName("status_name")
                .HasMaxLength(100);
        }
    }
}
