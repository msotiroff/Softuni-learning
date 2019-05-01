using System.ComponentModel.DataAnnotations;

namespace HTTPServer.ByTheCakeApplication.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        [Required]
        [MinLength(3)]
        public string Username { get; set; }

        [Required]
        [MinLength(3)]
        public string Password { get; set; }
    }
}
