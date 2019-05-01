namespace MeTube.App.Models.User
{
    using MeTube.Common.AutoMapping;
    using MeTube.Services.Models.User;

    public class Identity : IMapWith<LoggedInUserModel>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
    }
}
