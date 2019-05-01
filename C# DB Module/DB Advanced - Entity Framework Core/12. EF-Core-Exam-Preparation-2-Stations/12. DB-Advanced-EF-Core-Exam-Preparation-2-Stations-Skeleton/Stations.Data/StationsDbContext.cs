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

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.ConnectionString);
			}
		}

        public DbSet<Station> Stations { get; set; }
        public DbSet<SeatingClass> SeatingClasses { get; set; }
        public DbSet<TrainSeat> TrainSeats { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<CustomerCard> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Station>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Name);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Town).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Train>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.TrainNumber);

                entity.Property(e => e.TrainNumber).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Type).IsRequired(false);
            });

            modelBuilder.Entity<SeatingClass>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasAlternateKey(e => e.Name);
                entity.HasAlternateKey(e => e.Abbreviation);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(30);
                entity.Property(e => e.Abbreviation).IsRequired().HasColumnType("CHAR(2)");
            });

            modelBuilder.Entity<TrainSeat>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.SeatingClassId).IsRequired();
                entity.Property(e => e.TrainId).IsRequired();
                entity.Property(e => e.Quantity).IsRequired();

                entity.HasOne(ts => ts.Train)
                    .WithMany(t => t.TrainSeats)
                    .HasForeignKey(ts => ts.TrainId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ts => ts.SeatingClass)
                    .WithMany(sc => sc.TrainSeats)
                    .HasForeignKey(ts => ts.SeatingClassId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.DepartureTime).IsRequired().HasColumnType("DATETIME2");
                entity.Property(e => e.ArrivalTime).IsRequired().HasColumnType("DATETIME2");
                entity.Property(e => e.TimeDifference).IsRequired(false);

                entity.HasOne(t => t.Train)
                    .WithMany(tr => tr.Trips)
                    .HasForeignKey(t => t.TrainId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.OriginStation)
                    .WithMany(s => s.TripsFrom)
                    .HasForeignKey(t => t.OriginStationId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.DestinationStation)
                    .WithMany(s => s.TripsTo)
                    .HasForeignKey(t => t.DestinationStationId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Price).IsRequired();
                entity.Property(e => e.SeatingPlace).IsRequired().HasMaxLength(8);

                entity.HasOne(t => t.Trip)
                    .WithMany(tr => tr.Tickets)
                    .HasForeignKey(t => t.TripId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.CustomerCard)
                    .WithMany(cc => cc.BoughtTickets)
                    .HasForeignKey(t => t.CustomerCardId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<CustomerCard>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(128);
                entity.Property(e => e.Type).HasDefaultValue(CardType.Normal);
            });
        }
	}
}