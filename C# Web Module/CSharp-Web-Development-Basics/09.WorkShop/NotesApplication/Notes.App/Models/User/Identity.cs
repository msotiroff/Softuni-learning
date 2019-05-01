namespace Notes.App.Models.User
{
    using Notes.Common.AutoMapping;
    using Notes.Services.Models.User;

    public class Identity : IMapWith<LoggedInUserModel>
    {
        public int Id { get; set; }
        
        public string Username { get; set; }
    }
}
