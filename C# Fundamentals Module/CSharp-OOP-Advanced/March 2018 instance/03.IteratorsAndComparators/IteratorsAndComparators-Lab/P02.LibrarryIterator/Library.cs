using System.Collections;
using System.Collections.Generic;

public class Library : IEnumerable<Book>
{
    public Library(params Book[] books)
    {
        this.Books = books;
    }

    public IList<Book> Books { get; private set; } = new List<Book>();

    public IEnumerator<Book> GetEnumerator() => new LibraryIterator(this.Books);

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private class LibraryIterator : IEnumerator<Book>
    {
        private IList<Book> books;
        private int currentIndex;

        public LibraryIterator(IList<Book> books)
        {
            this.books = books;
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
