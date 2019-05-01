using Judge.Services.Models;

namespace Judge.Services.Contracts
{
    public interface IUserService
    {
        bool Add(string email, string fullName, string passwordHash);

        LoggedInUserModel TryLogin(string email, string passwordHash);
    }
}
