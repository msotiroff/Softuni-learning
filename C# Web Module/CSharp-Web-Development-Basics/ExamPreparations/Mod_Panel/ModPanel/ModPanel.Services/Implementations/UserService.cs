namespace ModPanel.Services.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using ModPanel.Data;
    using ModPanel.Models;
    using ModPanel.Services.Models.User;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : DataAccessService, IUserService
    {
        public UserService(ModPanelDbContext db) 
            : base(db)
        {
        }

        public IEnumerable<UserDetailsServiceModel> All()
        {
            return this.db
                .Users
                .OrderByDescending(u => u.Id)
                .ProjectTo<UserDetailsServiceModel>()
                .ToArray();
        }

        public string Approve(int id)
        {
            var userToBeApproved = this.db.Users.Find(id);
            if (userToBeApproved == null || userToBeApproved.IsApproved)
            {
                return null;
            }

            userToBeApproved.IsApproved = true;
            this.db.Users.Update(userToBeApproved);
            this.db.SaveChanges();

            return userToBeApproved.Email;
        }

        public LoggedInUserModel Create(string email, string passwordHash, string position)
        {
            var user = new User
            {
                Email = email,
                Position = this.db.Positions.FirstOrDefault(p => p.Name == position),
                PassowrdHash = passwordHash
            };

            if (!this.ValidateModelState(user))
            {
                return null;
            }

            if (!this.db.Users.Any())
            {
                user.IsAdmin = true;
                user.IsApproved = true;
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
