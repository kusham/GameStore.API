using GamesStore.API.Entities;

namespace GamesStore.API.Repositories
{
    public interface IGamesRepository
    {
        Task AddGameAsync(Game game);
        Task DeleteGameAsync(int id);
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<Game?> GetGameByIdAsync(int id);
        Task UpdateGameAsync(Game updatedGame);
    }
}