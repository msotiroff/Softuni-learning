namespace Library.Data.Configurations
{
    using Library.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MovieDirectorConfig : IEntityTypeConfiguration<MovieDirector>
    {
        public void Configure(EntityTypeBuilder<MovieDirector> builder)
        {
            builder
                .HasKey(md => new { md.MovieId, md.DirectorId });

            builder
                .HasOne(md => md.Director)
                .WithMany(d => d.Movies)
                .HasForeignKey(md => md.DirectorId);

            builder
                .HasOne(md => md.Movie)
                .WithMany(m => m.Directors)
                .HasForeignKey(md => md.MovieId);
        }
    }
}
