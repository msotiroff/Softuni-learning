namespace CHUSHKA.App.Models.User
{
    using CHUSHKA.Common.AutoMapping;
    using CHUSHKA.Services.Models.User;

    public class Identity : IMapWith<LoggedInUserModel>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public bool IsAdmin { get; set; }
    }
}
