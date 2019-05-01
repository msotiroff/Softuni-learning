namespace ModPanel.App.Models.User
{
    using ModPanel.Common.AutoMapping;
    using ModPanel.Services.Models.User;

    public class Identity : IMapWith<LoggedInUserModel>
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string PositionName { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsApproved { get; set; }
    }
}
