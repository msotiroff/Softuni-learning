using MeTube.Services.Models.User;

namespace MeTube.Services.Contracts
{
    public interface IUserService
    {
        LoggedInUserModel TryLogin(string username, string passwordHash);

        LoggedInUserModel Create(string email, string fullName, string passwordHash);

        UserProfileServiceModel GetById(int id);
    }
}
