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

            group.MapGet("/", async (IGamesRepository _gamesRepository) => 
            (await _gamesRepository.GetAllGamesAsync()).Select(game => game.AsDto()));

            group.MapGet("/{id:int}", async (IGamesRepository _gamesRepository, int id) =>
            {
                Game? game = await _gamesRepository.GetGameByIdAsync(id);
                return game is not null ? Results.Ok(game) : Results.NotFound();
            }).WithName(_getGameEndpointName);

            group.MapPost("/", async (IGamesRepository _gamesRepository, CreateGameDto gameDto) =>
            {
                Game game = new() 
                { 
                    Genre = gameDto.Genre, Name = gameDto.Name, Price = gameDto.Price, 
                    ImageUrl = gameDto.ImageUrl, ReleaseDate = gameDto.ReleaseDate 
                };
                await _gamesRepository.AddGameAsync(game);
                return Results.Created($"/games/{game.Id}", game);
            });

            group.MapPut("/{id:int}", async (IGamesRepository _gamesRepository, int id, UpdateGameDto updatedGameDto) =>
            {
                Game? existingGame = await _gamesRepository.GetGameByIdAsync(id);
                if (existingGame is null)
                {
                    return Results.NotFound();
                }
                existingGame.Name = updatedGameDto.Name;
                existingGame.Genre = updatedGameDto.Genre;
                existingGame.Price = updatedGameDto.Price;
                existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
                existingGame.ImageUrl = updatedGameDto.ImageUrl;

                await _gamesRepository.UpdateGameAsync(existingGame);
                return Results.NoContent();
            });

            group.MapDelete("/{id:int}", async (IGamesRepository _gamesRepository, int id) =>
            {
                if (_gamesRepository.GetGameByIdAsync(id) is null)
                {
                    return Results.NotFound();
                }
                await _gamesRepository.DeleteGameAsync(id);
                return Results.NoContent();
            });

            return group;
        }
    }
}
