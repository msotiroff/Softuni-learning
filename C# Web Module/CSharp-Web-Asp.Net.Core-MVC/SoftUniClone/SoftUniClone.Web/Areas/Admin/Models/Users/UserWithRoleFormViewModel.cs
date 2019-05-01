namespace SoftUniClone.Web.Areas.Admin.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class UserWithRoleFormViewModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }
}