namespace CHUSHKA.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using CHUSHKA.Data;
    using CHUSHKA.Models;
    using CHUSHKA.Services.Models.User;
    using System;
    using System.Linq;

    public class UserService : DataAccessService, IUserService
    {
        public UserService(CHUSHKADbContext db) 
            : base(db)
        {
        }

        public LoggedInUserModel Create(string email, string username, string passwordHash, string fullName)
        {
            var user = new User
            {
                Email = email,
                Username = username,
                PassowrdHash = passwordHash,
                FullName = fullName,
                IsAdmin = !this.db.Users.Any()
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
