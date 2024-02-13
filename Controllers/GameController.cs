using GamesStore.API.Dtos;
using GamesStore.API.Entities;
using GamesStore.API.Repositories;

namespace GamesStore.API.Controllers
{
    public static class GameController
    {
        const string _getGameEndpointName = "GetGame";

        public static RouteGroupBuilder MapGamesControllers(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/games").WithParameterValidation();

            group.MapGet("/", (IGamesRepository _gamesRepository) => _gamesRepository.GetAllGames().Select(game => game.AsDto()));

            group.MapGet("/{id:int}", (IGamesRepository _gamesRepository, int id) =>
            {
                Game? game = _gamesRepository.GetGameById(id);
                return game is not null ? Results.Ok(game) : Results.NotFound();
            }).WithName(_getGameEndpointName);

            group.MapPost("/", (IGamesRepository _gamesRepository, CreateGameDto gameDto) =>
            {
                Game game = new() { Genre = gameDto.Genre, Name = gameDto.Name, Price = gameDto.Price, ImageUrl = gameDto.ImageUrl, ReleaseDate = gameDto.ReleaseDate };
                _gamesRepository.AddGame(game);
                return Results.Created($"/games/{game.Id}", game);
            });

            group.MapPut("/{id:int}", (IGamesRepository _gamesRepository, int id, UpdateGameDto updatedGameDto) =>
            {
                Game? existingGame = _gamesRepository.GetGameById(id);
                if (existingGame is null)
                {
                    return Results.NotFound();
                }
                existingGame.Name = updatedGameDto.Name;
                existingGame.Genre = updatedGameDto.Genre;
                existingGame.Price = updatedGameDto.Price;
                existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
                existingGame.ImageUrl = updatedGameDto.ImageUrl;

                _gamesRepository.UpdateGame(existingGame);
                return Results.NoContent();
            });

            group.MapDelete("/{id:int}", (IGamesRepository _gamesRepository, int id) =>
            {
                if (_gamesRepository.GetGameById(id) is null)
                {
                    return Results.NotFound();
                }
                _gamesRepository.DeleteGame(id);
                return Results.NoContent();
            });

            return group;
        }
    }
}
