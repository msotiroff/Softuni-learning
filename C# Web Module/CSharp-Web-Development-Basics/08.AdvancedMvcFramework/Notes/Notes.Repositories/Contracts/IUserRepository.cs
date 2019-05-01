namespace Notes.Repositories.Contracts
{
    using Notes.Models;
    using Notes.Repositories.Contracts.Generic;

    public interface IUserRepository : IRepository<User>
    {
        bool TryLogin(string username, string passwordHash);

        User GetWithNotes(int userId);
    }
}
