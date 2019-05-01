namespace Airport.Services.Implementations
{
    using AutoMapper;
    using Contracts;
    using Airport.Data;
    using Airport.Models;
    using Airport.Services.Models.User;
    using System;
    using System.Linq;

    public class UserService : DataAccessService, IUserService
    {
        public UserService(AirportDbContext db) 
            : base(db)
        {
        }

        public LoggedInUserModel Create(string email, string fullName, string passwordHash)
        {
            var user = new User
            {
                Email = email,
                Name = fullName,
                PassowrdHash = passwordHash
            };

            if (!this.ValidateModelState(user))
            {
                return null;
            }

            if (!this.db.Users.Any())
            {
                user.IsAdmin = true;
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
