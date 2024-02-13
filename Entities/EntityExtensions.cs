﻿using GamesStore.API.Dtos;

namespace GamesStore.API.Entities
{
    public static class EntityExtensions
    {
        public static GameDto AsDto(this Game game)
        {
            return new GameDto(game.Id, game.Name, game.Genre, game.Price, game.ImageUrl, game.ReleaseDate);
        }
    }
}
