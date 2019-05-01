namespace WizMail.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Email
    {
        public Email()
        {
            this.Recipients = new HashSet<UserEmail>();
            this.SendDate = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

        public string Attachment { get; set; }

        [Required]
        public DateTime SendDate { get; set; }

        [Required]
        public int SenderId { get; set; }

        public User Sender { get; set; }

        public int FlagId { get; set; }

        public Flag Flag { get; set; }

        public ICollection<UserEmail> Recipients { get; set; }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
