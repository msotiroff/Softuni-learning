namespace SoftUniGameStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using SoftUniGameStore.Models;

    public class UserGameConfig : IEntityTypeConfiguration<UserGame>
    {
        public void Configure(EntityTypeBuilder<UserGame> builder)
        {
            builder.HasKey(ug => new { ug.UserId, ug.GameId });

            builder
                .HasOne(ur => ur.User)
                .WithMany(u => u.Games)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(ur => ur.Game)
                .WithMany(u => u.Users)
                .HasForeignKey(ur => ur.GameId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
