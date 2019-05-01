namespace Notes.Repositories.Implementations
{
    using Contracts;
    using Generic;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Linq;

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context)
            : base(context)
        {
        }

        public User GetWithNotes(int userId)
            => this.context
            .Set<User>()
            .Include(u => u.Notes)
            .FirstOrDefault(u => u.Id == userId);

        public bool TryLogin(string username, string passwordHash)
            => this.context
                .Set<User>()
                .FirstOrDefault(u => u.Username == username && u.Password == passwordHash) != null;
    }
}
