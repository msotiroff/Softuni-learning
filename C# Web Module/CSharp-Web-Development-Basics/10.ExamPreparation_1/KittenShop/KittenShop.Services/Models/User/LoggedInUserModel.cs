namespace KittenShop.Services.Models.User
{
    using KittenShop.Common.AutoMapping;
    using KittenShop.Models;

    public class LoggedInUserModel : IMapWith<User>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
    }
}
