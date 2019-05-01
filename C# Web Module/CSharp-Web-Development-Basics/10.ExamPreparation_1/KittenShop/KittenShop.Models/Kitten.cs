namespace KittenShop.Models
{
    using global::KittenShop.Models.Common;
    using System.ComponentModel.DataAnnotations;

    public class Kitten
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.CatNameMinLength)]
        public string Name { get; set; }

        [Range(1, 20)]
        public int Age { get; set; }

        [Required]
        public int BreedId { get; set; }

        public Breed Breed { get; set; }

        [Required]
        public int OwnerId { get; set; }

        public User Owner { get; set; }

        public override int GetHashCode()
        {
            return this.Id;
        }
    }
}