namespace Library.Data.Configurations
{
    using Library.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BorrowerConfig : IEntityTypeConfiguration<Borrower>
    {
        public void Configure(EntityTypeBuilder<Borrower> builder)
        {
            builder
                .HasMany(b => b.BorrowedBooks)
                .WithOne(bb => bb.Borrower)
                .HasForeignKey(bb => bb.BorrowerId);

            builder
                .HasMany(b => b.BorrowedMovies)
                .WithOne(bm => bm.Borrower)
                .HasForeignKey(bm => bm.BorrowerId);
        }
    }
}
