using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Likhachev.Pgas.Data
{
    using Core;
    using Core.Accounts;
    using Core.DictionaryTypes;
    using Core.Activities;
    using Core.PgasClaims;
    using EntityTypeConfigurations;

    public partial class PgasContext : DbContext
    {
        public static string ConnectionString { get; } = "Data Source=DESKTOP-4HUR70Q\\SQLEXPRESS;Initial Catalog=Likhachev.Pgas.DB;Trusted_Connection=True;";
        public PgasContext() {}
        public PgasContext(DbContextOptions<PgasContext> options) : base(options) {}

        #region DbSets
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AchievementLevel> AchievementLevels { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
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
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer(ConnectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new AchievementLevelConfiguration());
            modelBuilder.ApplyConfiguration(new AchievementConfiguration());
            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorWorkConfiguration());
            modelBuilder.ApplyConfiguration(new CreativeEndeavorConfiguration());
            modelBuilder.ApplyConfiguration(new EventLevelConfiguration());
            modelBuilder.ApplyConfiguration(new FacultyConfiguration());
            modelBuilder.ApplyConfiguration(new FileConfiguration());
            modelBuilder.ApplyConfiguration(new GroupSizeConfiguration());
            modelBuilder.ApplyConfiguration(new PgasActivityLinkConfiguration());
            modelBuilder.ApplyConfiguration(new PgasClaimConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewerRemarkConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
