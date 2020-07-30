using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    using Core.Activities;
    class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK_files_file_id");

            entity.HasIndex(e => e.ActivityId)
                .HasName("IDX_files_activity_id");

            entity.ToTable("files");

            entity.Property(e => e.Id).HasColumnName("file_id");

            entity.Property(e => e.ActivityId).HasColumnName("activity_id");

            entity.Property(e => e.FileByte)
                .IsRequired()
                .HasColumnName("file_byte");

            entity.Property(e => e.FileName)
                .IsRequired()
                .HasColumnName("file_name")
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
