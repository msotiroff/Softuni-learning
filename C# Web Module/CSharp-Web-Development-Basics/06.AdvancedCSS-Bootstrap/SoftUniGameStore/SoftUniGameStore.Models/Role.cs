namespace SoftUniGameStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<UserRole>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<UserRole> Users { get; set; }
    }
}