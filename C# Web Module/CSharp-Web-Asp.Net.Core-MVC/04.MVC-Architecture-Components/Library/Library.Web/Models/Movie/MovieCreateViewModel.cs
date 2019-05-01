namespace Library.Web.Models.Movie
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MovieCreateViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        
        [Required]
        [Url]
        [Display(Name = "YouTube link")]
        public string YouTubeLink { get; set; }

        public IEnumerable<string> SelectedDirectors { get; set; } = new List<string>();

        public IEnumerable<SelectListItem> AllDirectors { get; set; }
    }
}
