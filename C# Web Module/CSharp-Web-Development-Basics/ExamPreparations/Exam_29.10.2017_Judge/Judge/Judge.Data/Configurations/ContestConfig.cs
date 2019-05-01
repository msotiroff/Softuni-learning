namespace Judge.Data.Configurations
{
    using Judge.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ContestConfig : IEntityTypeConfiguration<Contest>
    {
        public void Configure(EntityTypeBuilder<Contest> builder)
        {
            builder
                .HasMany(c => c.Submissions)
                .WithOne(s => s.Contest)
                .HasForeignKey(s => s.ContestId);
        }
    }
}
