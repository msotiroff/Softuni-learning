namespace MeTube.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using MeTube.Data;
    using MeTube.Models;
    using MeTube.Services.Models.User;
    using System;
    using System.Linq;

    public class UserService : DataAccessService, IUserService
    {
        public UserService(MeTubeDbContext db) 
            : base(db)
        {
        }

        public LoggedInUserModel Create(string email, string fullName, string passwordHash)
        {
            var user = new User
            {
                Email = email,
                Username = fullName,
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

        public UserProfileServiceModel GetById(int id)
        {
            var user = this.db
                .Users
                .Where(u => u.Id == id)
                .ProjectTo<UserProfileServiceModel>()
                .FirstOrDefault();

            return user;
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
