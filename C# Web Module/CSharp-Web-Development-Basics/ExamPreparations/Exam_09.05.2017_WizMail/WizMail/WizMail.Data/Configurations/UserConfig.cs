namespace WizMail.Data.Configurations
{
    using WizMail.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasIndex(u => u.Username)
                .IsUnique(true);

            builder
                .HasMany(u => u.SentEmails)
                .WithOne(e => e.Sender)
                .HasForeignKey(e => e.SenderId);

            builder
                .HasMany(u => u.RecievedEmails)
                .WithOne(re => re.Recipient)
                .HasForeignKey(re => re.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
