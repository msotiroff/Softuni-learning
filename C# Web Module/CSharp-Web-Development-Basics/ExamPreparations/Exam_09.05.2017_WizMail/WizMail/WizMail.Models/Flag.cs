namespace WizMail.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Flag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}