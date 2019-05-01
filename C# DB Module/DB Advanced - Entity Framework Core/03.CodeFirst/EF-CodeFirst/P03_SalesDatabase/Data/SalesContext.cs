namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<Store> Stores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(
                entity => 
                {
                    entity.HasKey(e => e.CustomerId);

                    entity.Property(e => e.Name).IsRequired(true).HasMaxLength(100).IsUnicode(true);
                    entity.Property(e => e.Email).IsRequired(true).HasMaxLength(80).IsUnicode(false);
                    entity.Property(e => e.CreditCardNumber).IsRequired(true).IsUnicode(false);
                });

            modelBuilder.Entity<Product>(
                entity => 
                {
                    entity.HasKey(e => e.ProductId);

                    entity.Property(e => e.Name).IsRequired(true).HasMaxLength(100).IsUnicode(true);
                    entity.Property(e => e.Quantity).IsRequired(true);
                    entity.Property(e => e.Price).IsRequired(true);
                    entity.Property(e => e.Description).IsRequired(false).HasMaxLength(250).HasDefaultValue("No description").IsUnicode(true);
                });

            modelBuilder.Entity<Store>(
                entity => 
                {
                    entity.HasKey(e => e.StoreId);

                    entity.Property(e => e.Name).IsRequired(true).HasMaxLength(80).IsUnicode(true);
                }
            );

            modelBuilder.Entity<Sale>(
                entity =>
                {
                    entity.HasKey(e => e.SaleId);

                    entity.Property(e => e.Date).IsRequired(true).HasColumnType("DATETIME2").HasDefaultValueSql("GETDATE()");

                    entity.HasOne(s => s.Customer)
                        .WithMany(c => c.Sales)
                        .HasForeignKey(s => s.CustomerId);

                    entity.HasOne(s => s.Product)
                        .WithMany(p => p.Sales)
                        .HasForeignKey(s => s.ProductId);

                    entity.HasOne(s => s.Store)
                        .WithMany(st => st.Sales)
                        .HasForeignKey(s => s.StoreId);
                }
                );
        }
    }
}
