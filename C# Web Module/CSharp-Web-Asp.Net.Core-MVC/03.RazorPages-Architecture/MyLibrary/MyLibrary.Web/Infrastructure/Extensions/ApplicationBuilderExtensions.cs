namespace MyLibrary.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MyLibrary.Data;
    using MyLibrary.Models;
    using MyLibrary.Web.Models.Book;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<MyLibraryDbContext>();

                context.Database.Migrate();

                if (!context.Books.Any())
                {
                    var jsonBooks = File.ReadAllText(@"wwwroot\seedfiles\books.json");
                    var bookDtos = JsonConvert.DeserializeObject<BookDto[]>(jsonBooks);

                    SeedAuthors(context, bookDtos);

                    SeedBooks(context, bookDtos);
                }
            }

            return app;
        }

        private static void SeedBooks(MyLibraryDbContext context, BookDto[] bookDtos)
        {
            var booksToCreate = bookDtos
                .Select(b => new Book
                {
                    Title = b.Title,
                    Description = b.Description,
                    CoverImageUrl = b.CoverImageUrl,
                    Authors = b.Authors
                    .Select(a => new BookAuthor
                    {
                        AuthorId = context.Authors.First(au => au.Name == a).Id
                    })
                    .ToArray()
                })
                .ToArray();

            context.Books.AddRange(booksToCreate);
            context.SaveChanges();
        }

        private static void SeedAuthors(MyLibraryDbContext context, BookDto[] bookDtos)
        {
            var authorsToCreate = bookDtos
                .SelectMany(b => b.Authors)
                .ToHashSet()
                .Select(a => new Author { Name = a });

            context.Authors.AddRange(authorsToCreate);

            context.SaveChanges();
        }
    }
}
