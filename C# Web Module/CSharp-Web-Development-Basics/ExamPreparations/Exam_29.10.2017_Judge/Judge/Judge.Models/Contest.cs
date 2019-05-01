namespace Judge.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Contest
    {
        public Contest()
        {
            this.Submissions = new HashSet<Submission>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{1}[A-Za-z\s]{2,99}$")]
        public string Name { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}
