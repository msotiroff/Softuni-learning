namespace SoftUniClone.Services.Admin.Contracts
{
    using Models.Users;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserBasicServiceModel>> GetAllListingAsync(string searchToken, int page);

        Task<IEnumerable<AdminUserIdAndNameServiceModel>> GetAllUserIdsAndNamesAsync();

        Task<int> TotalCountAsync(string searchToken);
    }
}