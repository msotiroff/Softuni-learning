using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BookLibrary
{
    class BookLibrary
    {
        static void Main(string[] args)
        {
            Library currentLibrary = new Library()
            {
                Name = "Library",
                Books = new List<Book>()
            };

            int numberOfBooks = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBooks; i++)
            {                                                 // dd.MM.yyyy
                // Input format: {title} {author} {publisher} {release date} {ISBN} {price}

                string[] currBookPropperties = Console.ReadLine().Split(' ');

                Book currentBook = new Book()
                {
                    Title = currBookPropperties[0],
                    Author = currBookPropperties[1],
                    Publisher = currBookPropperties[2],
                    ReleaseDate = DateTime.ParseExact(currBookPropperties[3], "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    ISBNnumber = int.Parse(currBookPropperties[4]),
                    Price = double.Parse(currBookPropperties[5])
                };

                currentLibrary.Books.Add(currentBook);
            }


            Dictionary<string, double> allAuthors = new Dictionary<string, double>();

            foreach (var book in currentLibrary.Books)
            {
                string currentAuthor = book.Author;
                double currentPrice = book.Price;

                if (!allAuthors.ContainsKey(currentAuthor))
                {
                    allAuthors[currentAuthor] = 0;
                }
                allAuthors[currentAuthor] += currentPrice;
            }


            foreach (var author in allAuthors.OrderByDescending(au => au.Value).ThenBy(au => au.Key))
            {
                Console.WriteLine($"{author.Key} -> {author.Value:f2}");
            }

        }
    }
}
