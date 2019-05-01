namespace FDMC.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Cat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public int BreedId { get; set; }

        public Breed Breed { get; set; }

        [Required]
        [Range(0, 20)]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateAdded { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
    }
}
