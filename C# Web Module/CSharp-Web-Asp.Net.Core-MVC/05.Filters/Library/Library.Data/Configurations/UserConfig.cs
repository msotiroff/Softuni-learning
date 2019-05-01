namespace Library.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Library.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasIndex(u => u.Username)
                .IsUnique(true);
        }
    }
}
