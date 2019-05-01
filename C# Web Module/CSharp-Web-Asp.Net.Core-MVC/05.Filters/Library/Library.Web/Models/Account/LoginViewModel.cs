using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(4)]
        public string Username { get; set; }

        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}
