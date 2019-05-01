namespace Library.Web.Models.Movie
{
    using Library.Web.Models.Director;
    using System.Collections.Generic;

    public class MovieDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string YouTubeTrailerId { get; set; }

        public bool IsBorrowed { get; set; }

        public string Status { get; set; }

        public IEnumerable<DirectorViewModel> Directors { get; set; }
    }
}
