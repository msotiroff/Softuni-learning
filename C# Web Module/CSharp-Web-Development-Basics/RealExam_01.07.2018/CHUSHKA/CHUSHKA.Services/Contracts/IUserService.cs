using CHUSHKA.Services.Models.User;

namespace CHUSHKA.Services.Contracts
{
    public interface IUserService
    {
        LoggedInUserModel TryLogin(string username, string passwordHash);

        LoggedInUserModel Create(string email, string username, string passwordHash, string fullName);
    }
}
