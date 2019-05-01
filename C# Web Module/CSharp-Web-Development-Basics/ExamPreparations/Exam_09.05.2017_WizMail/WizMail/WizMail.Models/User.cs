namespace WizMail.Models
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private string emailAddress;

        public User()
        {
            this.SentEmails = new HashSet<Email>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(ModelConstants.UsernamePattern, ErrorMessage = ModelConstants.UsernameValidationErrorMsg)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        [Required]
        public string PassowrdHash { get; set; }

        public ICollection<Email> SentEmails { get; set; }

        public ICollection<UserEmail> RecievedEmails { get; set; }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}