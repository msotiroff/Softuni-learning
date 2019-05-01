namespace ModPanel.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PassowrdHash { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsApproved { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}