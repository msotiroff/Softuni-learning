namespace Judge.Services.Models
{
    using Common.AutoMapping;
    using Judge.Models;

    public class LoggedInUserModel : IMapWith<User>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public bool IsAdmin { get; set; }
    }
}
