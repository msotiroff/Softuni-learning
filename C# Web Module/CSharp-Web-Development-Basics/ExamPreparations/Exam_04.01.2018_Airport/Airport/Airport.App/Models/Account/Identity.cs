namespace Airport.App.Models.User
{
    using Airport.Common.AutoMapping;
    using Airport.Services.Models.User;

    public class Identity : IMapWith<LoggedInUserModel>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public bool  IsAdmin { get; set; }
    }
}
