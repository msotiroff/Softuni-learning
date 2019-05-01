namespace Forum.App.Services
{
    using Contracts;
    using Forum.App.Common;
    using Forum.Data;
    using Forum.DataModels;
    using System;
    using System.Linq;

    public class UserService : IUserService
    {
        private ForumData forumData;
        private ISession session;

        public UserService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        public User GetUserById(int userId)
        {
            var user = this.forumData
                .Users
                .FirstOrDefault(u => u.Id == userId);

            // TODO: Throw if null...

            return user;
        }

        public string GetUserName(int userId)
        {
            var username = this.forumData
                .Users
                .FirstOrDefault(u => u.Id == userId)
                ?.Username;
            
            // TODO: Throw if null...
            
            return username;
        }

        public bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            var user = this.forumData
                .Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                return false;
            }

            this.session.Reset();
            this.session.LogIn(user);

            return true;
        }

        public bool TrySignUpUser(string username, string password)
        {
            var isUsernameValid = !string.IsNullOrWhiteSpace(username) && username.Length > Constants.UsernameAndPassowrdMinLength;

            var isPasswordValid = !string.IsNullOrWhiteSpace(password) && password.Length > Constants.UsernameAndPassowrdMinLength;

            var isValid = isUsernameValid && isPasswordValid;

            if (!isValid)
            {
                throw new ArgumentException(Constants.InvalidUsernameOrPasswordLength);
            }

            var userAlreadyExist = this.forumData.Users.Any(u => u.Username == username);

            if (userAlreadyExist)
            {
                throw new InvalidOperationException(Constants.UsernameTakenError);
            }

            var userId = this.forumData.Users.Any()
                ? this.forumData.Users.Max(u => u.Id) + 1
                : 1;

            var user = new User(userId, username, password);

            this.forumData.Users.Add(user);
            this.forumData.SaveChanges();

            this.TryLogInUser(username, password);

            return true;
        }
    }
}
