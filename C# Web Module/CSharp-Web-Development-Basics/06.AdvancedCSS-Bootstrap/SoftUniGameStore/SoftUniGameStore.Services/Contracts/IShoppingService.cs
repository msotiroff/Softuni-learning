namespace SoftUniGameStore.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IShoppingService : IService
    {
        Task<bool> IsUserBoughtGame(int userId, int gameId);

        Task<bool> Order(int userId, IEnumerable<int> gamesIds);
    }
}
