namespace SoftUniGameStore.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Contracts;
    using Microsoft.EntityFrameworkCore;
    using SoftUniGameStore.Data;
    using SoftUniGameStore.Models;
    using SoftUniGameStore.Services.Models;

    public class GameService : IGameService
    {
        private readonly GameStoreDbContext db;

        public GameService(GameStoreDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<GameServiceModel>> All()
        {
            var allGames = await this.db
                .Games
                .Select(g => new GameServiceModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    Size = g.Size,
                    Thumbnail = g.ImageThumbnail,
                    Description = g.Description,
                    Price = g.Price
                })
                .ToListAsync();

            return allGames;
        }

        public async Task<int> Create(GameCreateServiceModel model)
        {
            var game = new Game
            {
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                Size = model.Size,
                ImageThumbnail = model.ImageThumbnail,
                Trailer = model.Trailer,
                ReleaseDate = model.ReleaseDate
            };

            await this.db.Games.AddAsync(game);
            await this.db.SaveChangesAsync();

            return game.Id;
        }

        public async Task<bool> Delete(int gameId)
        {
            var gameToDelete = await this.db.Games.FirstOrDefaultAsync(g => g.Id == gameId);

            if (gameToDelete == null)
            {
                return false;
            }

            this.db.Remove(gameToDelete);

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<GameCartServiceModel>> GetAllByIds(ICollection<int> productsIds)
        {
            var games = await this.db
                .Games
                .Where(g => productsIds.Contains(g.Id))
                .Select(g => new GameCartServiceModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    Thumbnail = g.ImageThumbnail,
                    Price = g.Price,
                })
                .ToListAsync();

            return games;
        }

        public async Task<GameServiceModel> GetById(int gameId)
        {
            var game = await this.db
                .Games
                .Where(g => g.Id == gameId)
                .Select(g => new GameServiceModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    Price = g.Price,
                    Size = g.Size,
                    Thumbnail = g.ImageThumbnail,
                    Trailer = g.Trailer,
                    ReleaseDate = g.ReleaseDate
                })
                .FirstOrDefaultAsync();

            return game;
        }

        public async Task<IEnumerable<GameServiceModel>> GetAllByUser(int userId)
        {
            var gamesByUser = await this.db
                .UserGames
                .Where(ug => ug.UserId == userId)
                .Select(ug => new GameServiceModel
                {
                    Id = ug.Game.Id,
                    Title = ug.Game.Title,
                    Size = ug.Game.Size,
                    Thumbnail = ug.Game.ImageThumbnail,
                    Description = ug.Game.Description,
                    Price = ug.Game.Price
                })
                .ToListAsync();

            return gamesByUser;
        }

        public async Task<bool> Update(GameServiceModel model)
        {
            var gameToEdit = await this.db.Games.FirstOrDefaultAsync(g => g.Id == model.Id);

            try
            {
                gameToEdit.Title = model.Title;
                gameToEdit.Description = model.Description;
                gameToEdit.Price = model.Price;
                gameToEdit.Size = model.Size;
                gameToEdit.ReleaseDate = model.ReleaseDate;
                gameToEdit.ImageThumbnail = model.Thumbnail;
                gameToEdit.Trailer = model.Trailer;

                this.db.Entry(gameToEdit).State = EntityState.Modified;

                await this.db.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
