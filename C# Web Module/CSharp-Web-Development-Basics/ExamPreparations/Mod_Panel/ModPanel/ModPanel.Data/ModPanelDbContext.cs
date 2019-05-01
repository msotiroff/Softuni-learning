namespace ModPanel.Data
{
    using Configurations;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ModPanelDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<AdminLog> AdminLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(SqlServerConfig.ConnectionString);

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());

            base.OnModelCreating(builder);
        }
    }
}
