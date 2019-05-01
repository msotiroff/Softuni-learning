using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BookLibraryModification
{  
    class BookLibraryModification
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

            DateTime givenDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            foreach (var book in currentLibrary.Books
                .Where(b => b.ReleaseDate > givenDate)
                .OrderBy(b => b.ReleaseDate)
                .ThenBy(b => b.Title))
            {
                Console.WriteLine($"{book.Title} -> {book.ReleaseDate.ToString("dd.MM.yyyy")}");
            }


        }
    }
}
