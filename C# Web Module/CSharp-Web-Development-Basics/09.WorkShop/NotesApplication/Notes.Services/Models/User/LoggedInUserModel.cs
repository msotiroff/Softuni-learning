namespace Notes.Services.Models.User
{
    using Notes.Common.AutoMapping;
    using Notes.Models;

    public class LoggedInUserModel : IMapWith<User>
    {
        public int Id { get; set; }

        public string Username { get; set; }
    }
}
