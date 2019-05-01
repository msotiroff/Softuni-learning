namespace Library.Web.Models.Movie
{
    using System.Collections.Generic;

    public class MovieDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string YouTubeTrailerId { get; set; }

        public ICollection<string> Directors { get; set; }
    }
}
