using GamesStore.API.Data;
using GamesStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.API.Repositories
{
    public class EntityFrameworkGameRepository : IGamesRepository
    {
        private readonly GameStoreDbContext _dbContext;

        public EntityFrameworkGameRepository(GameStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddGameAsync(Game game)
        {
            _dbContext.Games.Add(game);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
           await _dbContext.Games.Where(game => game.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _dbContext.Games.AsNoTracking().ToListAsync();
        }

        public async Task<Game?> GetGameByIdAsync(int id)
        {
            return await _dbContext.Games.AsNoTracking()
                .FirstOrDefaultAsync(game => game.Id == id);
        }

        public async Task UpdateGameAsync(Game updatedGame)
        {
            _dbContext.Update(updatedGame);
            await _dbContext.SaveChangesAsync();
        }
    }
}
