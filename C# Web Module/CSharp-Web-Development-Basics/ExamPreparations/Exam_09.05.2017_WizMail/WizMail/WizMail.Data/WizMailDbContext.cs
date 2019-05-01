namespace WizMail.Data
{
    using Configurations;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class WizMailDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<UserEmail> UserEmails { get; set; }
        public DbSet<Flag> Flags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(SqlServerConfig.ConnectionString);

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new EmailConfig());
            builder.ApplyConfiguration(new UserEmailConfig());

            base.OnModelCreating(builder);
        }
    }
}
