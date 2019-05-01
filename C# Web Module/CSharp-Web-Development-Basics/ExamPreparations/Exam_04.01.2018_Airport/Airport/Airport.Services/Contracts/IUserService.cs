using Airport.Services.Models.User;

namespace Airport.Services.Contracts
{
    public interface IUserService
    {
        LoggedInUserModel TryLogin(string email, string passwordHash);

        LoggedInUserModel Create(string email, string fullName, string passwordHash);
    }
}
