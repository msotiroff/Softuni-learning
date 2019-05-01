namespace Library.Web.Models.Movie
{
    using Library.Web.Models.Interfaces;
    using System.Collections.Generic;

    public class MovieIndexViewModel : ILibraryEntry
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Status { get; set; }
        
        public List<IOriginator> Originators { get; set; }
    }
}
