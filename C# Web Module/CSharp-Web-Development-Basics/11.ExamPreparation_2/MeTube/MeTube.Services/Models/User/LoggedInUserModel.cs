namespace MeTube.Services.Models.User
{
    using MeTube.Common.AutoMapping;
    using MeTube.Models;

    public class LoggedInUserModel : IMapWith<User>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
    }
}
