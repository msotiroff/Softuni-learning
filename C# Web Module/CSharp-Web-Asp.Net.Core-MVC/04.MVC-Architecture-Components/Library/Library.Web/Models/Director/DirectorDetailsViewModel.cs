namespace Library.Web.Models.Director
{
    using Library.Web.Models.Movie;
    using System.Collections.Generic;

    public class DirectorDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<MovieConciseViewModel> Movies { get; set; }
    }
}
