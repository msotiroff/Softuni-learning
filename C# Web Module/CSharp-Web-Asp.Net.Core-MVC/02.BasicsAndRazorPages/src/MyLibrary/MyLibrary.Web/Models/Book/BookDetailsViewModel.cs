using System.Collections.Generic;

namespace MyLibrary.Web.Models
{
    public class BookDetailsViewModel
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string CoverImageUrl { get; set; }

        public string Status { get; set; }

        public IEnumerable<AuthorViewModel> Authors { get; set; }
    }
}
