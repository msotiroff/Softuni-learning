namespace Library.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsBorrowed { get; set; }

        [Required]
        [MinLength(11)]
        [MaxLength(11)]
        public string YouTubeTrailerId { get; set; }

        public ICollection<MovieDirector> Directors { get; set; }

        public ICollection<MovieStatus> Statuses { get; set; }
    }
}
