namespace Judge.Data
{
    using Configurations;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class JudgeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Contest> Contests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(SqlServerConfig.ConnectionString);

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new ContestConfig());

            base.OnModelCreating(builder);
        }
    }
}
