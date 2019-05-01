namespace FDMC.Data
{
    using FDMC.Models;
    using Microsoft.EntityFrameworkCore;

    public class FdmcDbContext : DbContext
    {
        public FdmcDbContext(DbContextOptions<FdmcDbContext> options)
            :base(options)
        {
        }
        
        public DbSet<Cat> Cats { get; set; }

        public DbSet<Breed> Breeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Cat>()
                .HasOne(c => c.Breed)
                .WithMany(b => b.Cats)
                .HasForeignKey(c => c.BreedId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
