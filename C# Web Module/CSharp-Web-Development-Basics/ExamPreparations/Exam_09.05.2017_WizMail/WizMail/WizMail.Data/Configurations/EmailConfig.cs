namespace WizMail.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using WizMail.Models;

    internal class EmailConfig : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder
                .HasMany(e => e.Recipients)
                .WithOne(r => r.Email)
                .HasForeignKey(r => r.EmailId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
