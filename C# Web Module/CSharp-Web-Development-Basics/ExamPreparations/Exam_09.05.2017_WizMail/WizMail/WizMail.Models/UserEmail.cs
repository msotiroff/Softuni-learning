namespace WizMail.Models
{
    public class UserEmail
    {
        public int EmailId { get; set; }

        public Email Email { get; set; }

        public int RecipientId { get; set; }

        public User Recipient { get; set; }
    }
}