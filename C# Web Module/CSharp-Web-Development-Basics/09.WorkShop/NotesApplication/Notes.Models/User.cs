namespace Notes.Models
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Notes = new HashSet<Note>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(ModelConstants.UsernameMinLength)]
        public string Username { get; set; }

        [Required]
        public string PassowrdHash { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
