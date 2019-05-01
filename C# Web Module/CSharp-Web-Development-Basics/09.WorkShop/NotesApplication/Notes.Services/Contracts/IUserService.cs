namespace Notes.Services.Contracts
{
    using Notes.Services.Models.User;
    using System.Collections.Generic;

    public interface IUserService
    {
        int Create(string username, string passwordHash);

        LoggedInUserModel TryLogin(string username, string passwordHash);

        IEnumerable<UserListServiceModel> All();
        UserListServiceModel GetById(int id);
    }
}
