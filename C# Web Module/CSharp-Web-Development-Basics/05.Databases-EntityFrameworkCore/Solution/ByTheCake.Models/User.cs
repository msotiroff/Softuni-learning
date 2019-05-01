namespace ByTheCake.Models
{
    using Common;
    using System;
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
        [MinLength(ModelConstants.UserNameMinLength)]
        [MaxLength(ModelConstants.UserNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ModelConstants.UserUsernameMinLength)]
        [MaxLength(ModelConstants.UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
