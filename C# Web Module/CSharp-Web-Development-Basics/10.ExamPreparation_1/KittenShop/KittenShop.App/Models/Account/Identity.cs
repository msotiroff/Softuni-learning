namespace KittenShop.App.Models.User
{
    using KittenShop.Common.AutoMapping;
    using KittenShop.Services.Models.User;

    public class Identity : IMapWith<LoggedInUserModel>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
    }
}
