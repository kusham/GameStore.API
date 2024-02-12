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

            group.MapGet("/", (IGamesRepository _gamesRepository) => _gamesRepository.GetAllGames());

            group.MapGet("/{id:int}", (IGamesRepository _gamesRepository, int id) =>
            {
                Game? game = _gamesRepository.GetGameById(id);
                return game is not null ? Results.Ok(game) : Results.NotFound();
            }).WithName(_getGameEndpointName);

            group.MapPost("/", (IGamesRepository _gamesRepository, Game game) =>
            {
                _gamesRepository.AddGame(game);
                return Results.Created($"/games/{game.Id}", game);
            });

            group.MapPut("/{id:int}", (IGamesRepository _gamesRepository, int id, Game game) =>
            {
                if (id != game.Id)
                {
                    return Results.BadRequest("Id in the URL and in the body do not match");
                }
                if (_gamesRepository.GetGameById(id) is null)
                {
                    return Results.NotFound();
                }
                _gamesRepository.UpdateGame(game);
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
