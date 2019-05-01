namespace MyLibrary.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BookCreateBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Url]
        public string CoverImageUrl { get; set; }

        [Required]
        public string Authors { get; set; }
    }
}
