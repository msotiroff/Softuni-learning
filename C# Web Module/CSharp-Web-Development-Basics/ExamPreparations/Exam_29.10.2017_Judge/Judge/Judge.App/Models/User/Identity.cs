namespace Judge.App.Models.User
{
    using Judge.Common.AutoMapping;
    using Judge.Services.Models;

    public class Identity : IMapWith<LoggedInUserModel>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public bool  IsAdmin { get; set; }
    }
}
