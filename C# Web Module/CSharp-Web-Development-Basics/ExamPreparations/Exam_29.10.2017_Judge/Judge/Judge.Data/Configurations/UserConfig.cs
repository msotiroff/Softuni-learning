namespace Judge.Data.Configurations
{
    using Judge.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasAlternateKey(u => u.Email);

            builder
                .HasMany(u => u.Submissions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(u => u.Contests)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}
