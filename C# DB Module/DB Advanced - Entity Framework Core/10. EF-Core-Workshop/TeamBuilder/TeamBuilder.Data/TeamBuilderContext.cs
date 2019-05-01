namespace TeamBuilder.Data
{
    using Microsoft.EntityFrameworkCore;
    using TeamBuilder.Models;

    public class TeamBuilderContext : DbContext
    {
        public TeamBuilderContext()
        {
        }

        public TeamBuilderContext(DbContextOptions options)
            : base()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Invitation> Invitations { get; set; }

        public DbSet<TeamEvent> TeamEvents { get; set; }

        public DbSet<UserTeam> UserTeams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ServerConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Username).IsUnique(true);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Username).IsRequired(true);
                entity.Property(e => e.Password).IsRequired(true);
                entity.Property(e => e.FirstName).IsRequired(false);
                entity.Property(e => e.LastName).IsRequired(false);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Name).IsUnique(true);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired(true).HasMaxLength(25);
                entity.Property(e => e.Description).IsRequired(false).HasMaxLength(32);
                entity.Property(e => e.Acronym).IsRequired(true).HasColumnType("CHAR(3)");

                entity.HasOne(t => t.Creator)
                    .WithMany(c => c.CreatedTeams)
                    .HasForeignKey(t => t.CreatorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).IsRequired(true).HasMaxLength(25).IsUnicode(true);
                entity.Property(e => e.Description).IsRequired(false).HasMaxLength(250).IsUnicode(true);
                entity.Property(e => e.StartDate).IsRequired(false);
                entity.Property(e => e.EndDate).IsRequired(false);

                entity.HasOne(e => e.Creator)
                    .WithMany(c => c.CreatedEvents)
                    .HasForeignKey(e => e.CreatorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.IsActive).HasDefaultValue(true);

                entity.HasOne(i => i.InvitedUser)
                    .WithMany(iu => iu.RecievedInvitations)
                    .HasForeignKey(i => i.InvitedUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserTeam>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TeamId });

                entity.HasOne(ut => ut.Team)
                    .WithMany(t => t.UserTeams)
                    .HasForeignKey(ut => ut.TeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ut => ut.User)
                    .WithMany(u => u.UserTeams)
                    .HasForeignKey(ut => ut.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TeamEvent>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.EventId });

                entity.HasOne(te => te.Team)
                    .WithMany(t => t.TeamEvents)
                    .HasForeignKey(te => te.TeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(te => te.Event)
                    .WithMany(e => e.ParticipatingTeamEvents)
                    .HasForeignKey(te => te.EventId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
