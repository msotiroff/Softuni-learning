namespace MeTube.Data
{
    using Configurations;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MeTubeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tube> Tubes { get; set; }

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
