namespace CHUSHKA.Data.Configurations
{
    using CHUSHKA.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasIndex(u => u.Email)
                .IsUnique(true);

            builder
                .HasIndex(u => u.Username)
                .IsUnique(true);

            builder
                .HasMany(u => u.Orders)
                .WithOne(o => o.Client)
                .HasForeignKey(o => o.ClientId);
        }
    }
}
