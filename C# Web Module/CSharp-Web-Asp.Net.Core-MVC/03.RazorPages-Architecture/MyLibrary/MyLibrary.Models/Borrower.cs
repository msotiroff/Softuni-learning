namespace MyLibrary.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Borrower
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
