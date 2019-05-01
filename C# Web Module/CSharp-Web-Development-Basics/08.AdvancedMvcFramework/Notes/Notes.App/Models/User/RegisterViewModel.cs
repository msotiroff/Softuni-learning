using System.ComponentModel.DataAnnotations;

namespace Notes.App.Models.User
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
