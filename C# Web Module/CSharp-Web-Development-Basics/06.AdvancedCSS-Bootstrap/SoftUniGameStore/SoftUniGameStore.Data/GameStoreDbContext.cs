namespace SoftUniGameStore.Data
{
    using Microsoft.EntityFrameworkCore;
    using SoftUniGameStore.Data.Configurations;
    using SoftUniGameStore.Models;

    public class GameStoreDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(SqlServerConfig.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserRoleConfig());
            builder.ApplyConfiguration(new UserGameConfig());
            builder.ApplyConfiguration(new UserConfig());

            base.OnModelCreating(builder);
        }
    }
}
