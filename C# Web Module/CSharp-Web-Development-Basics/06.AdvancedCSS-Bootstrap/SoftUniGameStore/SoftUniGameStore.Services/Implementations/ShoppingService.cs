namespace SoftUniGameStore.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using SoftUniGameStore.Data;
    using SoftUniGameStore.Models;

    public class ShoppingService : IShoppingService
    {
        private readonly GameStoreDbContext db;

        public ShoppingService(GameStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> Order(int userId, IEnumerable<int> gamesIds)
        {
            var orderedGamesIds = await this.db.UserGames.Where(ug => ug.UserId == userId).Select(ug => ug.GameId).ToListAsync();
            var availableToOrder = gamesIds.Except(orderedGamesIds);

            try
            {
                var userGames = availableToOrder
                .Select(gId => new UserGame
                {
                    GameId = gId,
                    UserId = userId
                })
                .ToList();

                await this.db.UserGames.AddRangeAsync(userGames);
                await this.db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> IsUserBoughtGame(int userId, int gameId)
            => await this.db
                .UserGames
                .FirstOrDefaultAsync(ug => ug.UserId == userId && ug.GameId == gameId) != null;
    }
}
