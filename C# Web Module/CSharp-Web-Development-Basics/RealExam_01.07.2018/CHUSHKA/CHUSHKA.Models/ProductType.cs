namespace CHUSHKA.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}