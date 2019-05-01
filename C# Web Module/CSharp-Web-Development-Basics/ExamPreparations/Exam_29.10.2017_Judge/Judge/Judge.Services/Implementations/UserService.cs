namespace Judge.Services.Implementations
{
    using AutoMapper;
    using Contracts;
    using Judge.Data;
    using Judge.Models;
    using Judge.Services.Models;
    using System.Linq;

    public class UserService : EntityValidationService, IUserService
    {
        private readonly JudgeDbContext db;

        public UserService(JudgeDbContext db)
        {
            this.db = db;
        }

        public bool Add(string email, string fullName, string passwordHash)
        {
            var user = new User
            {
                Email = email,
                FullName = fullName,
                PassowrdHash = passwordHash
            };

            if (!this.db.Users.Any())
            {
                user.IsAdmin = true;
            }

            if (!this.ValidateModelState(user))
            {
                return false;
            }

            this.db.Users.Add(user);
            this.db.SaveChanges();

            return true;
        }

        public LoggedInUserModel TryLogin(string email, string passwordHash)
        {
            var user = this.db
                .Users
                .FirstOrDefault(u => u.Email == email && u.PassowrdHash == passwordHash);

            return user != null 
                ? Mapper.Map<LoggedInUserModel>(user) 
                : null;
        }
    }
}
