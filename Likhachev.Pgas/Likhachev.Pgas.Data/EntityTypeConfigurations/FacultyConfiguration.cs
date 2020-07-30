using Likhachev.Pgas.Core.DictionaryTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> entity) 
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK_faculties_faculty_id");

            entity.ToTable("faculties");

            entity.Property(e => e.Id).HasColumnName("faculty_id");

            entity.Property(e => e.FacultyName)
                .IsRequired()
                .HasColumnName("faculty_name")
                .HasMaxLength(50);
        }
    }
}
