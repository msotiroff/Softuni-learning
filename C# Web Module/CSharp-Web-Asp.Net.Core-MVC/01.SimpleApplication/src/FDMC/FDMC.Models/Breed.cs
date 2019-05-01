namespace FDMC.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Breed
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public IEnumerable<Cat> Cats { get; set; } = new HashSet<Cat>();
    }
}
