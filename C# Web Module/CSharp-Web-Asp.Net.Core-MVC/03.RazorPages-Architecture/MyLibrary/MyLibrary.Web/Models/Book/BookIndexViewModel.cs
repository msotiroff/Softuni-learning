using MyLibrary.Web.Models.Author;
using System.Collections.Generic;

namespace MyLibrary.Web.Models
{
    public class BookIndexViewModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Status { get; set; }
        
        public List<AuthorViewModel> Authors { get; set; }
    }
}
