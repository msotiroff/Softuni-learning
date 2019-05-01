namespace SoftUniGameStore.Models
{
    using SoftUniGameStore.Models.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Games = new HashSet<UserGame>();
            this.Roles = new HashSet<UserRole>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(ModelConstants.UsernameMinLength)]
        [MaxLength(ModelConstants.UsernameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public ICollection<UserGame> Games { get; set; }
        
        public ICollection<UserRole> Roles { get; set; }

    }
}
