using WizMail.Services.Models.User;

namespace WizMail.Services.Contracts
{
    public interface IUserService
    {
        LoggedInUserModel TryLogin(string username, string passwordHash);

        LoggedInUserModel Create(string username, string firstName, string lastName, string passwordHash);
    }
}
