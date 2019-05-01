namespace FastFood.Data
{
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;

    public class FastFoodDbContext : DbContext
	{
		public FastFoodDbContext()
		{
		}

		public FastFoodDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Category> Categories { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if (!builder.IsConfigured)
			{
				builder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Position>().HasAlternateKey(e => e.Name);
            modelBuilder.Entity<Item>().HasAlternateKey(e => e.Name);

            modelBuilder.Entity<Order>().Ignore(e => e.TotalPrice);

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ItemId });

                entity.HasOne(oa => oa.Order)
                    .WithMany(o => o.OrderItems)
                    .HasForeignKey(oa => oa.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(oa => oa.Item)
                    .WithMany(i => i.OrderItems)
                    .HasForeignKey(oa => oa.ItemId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
		}
	}
}