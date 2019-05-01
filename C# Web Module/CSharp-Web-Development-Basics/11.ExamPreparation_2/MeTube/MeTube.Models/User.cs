namespace MeTube.Models
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Tubes = new HashSet<Tube>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(ModelConstants.UserFullNameMinLength)]
        public string Username { get; set; }

        [Required]
        public string PassowrdHash { get; set; }

        public ICollection<Tube> Tubes { get; set; }
    }
}