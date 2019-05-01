using ModPanel.Services.Models.User;
using System.Collections.Generic;

namespace ModPanel.Services.Contracts
{
    public interface IUserService
    {
        LoggedInUserModel TryLogin(string email, string passwordHash);

        LoggedInUserModel Create(string email, string passwordHash, string position);

        IEnumerable<UserDetailsServiceModel> All();

        string Approve(int id);
    }
}
