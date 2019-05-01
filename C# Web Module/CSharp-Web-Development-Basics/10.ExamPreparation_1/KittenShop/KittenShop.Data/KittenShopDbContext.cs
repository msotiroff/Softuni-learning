namespace KittenShop.Data
{
    using Configurations;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class KittenShopDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Kitten> Kittens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(SqlServerConfig.ConnectionString);

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new KittenConfig());

            base.OnModelCreating(builder);
        }
    }
}
