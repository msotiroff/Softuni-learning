using MyLibrary.Web.Models.Author;
using System.Collections.Generic;

namespace MyLibrary.Web.Models.Search
{
    public class SearchResultViewModel
    {
        public string SearchTerm { get; set; }

        public IEnumerable<BookConciseViewModel> Books { get; set; }

        public IEnumerable<AuthorViewModel> Authors { get; set; }
    }
}
