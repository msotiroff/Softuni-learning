namespace KittenShop.Data.Configurations
{
    using KittenShop.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasAlternateKey(u => u.Email);

            builder
                .HasMany(u => u.Kittens)
                .WithOne(k => k.Owner)
                .HasForeignKey(k => k.OwnerId);
        }
    }
}
