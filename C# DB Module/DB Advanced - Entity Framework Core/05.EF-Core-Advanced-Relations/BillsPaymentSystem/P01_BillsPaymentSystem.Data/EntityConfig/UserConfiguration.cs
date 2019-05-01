namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
                builder.HasKey(u => u.UserId);

                builder
                .Property(u => u.FirstName)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

                builder
                .Property(u => u.LastName)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

                builder
                .Property(u => u.Email)
                .IsRequired(true)
                .HasMaxLength(80)
                .IsUnicode(false);

                builder
                .Property(u => u.Password)
                .IsRequired(true)
                .HasMaxLength(25)
                .IsUnicode(false);
        }
    }
}
