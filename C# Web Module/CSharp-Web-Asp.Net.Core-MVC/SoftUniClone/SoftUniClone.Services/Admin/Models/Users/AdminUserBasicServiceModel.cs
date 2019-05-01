namespace SoftUniClone.Services.Admin.Models.Users
{
    using Common.Mapping;
    using SoftUniClone.Models;

    public class AdminUserBasicServiceModel : IAutoMapWith<User>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}