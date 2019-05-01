namespace WizMail.Services.Models.User
{
    using WizMail.Common.AutoMapping;
    using WizMail.Models;

    public class LoggedInUserModel : IMapWith<User>
    {
        public int Id { get; set; }
        
        public string Username { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string EmailAddress { get; set; }
    }
}
