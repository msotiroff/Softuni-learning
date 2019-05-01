namespace ByTheCake.Data
{
    using ByTheCake.Data.Configurations;
    using ByTheCake.Models;
    using Microsoft.EntityFrameworkCore;

    public class ByTheCakeDbContext : DbContext
    {
        public ByTheCakeDbContext()
        {
        }

        public ByTheCakeDbContext(DbContextOptions<ByTheCakeDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(SqlServerConfig.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderProductConfig());
            builder.ApplyConfiguration(new OrderConfig());

            base.OnModelCreating(builder);
        }
    }
}
