namespace Notes.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Notes.Data;
    using Notes.Models;
    using Notes.Services.Models.User;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : EntityValidationService, IUserService
    {
        private readonly NotesDbContext db;

        public UserService(NotesDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<UserListServiceModel> All()
        {
            var allUsers = this.db
                .Users
                .ProjectTo<UserListServiceModel>()
                .ToArray();

            return allUsers;
        }

        public int Create(string username, string passwordHash)
        {
            var user = new User
            {
                Username = username,
                PassowrdHash = passwordHash
            };

            if (!this.ValidateModelState(user))
            {
                return -1;
            }

            var userExist = this.db.Users.Any(u => u.Username == username);
            if (userExist)
            {
                return -1;
            }

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return user.Id;
        }

        public UserListServiceModel GetById(int id)
        {
            var user = this.db
                .Users
                .Where(u => u.Id == id)
                .ProjectTo<UserListServiceModel>()
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
