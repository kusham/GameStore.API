using GamesStore.API.Entities;

namespace GamesStore.API.Repositories
{
    public class GamesRepository
    {
        private readonly List<Game> _games = new()
        {
            new Game()
            {
                Id = 1,
                Name = "game 1",
                Genre = "",
                Price = 12.34M,
                ReleaseDate = new DateTime(1991, 01, 12),
                ImageUrl = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 2,
                Name = "game 2",
                Genre = "",
                Price = 12.34M,
                ReleaseDate = new DateTime(1991, 01, 12),
                ImageUrl = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 3,
                Name = "game 3",
                Genre = "",
                Price = 12.34M,
                ReleaseDate = new DateTime(1991, 01, 12),
                ImageUrl = "https://placehold.co/100"
            }
        };
        public List<Game> GetAllGames()
        {
            return _games;
        }
        public Game? GetGameById(int id)
        {
            return _games.FirstOrDefault(game => game.Id == id);
        }
        public void AddGame(Game game)
        {
            game.Id = _games.Max(game => game.Id) + 1;
            _games.Add(game);
        }

        public void UpdateGame(Game updatedGame)
        {
            var existingGame = _games.FirstOrDefault(game => game.Id == updatedGame.Id);
            if (existingGame != null)
            {
                existingGame.Name = updatedGame.Name;
                existingGame.Genre = updatedGame.Genre;
                existingGame.Price = updatedGame.Price;
                existingGame.ReleaseDate = updatedGame.ReleaseDate;
                existingGame.ImageUrl = updatedGame.ImageUrl;
            }
        }
        public void DeleteGame(int id)
        {
            var game = _games.FirstOrDefault(game => game.Id == id);
            if (game != null)
            {
                _games.Remove(game);
            }
        }

    }
}
