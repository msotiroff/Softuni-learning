namespace Airport.Services.Models.User
{
    using Airport.Common.AutoMapping;
    using Airport.Models;

    public class LoggedInUserModel : IMapWith<User>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public bool IsAdmin { get; set; }
    }
}
