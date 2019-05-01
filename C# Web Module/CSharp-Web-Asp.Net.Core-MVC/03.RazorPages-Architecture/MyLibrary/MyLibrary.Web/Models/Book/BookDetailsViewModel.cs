using MyLibrary.Web.Models.Author;
using System.Collections.Generic;

namespace MyLibrary.Web.Models
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string CoverImageUrl { get; set; }

        public bool IsBorrowed { get; set; }

        public string Status { get; set; }

        public IEnumerable<AuthorViewModel> Authors { get; set; }
    }
}
