namespace ByTheCake.Services.Contracts
{
    using Models;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<int> Create(UserCreateServiceModel model);
        
        Task<int> TrySignIn(string username, string passwordHash);

        Task<bool> Exist(string userName);

        Task<UserProfileServiceModel> GetById(int userId);
    }
}
