namespace ProductsShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using ProductsShop.Models;

    public class ProductsShopDbContext : DbContext
    {
        public ProductsShopDbContext()
            : base()
        {
        }

        public ProductsShopDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName).IsRequired(false);
                entity.Property(e => e.LastName).IsRequired(true);
                entity.Property(e => e.Age).IsRequired(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).IsRequired(true);
                entity.Property(e => e.Price).IsRequired(true);
                entity.Property(e => e.SellerId).IsRequired(true);
                entity.Property(e => e.BuyerId).IsRequired(false);

                entity.HasOne(p => p.Seller)
                    .WithMany(s => s.ProductsSold)
                    .HasForeignKey(p => p.SellerId);

                entity.HasOne(p => p.Buyer)
                    .WithMany(b => b.ProductsBought)
                    .HasForeignKey(p => p.BuyerId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).IsRequired(true).HasMaxLength(15);
            });

            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(e => new { e.CategoryId, e.ProductId });
            });
        }
    }
}
