namespace Judge.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Submission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ExecutableCode { get; set; }

        public bool Compiled { get; set; }

        public int ContestId { get; set; }

        public Contest Contest { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
