namespace SoftUniGameStore.Services.Contracts
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService : IService
    {
        Task<IEnumerable<UserDetailsServiceModel>> All();

        Task<int> Create(UserRegisterServiceModel model);

        Task<bool> IsEmailUnique(string email);

        Task<int> TryLogin(UserLoginServiceModel serviceModel);

        Task<bool> UserIsInRole(string roleName, int userId);

        Task<bool> AddToRole(string role, int userId);
    }
}
