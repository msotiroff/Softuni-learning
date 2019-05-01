namespace Airport.Models
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(ModelConstants.UserNameMinLength)]
        public string Name { get; set; }

        [Required]
        public string PassowrdHash { get; set; }

        public bool IsAdmin { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}