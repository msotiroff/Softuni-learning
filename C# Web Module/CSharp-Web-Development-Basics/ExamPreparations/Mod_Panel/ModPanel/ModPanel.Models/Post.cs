namespace ModPanel.Models
{
    using ModPanel.Models.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(ModelConstants.TitlePattern, ErrorMessage = ModelConstants.TitleErrorMessage)]
        public string Title { get; set; }
        
        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }
    }
}