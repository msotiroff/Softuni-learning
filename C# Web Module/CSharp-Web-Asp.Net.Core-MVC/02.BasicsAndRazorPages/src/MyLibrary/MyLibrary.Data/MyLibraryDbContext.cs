namespace MyLibrary.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Models;

    public class MyLibraryDbContext : DbContext
    {
        public MyLibraryDbContext(DbContextOptions<MyLibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Borrower> Borrowers { get; set; }

        public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

            builder
                .Entity<Book>()
                .HasMany(b => b.Authors)
                .WithOne(a => a.Book)
                .HasForeignKey(a => a.BookId);

            builder
                .Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            base.OnModelCreating(builder);
        }
    }
}
