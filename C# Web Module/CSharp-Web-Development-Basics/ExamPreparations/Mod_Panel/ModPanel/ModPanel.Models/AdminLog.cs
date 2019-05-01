namespace ModPanel.Models
{
    using ModPanel.Models.Common;
    using System.ComponentModel.DataAnnotations;

    public class AdminLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AdminId { get; set; }

        public User Admin { get; set; }

        [Required]
        public string Activity { get; set; }

        [Required]
        public LogType LogType { get; set; }
    }
}
