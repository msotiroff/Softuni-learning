namespace Notes.Services
{
    using Notes.Data;
    using Notes.Models;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService
    {
        private readonly NotesDbContext db;

        public UserService()
        {
            this.db = new NotesDbContext();
        }

        public bool Register(string username, string password)
        {
            try
            {
                var user = new User
                {
                    Username = username,
                    Password = password
                };

                this.db.Users.Add(user);
                this.db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<UserViewModel> All()
        {
            return this.db
                .Users
                .Select(u => new UserViewModel
                {
                    Notes = u.Notes,
                    Username = u.Username,
                    Id = u.Id
                })
                .ToList();
        }

        public UserViewModel GetById(int id)
        {
            return this.db
                .Users
                .Where(u => u.Id == id)
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Username = u.Username,
                    Notes = u.Notes
                })
                .FirstOrDefault();
        }
    }
}
