namespace ModPanel.Services.Models.User
{
    using ModPanel.Common.AutoMapping;
    using ModPanel.Models;

    public class LoggedInUserModel : IMapWith<User>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string PositionName { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsApproved { get; set; }
    }
}
