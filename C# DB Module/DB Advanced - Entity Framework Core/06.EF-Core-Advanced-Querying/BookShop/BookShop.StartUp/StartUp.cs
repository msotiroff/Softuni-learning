namespace BookShop
{
    using System;
    using System.Linq;

    using BookShop.Data;
    using BookShop.Initializer;
    using System.Text;
    using BookShop.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;

    public class StartUp
    {
        public static void Main()
        {
            //using (var db = new BookShopContext())
            //{
            //    DbInitializer.ResetDatabase(db);
            //}

            string command = Console.ReadLine();
            //int year = int.Parse(command);
            //int count = int.Parse(command);

            var db = new BookShopContext();

            //string result = GetBooksByAgeRestriction(db, command);
            //string result = GetGoldenBooks(db);
            //string result = GetBooksByPrice(db);
            //string result = GetBooksNotRealeasedIn(db, year);
            //string result = GetBooksByCategory(db, command);
            //string result = GetBooksReleasedBefore(db, command);
            //string result = GetAuthorNamesEndingIn(db, command);
            //string result = GetBookTitlesContaining(db, command);
            //string result = GetBooksByAuthor(db, command);
            //int result = CountBooks(db, count);
            //string result = CountCopiesByAuthor(db);
            //string result = GetTotalProfitByCategory(db);
            //string result = GetMostRecentBooks(db);
            //IncreasePrices(db);
            //int removedBooks = RemoveBooks(db);

            //Console.WriteLine(result);
            //Console.WriteLine($"{removedBooks} books were deleted");

            db.Dispose();
        }

        public static int RemoveBooks(BookShopContext db)
        {
            var booksToBeDeleted = db
                .Books
                .Where(b => b.Copies < 4200)
                .ToList();

            int deletedBooks = booksToBeDeleted.Count();

            db.Books.RemoveRange(booksToBeDeleted);
            db.SaveChanges();

            return deletedBooks;
        }

        public static void IncreasePrices(BookShopContext db)
        {
            var booksToIncreasePrice = db
                .Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            booksToIncreasePrice.ForEach(b => b.Price += 5);

            db.SaveChanges();
        }

        public static string GetMostRecentBooks(BookShopContext db)
        {
            var categories = db
                .Categories
                .Include(c => c.CategoryBooks)
                .ThenInclude(cb => cb.Book)
                .ToList();

            var result = new StringBuilder();

            foreach (var category in categories.OrderBy(c => c.Name))
            {
                result.AppendLine($"--{category.Name}");

                foreach (var categoryBook in category.CategoryBooks
                    .OrderByDescending(cb => cb.Book.ReleaseDate)
                    .Take(3))
                {
                    result.AppendLine($"{categoryBook.Book.Title} ({categoryBook.Book.ReleaseDate.Value.Year})");
                }
            }

            return result.ToString();
        }

        public static string GetTotalProfitByCategory(BookShopContext db)
        {
            var categories = db
                .Categories
                .Include(c => c.CategoryBooks)
                .Select(c => new
                {
                    Name = c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Copies * cb.Book.Price)
                })
                .OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name)
                .ToList();

            var result = new StringBuilder();

            categories.ForEach(c => result.AppendLine($"{c.Name} ${c.Profit:f2}"));

            return result.ToString();
        }

        public static string CountCopiesByAuthor(BookShopContext db)
        {
            var books = db
                .Authors
                .Include(a => a.Books)
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    Copies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(x => x.Copies)
                .ToList();

            var result = new StringBuilder();

            books.ForEach(x => result.AppendLine($"{x.Name} - {x.Copies}"));

            return result.ToString();
        }

        public static int CountBooks(BookShopContext db, int count)
        {
            var booksCount = db
                .Books
                .Where(b => b.Title.Length > count)
                .Count();

            return booksCount;
        }

        public static string GetBooksByAuthor(BookShopContext db, string startLastName)
        {
            var books = db
                .Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(startLastName.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToList();

            var result = new StringBuilder();

            books.ForEach(b => result.AppendLine(b));

            return result.ToString();
        }

        public static string GetBookTitlesContaining(BookShopContext db, string containString)
        {
            var books = db
                .Books
                .Where(b => b.Title.ToLower().Contains(containString.ToLower()))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            var result = new StringBuilder();

            books.ForEach(b => result.AppendLine(b));

            return result.ToString().Trim();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext db, string nameEnd)
        {
            var authors = db
                .Authors
                .Where(a => a.FirstName.EndsWith(nameEnd))
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(a => a.Name)
                .ToList();

            var result = new StringBuilder();

            authors.ForEach(a => result.AppendLine(a.Name));

            return result.ToString();
        }

        public static string GetBooksReleasedBefore(BookShopContext db, string dateAsString)
        {
            DateTime convertedDate = DateTime.ParseExact(dateAsString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var books = db.Books
                .Where(b => b.ReleaseDate < convertedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price}")
                .ToList();

            var result = String.Join(Environment.NewLine, books);
            return result;
            //DateTime releaseDate = DateTime.ParseExact(dateAsString, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            //var books = db
            //    .Books
            //    .Where(b => b.ReleaseDate < releaseDate)
            //    .OrderByDescending(b => b.ReleaseDate)
            //    .Select(b => new
            //    {
            //        Title = b.Title,
            //        EditionType = b.EditionType,
            //        Price = b.Price
            //    })
            //    .ToList();

            //if (books.Count == 0)
            //{
            //    return string.Empty;
            //}

            //var result = new StringBuilder();

            //books.ForEach(b => result.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}"));

            //return result.ToString();
        }

        public static string GetBooksByCategory(BookShopContext db, string command)
        {
            var inputCategories = command
                .Split(new  char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToList();

            var booksByCategory = db
                .Books
                .Where(b => b.BookCategories.Any(c => inputCategories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            var result = new StringBuilder();

            booksByCategory.ForEach(b => result.AppendLine(b));

            return result.ToString();
        }

        public static string GetBooksNotRealeasedIn(BookShopContext db, int year)
        {
            var books = db
                .Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = new StringBuilder();

            books.ForEach(b => result.AppendLine(b));

            return result.ToString();
        }

        public static string GetBooksByPrice(BookShopContext db)
        {
            var booksByPrice = db
                .Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            var result = new StringBuilder();

            booksByPrice
                .ForEach(b => result.AppendLine($"{b.Title} - ${b.Price:f2}"));

            return result.ToString();
        }

        public static string GetGoldenBooks(BookShopContext db)
        {
            var goldenBooks = db
                .Books
                .Where(b => b.Copies < 5000 && b.EditionType == EditionType.Gold)
                .Select(b => new
                {
                    Title = b.Title,
                    Id = b.BookId
                })
                .OrderBy(b => b.Id)
                .ToList();

            var result = new StringBuilder();

            goldenBooks.ForEach(gb => result.AppendLine(gb.Title));

            return result.ToString();
        }

        public static string GetBooksByAgeRestriction(BookShopContext db, string command)
        {
            int ageRestriction = 0;

            switch (command.ToLower())
            {
                case "minor":
                    ageRestriction = 0;
                    break;
                case "teen":
                    ageRestriction = 1;
                    break;
                case "adult":
                    ageRestriction = 2;
                    break;
                default:
                    break;
            }

            var titles = db
                .Books
                .Where(b => (int)b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var result = new StringBuilder();

            titles.ForEach(t => result.AppendLine(t));

            return result.ToString();
        }
    }
}