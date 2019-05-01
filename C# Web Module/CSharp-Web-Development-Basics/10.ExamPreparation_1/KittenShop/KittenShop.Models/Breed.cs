namespace KittenShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Breed
    {
        public Breed()
        {
            this.Kittens = new HashSet<Kitten>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Kitten> Kittens { get; set; }
    }
}