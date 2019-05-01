namespace WizMail.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using WizMail.Models;

    internal class UserEmailConfig : IEntityTypeConfiguration<UserEmail>
    {
        public void Configure(EntityTypeBuilder<UserEmail> builder)
        {
            builder
                .HasKey(ue => new { ue.EmailId, ue.RecipientId });
        }
    }
}
