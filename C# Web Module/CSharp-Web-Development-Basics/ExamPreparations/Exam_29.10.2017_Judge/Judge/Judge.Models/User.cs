namespace Judge.Models
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Contests = new HashSet<Contest>();
            this.Submissions = new HashSet<Submission>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(ModelConstants.UserFullNameMinLength)]
        public string FullName { get; set; }

        [Required]
        public string PassowrdHash { get; set; }

        public bool IsAdmin { get; set; }

        public ICollection<Contest> Contests { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}
