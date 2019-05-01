using System.Collections.Generic;

namespace Library.Web.Models.Author
{
    public class AuthorDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<BookConciseViewModel> Books { get; set; }
    }
}
