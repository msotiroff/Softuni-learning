using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Web.Models.Book
{
    public class BookDto
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string CoverImageUrl { get; set; }
        
        public IEnumerable<string> Authors { get; set; }
    }
}
