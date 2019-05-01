namespace WizMail.App.Models.Mail
{
    using System.ComponentModel.DataAnnotations;

    public class EmailCreateViewModel
    {
        [Required]
        public string Recipients { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

        public string Attachment { get; set; }

        public string Save { get; set; }

        public string Send { get; set; }
    }
}
