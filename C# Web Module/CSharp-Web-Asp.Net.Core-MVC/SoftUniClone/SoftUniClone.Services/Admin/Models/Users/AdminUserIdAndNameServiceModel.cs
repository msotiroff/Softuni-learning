namespace SoftUniClone.Services.Admin.Models.Users
{
    using Common.Mapping;
    using SoftUniClone.Models;

    public class AdminUserIdAndNameServiceModel : IAutoMapWith<User>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}