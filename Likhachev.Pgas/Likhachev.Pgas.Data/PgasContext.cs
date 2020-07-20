using System;
using Likhachev.Pgas.Core;
using Likhachev.Pgas.Core.DictionaryTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Likhachev.Pgas.Data
{
    public partial class PgasContext : DbContext
    {
        public static string ConnectionString { get; } = "Data Source=DESKTOP-4HUR70Q\\SQLEXPRESS;Initial Catalog=Pgas;Trusted_Connection=True;";
        public PgasContext() {}

        public PgasContext(DbContextOptions<PgasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AchievementLevel> AchievementLevels { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<AllActivity> AllActivities { get; set; }
        public virtual DbSet<AuthorWork> AuthorWorks { get; set; }
        public virtual DbSet<CreativeEndeavor> CreativeEndeavors { get; set; }
        public virtual DbSet<EventLevel> EventLevels { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<GroupSize> GroupSizes { get; set; }
        public virtual DbSet<PgasActivityLink> PgasActivityLinks { get; set; }
        public virtual DbSet<PgasClaim> PgasClaim { get; set; }
        public virtual DbSet<ReviewerRemark> ReviewerRemarks { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__account___18186C103EF3EDC8");

                entity.ToTable("account_types");

                entity.HasIndex(e => e.AccountTypeName)
                    .HasName("KEY_account_types_account_type_name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("account_type_id");

                entity.Property(e => e.AccountTypeName)
                    .IsRequired()
                    .HasColumnName("account_type_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__accounts__46A222CD931EE94F");

                entity.ToTable("accounts");

                entity.HasIndex(e => e.Login)
                    .HasName("KEY_accounts_login")
                    .IsUnique();

                entity.HasIndex(e => new { e.FatherName, e.Login, e.Password })
                    .HasName("IDX_accounts");

                entity.Property(e => e.Id).HasColumnName("account_id");

                entity.Property(e => e.AccountTypeId).HasColumnName("account_type_id");

                entity.Property(e => e.FacultyId).HasColumnName("faculty_id");

                entity.Property(e => e.FatherName)
                    .IsRequired()
                    .HasColumnName("father_name")
                    .HasMaxLength(100);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(100);

                entity.Property(e => e.SecondName)
                    .HasColumnName("second_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudyGroup)
                    .HasColumnName("study_group")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__accounts__accoun__634EBE90");
            });

            modelBuilder.Entity<AchievementLevel>(entity =>
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
            });

            modelBuilder.Entity<Achievement>(entity =>
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

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Achievements)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__achieveme__activ__46E78A0C");

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
            });

            modelBuilder.Entity<Activity>(entity =>
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

                entity.HasOne(d => d.PinnedFile)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.PinnedFileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_activities_pinned_file_id");
            });

            modelBuilder.Entity<AllActivity>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("all_activities");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AchieveLvlId).HasColumnName("achieve_lvl_id");

                entity.Property(e => e.Id).HasColumnName("activity_id");

                entity.Property(e => e.ActivityName)
                    .IsRequired()
                    .HasColumnName("activity_name")
                    .HasMaxLength(100);

                entity.Property(e => e.ActivityType).HasColumnName("activity_type");

                entity.Property(e => e.CrEndeavorId).HasColumnName("cr_endeavor_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EvLvlId).HasColumnName("ev_lvl_id");

                entity.Property(e => e.EventLink)
                    .HasColumnName("event_link")
                    .HasMaxLength(100);

                entity.Property(e => e.GroupSizeId).HasColumnName("group_size_id");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.Property(e => e.PinnedFileId).HasColumnName("pinned_file_id");
            });

            modelBuilder.Entity<AuthorWork>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__author_w__F4223E6AC3186CB0");

                entity.ToTable("author_works");

                entity.HasIndex(e => e.ActivityId)
                    .HasName("IDX_author_works_activity_id");

                entity.Property(e => e.Id).HasColumnName("author_work_id");

                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

                entity.Property(e => e.CreativeEndeavorId).HasColumnName("creative_endeavor_id");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.AuthorWorks)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__author_wo__activ__4E88ABD4");

                entity.HasOne(d => d.CreativeEndeavor)
                    .WithMany(p => p.AuthorWorks)
                    .HasForeignKey(d => d.CreativeEndeavorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__author_wo__creat__4F7CD00D");
            });

            modelBuilder.Entity<CreativeEndeavor>(entity =>
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
            });

            modelBuilder.Entity<EventLevel>(entity =>
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
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_faculties_faculty_id");

                entity.ToTable("faculties");

                entity.Property(e => e.Id).HasColumnName("faculty_id");

                entity.Property(e => e.FacultyName)
                    .IsRequired()
                    .HasColumnName("faculty_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_files_file_id");

                entity.ToTable("files");

                entity.Property(e => e.Id).HasColumnName("file_id");

                entity.Property(e => e.FileByte)
                    .IsRequired()
                    .HasColumnName("file_byte");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasColumnName("file_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroupSize>(entity =>
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
            });

            modelBuilder.Entity<PgasActivityLink>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__pgas_act__93B0078CCD33AAE0");

                entity.ToTable("pgas_activity_links");

                entity.HasIndex(e => new { e.PgasClaimId, e.ActivityId })
                    .HasName("IDX_pgas_activity_links");

                entity.Property(e => e.Id).HasColumnName("link_id");

                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

                entity.Property(e => e.PgasClaimId).HasColumnName("pgas_claim_id");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.PgasActivityLinks)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pgas_acti__activ__4D94879B");

                entity.HasOne(d => d.PgasClaim)
                    .WithMany(p => p.PgasActivityLinks)
                    .HasForeignKey(d => d.PgasClaimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pgas_acti__pgas___4CA06362");
            });

            modelBuilder.Entity<PgasClaim>(entity =>
            {
                entity.ToTable("pgas_claim");

                entity.HasIndex(e => new { e.Mark, e.ReviewerId, e.StatusId, e.AccountId, e.Date })
                    .HasName("IDX_pgas_claim");

                entity.Property(e => e.Id).HasColumnName("pgas_claim_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mark)
                    .HasColumnName("mark")
                    .HasColumnType("numeric(6, 2)");

                entity.Property(e => e.ReviewerId).HasColumnName("reviewer_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.PgasClaimAccount)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_pgas_claim_account_id");

                entity.HasOne(d => d.Reviewer)
                    .WithMany(p => p.PgasClaimReviewer)
                    .HasForeignKey(d => d.ReviewerId)
                    .HasConstraintName("FK_pgas_claim_reviewer_id");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.PgasClaim)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pgas_clai__statu__4BAC3F29");
            });

            modelBuilder.Entity<ReviewerRemark>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_reviewer_remarks_remark_id");

                entity.ToTable("reviewer_remarks");

                entity.Property(e => e.Id).HasColumnName("remark_id");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.NewMark)
                    .HasColumnName("new_mark")
                    .HasColumnType("numeric(6, 2)");

                entity.Property(e => e.PgasClaimId).HasColumnName("pgas_claim_id");

                entity.HasOne(d => d.PgasClaim)
                    .WithMany(p => p.ReviewerRemarks)
                    .HasForeignKey(d => d.PgasClaimId)
                    .HasConstraintName("FK_reviewer_remarks_pgas_claim_id");
            });

            modelBuilder.Entity<Status>(entity =>
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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
