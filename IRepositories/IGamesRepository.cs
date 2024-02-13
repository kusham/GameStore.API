using GamesStore.API.Entities;

namespace GamesStore.API.Repositories
{
    public interface IGamesRepository
    {
        void AddGame(Game game);
        void DeleteGame(int id);
        IEnumerable<Game> GetAllGames();
        Game? GetGameById(int id);
        void UpdateGame(Game updatedGame);
    }
}