namespace SoftUniGameStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Trailer { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string ImageThumbnail { get; set; }

        [Required]
        public double Size { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public ICollection<UserGame> Users { get; set; }
    }
}