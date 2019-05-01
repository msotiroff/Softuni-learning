using Microsoft.EntityFrameworkCore;
using Stations.Models;

namespace Stations.Data
{
	public class StationsDbContext : DbContext
	{
		public StationsDbContext()
		{
		}

		public StationsDbContext(DbContextOptions options)
			: base(options)
		{
		}


        public DbSet<Trip> Trips { get; set; }

        public DbSet<CustomerCard> Cards { get; set; }

        public DbSet<SeatingClass> SeatingClasses { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Train> Trains { get; set; }

        public DbSet<TrainSeat> TrainSeats { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Station>().HasAlternateKey(e => e.Name);

            modelBuilder.Entity<Train>().HasAlternateKey(e => e.TrainNumber);

            modelBuilder.Entity<SeatingClass>().HasAlternateKey(e => e.Name);

            modelBuilder.Entity<SeatingClass>().HasAlternateKey(e => e.Abbreviation);
            
            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasOne(t => t.OriginStation)
                    .WithMany(os => os.TripsFrom)
                    .HasForeignKey(t => t.OriginStationId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.DestinationStation)
                    .WithMany(ds => ds.TripsTo)
                    .HasForeignKey(t => t.DestinationStationId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
	}
}