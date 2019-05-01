namespace KittenShop.Models
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Kittens = new HashSet<Kitten>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(ModelConstants.UsernameMinLength)]
        public string Username { get; set; }

        [Required]
        public string PassowrdHash { get; set; }

        public ICollection<Kitten> Kittens { get; set; }
    }
}