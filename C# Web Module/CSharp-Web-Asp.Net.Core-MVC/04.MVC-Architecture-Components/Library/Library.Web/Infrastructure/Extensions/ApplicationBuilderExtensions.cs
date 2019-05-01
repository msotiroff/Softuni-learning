namespace Library.Web.Infrastructure.Extensions
{
    using Library.Data;
    using Library.Models;
    using Library.Web.Models.Book;
    using Library.Web.Models.Movie;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<LibraryDbContext>();

                context.Database.Migrate();

                if (!context.Books.Any())
                {
                    var jsonBooks = File.ReadAllText(@"wwwroot\seedfiles\books.json");
                    var bookDtos = JsonConvert.DeserializeObject<BookDto[]>(jsonBooks);

                    SeedAuthors(context, bookDtos);
                    SeedBooks(context, bookDtos);
                }

                if (!context.Movies.Any())
                {
                    var jsonMovies = File.ReadAllText(@"wwwroot\seedfiles\movies.json");
                    var movieDtos = JsonConvert.DeserializeObject<MovieDto[]>(jsonMovies);

                    SeedDirectors(context, movieDtos);
                    SeedMovies(context, movieDtos);
                }
            }

            return app;
        }

        private static void SeedMovies(LibraryDbContext context, MovieDto[] movieDtos)
        {
            var moviesToCreate = movieDtos
                .Select(m => new Movie
                {
                    Title = m.Title,
                    Description = m.Description,
                    YouTubeTrailerId = m.YouTubeTrailerId,
                    Directors = m.Directors
                    .Select(d => new MovieDirector
                    {
                        DirectorId = context.Directors.First(dir => dir.Name == d).Id
                    })
                    .ToArray()
                })
                .ToArray();

            context.Movies.AddRange(moviesToCreate);
            context.SaveChanges();
        }

        private static void SeedDirectors(LibraryDbContext context, MovieDto[] movieDtos)
        {
            var directorsToSeed = movieDtos
                .SelectMany(m => m.Directors)
                .ToHashSet()
                .Select(d => new Director { Name = d });

            context.Directors.AddRange(directorsToSeed);
            context.SaveChanges();
        }

        private static void SeedBooks(LibraryDbContext context, BookDto[] bookDtos)
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

        private static void SeedAuthors(LibraryDbContext context, BookDto[] bookDtos)
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
