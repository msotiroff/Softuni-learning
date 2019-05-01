namespace SoftUniGameStore.Services.Contracts
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGameService : IService
    {
        Task<int> Create(GameCreateServiceModel model);
        
        Task<bool> Update(GameServiceModel serviceModel);

        Task<bool> Delete(int gameId);

        Task<IEnumerable<GameServiceModel>> All();

        Task<GameServiceModel> GetById(int gameId);

        Task<IEnumerable<GameCartServiceModel>> GetAllByIds(ICollection<int> productsIds);

        Task<IEnumerable<GameServiceModel>> GetAllByUser(int userId);
    }
}
