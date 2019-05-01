namespace WizMail.Services.Implementations
{
    using AutoMapper;
    using Contracts;
    using System.Linq;
    using WizMail.Data;
    using WizMail.Models;
    using WizMail.Models.Common;
    using WizMail.Services.Models.User;

    public class UserService : DataAccessService, IUserService
    {
        public UserService(WizMailDbContext db) 
            : base(db)
        {
        }

        public LoggedInUserModel Create(string username, string firstName, string lastName, string passwordHash)
        {
            var user = new User
            {
                Username = username,
                EmailAddress = $"{username}{ModelConstants.EmailAddressDomain}",
                FirstName = firstName,
                LastName = lastName,
                PassowrdHash = passwordHash
            };

            if (!this.ValidateModelState(user))
            {
                return null;
            }

            try
            {
                this.db.Users.Add(user);
                this.db.SaveChanges();

                return Mapper.Map<LoggedInUserModel>(user);
            }
            catch
            {
                return null;
            }
        }

        public LoggedInUserModel TryLogin(string username, string passwordHash)
        {
            var user = this.db
                .Users
                .FirstOrDefault(u => u.Username == username && u.PassowrdHash == passwordHash);

            if (user == null)
            {
                return null;
            }

            return Mapper.Map<LoggedInUserModel>(user);
        }
    }
}
