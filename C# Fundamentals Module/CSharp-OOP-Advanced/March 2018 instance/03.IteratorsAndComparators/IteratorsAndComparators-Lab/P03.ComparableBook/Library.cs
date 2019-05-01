using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Library : IEnumerable<Book>
{
    public Library(params Book[] books)
    {
        this.Books = new SortedSet<Book>(books);
    }

    public SortedSet<Book> Books { get; private set; } = new SortedSet<Book>();

    public IEnumerator<Book> GetEnumerator() => new LibraryIterator(this.Books);

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private class LibraryIterator : IEnumerator<Book>
    {
        private IList<Book> books;
        private int currentIndex;

        public LibraryIterator(SortedSet<Book> books)
        {
            this.books = books.ToList();
            this.currentIndex = -1;
        }

        public Book Current => this.books[currentIndex];

        object IEnumerator.Current => this.Current;
        
        public bool MoveNext() => ++this.currentIndex < this.books.Count;

        public void Reset() => this.currentIndex = -1;

        public void Dispose()
        {
        }
    }
}
