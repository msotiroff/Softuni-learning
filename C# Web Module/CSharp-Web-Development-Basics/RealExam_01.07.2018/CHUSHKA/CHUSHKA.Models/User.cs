namespace CHUSHKA.Models
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.UserUsernameMinLength)]
        public string Username { get; set; }
        
        [Required]
        public string PassowrdHash { get; set; }

        [Required]
        [MinLength(ModelConstants.UserUsernameMinLength)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public bool IsAdmin { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}