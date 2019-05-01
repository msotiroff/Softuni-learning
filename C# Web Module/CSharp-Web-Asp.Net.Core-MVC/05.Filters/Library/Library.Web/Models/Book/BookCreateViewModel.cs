namespace Library.Web.Models.Book
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BookCreateViewModel
    {
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Url]
        [Required]
        [Display(Name = "Cover Image Url")]
        public string CoverImageUrl { get; set; }

        public IEnumerable<string> SelectedAuthors { get; set; } = new List<string>();

        public IEnumerable<SelectListItem> AllAuthors { get; set; }
    }
}
