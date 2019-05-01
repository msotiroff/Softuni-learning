namespace KittenShop.Services.Implementations
{
    using AutoMapper;
    using Contracts;
    using KittenShop.Models;
    using KittenShop.Services.Models.User;
    using System.Linq;

    public class UserService : DataAccessService, IUserService
    {
        public LoggedInUserModel Create(string email, string username, string passwordHash)
        {
            var user = new User
            {
                Email = email,
                Username = username,
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

        public LoggedInUserModel TryLogin(string email, string passwordHash)
        {
            var user = this.db
                .Users
                .FirstOrDefault(u => u.Email == email && u.PassowrdHash == passwordHash);

            if (user == null)
            {
                return null;
            }

            return Mapper.Map<LoggedInUserModel>(user);
        }
    }
}
