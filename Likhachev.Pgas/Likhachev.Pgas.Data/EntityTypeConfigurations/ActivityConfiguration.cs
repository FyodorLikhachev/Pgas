using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Likhachev.Pgas.Data.EntityTypeConfigurations
{
    using Core.Activities;
    class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__activiti__482FBD6399F9A3D6");

            entity.ToTable("activities");

            entity.HasIndex(e => new { e.ActivityName, e.Date, e.AccountId })
                .HasName("IDX_activities");

            entity.Property(e => e.Id).HasColumnName("activity_id");

            entity.Property(e => e.AccountId).HasColumnName("account_id");

            entity.Property(e => e.ActivityName)
                .IsRequired()
                .HasColumnName("activity_name")
                .HasMaxLength(100);

            entity.Property(e => e.Date)
                .HasColumnName("date")
                .HasColumnType("datetime");

            entity.Property(e => e.PinnedFileId).HasColumnName("pinned_file_id");

            entity.HasOne(d => d.Account)
                .WithMany(p => p.Activities)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_activities_account_id");

            entity.HasOne(d => d.AuthorWork)
                .WithOne(p => p.Activity)
                .HasForeignKey<AuthorWork>(d => d.ActivityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__author_wo__activ__4E88ABD4");

            entity.HasOne(d => d.Achievement)
                .WithOne(p => p.Activity)
                .HasForeignKey<Achievement>(d => d.ActivityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__achieveme__activ__46E78A0C");

            entity.HasOne(d => d.PinnedFile)
                .WithOne(p => p.Activity)
                .HasForeignKey<File>(d => d.ActivityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_files_activity_id");
        }
    }
}
