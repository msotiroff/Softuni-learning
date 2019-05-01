namespace MeTube.App.Models.Tube
{
    using MeTube.Models.Common;
    using System.ComponentModel.DataAnnotations;

    public class TubeUploadViewModel
    {
        [Required]
        [MinLength(ModelConstants.TitleMinLenght)]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        [Url]
        [Required]
        [Display(Name = "YouTube link")]
        public string YouTubeLink { get; set; }
    }
}
