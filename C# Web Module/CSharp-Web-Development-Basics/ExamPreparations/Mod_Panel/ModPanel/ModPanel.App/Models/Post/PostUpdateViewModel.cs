namespace ModPanel.App.Models.Post
{
    using ModPanel.Models.Common;
    using System.ComponentModel.DataAnnotations;

    public class PostUpdateViewModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(ModelConstants.TitlePattern, ErrorMessage = ModelConstants.TitleErrorMessage)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
