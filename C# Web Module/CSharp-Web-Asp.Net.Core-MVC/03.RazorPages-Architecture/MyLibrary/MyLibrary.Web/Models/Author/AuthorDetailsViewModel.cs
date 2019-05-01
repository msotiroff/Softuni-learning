using System.Collections.Generic;

namespace MyLibrary.Web.Models.Author
{
    public class AuthorDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<BookConciseViewModel> Books { get; set; }
    }
}
