namespace Employees.Data
{
    using Microsoft.EntityFrameworkCore;
    using Employees.Models;

    public class EmployeesDbContext : DbContext
    {
        public EmployeesDbContext()
        {
        }

        public EmployeesDbContext(DbContextOptions options)
            : base()
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName).IsRequired(true).IsUnicode(true).HasMaxLength(60);
                entity.Property(e => e.LastName).IsRequired(true).IsUnicode(true).HasMaxLength(60);
                entity.Property(e => e.Salary).IsRequired(true);
                entity.Property(e => e.ManagerId).IsRequired(false);

                entity
                    .HasOne(e => e.Manager)
                    .WithMany(m => m.SubEmployees)
                    .HasForeignKey(e => e.ManagerId);
            });
        }
    }
}
