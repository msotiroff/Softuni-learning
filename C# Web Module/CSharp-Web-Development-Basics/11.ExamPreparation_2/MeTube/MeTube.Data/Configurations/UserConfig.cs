namespace MeTube.Data.Configurations
{
    using MeTube.Models;
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
                .HasMany(u => u.Tubes)
                .WithOne(t => t.Uploader)
                .HasForeignKey(t => t.UploaderId);
        }
    }
}
