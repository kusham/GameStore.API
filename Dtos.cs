using System.ComponentModel.DataAnnotations;

namespace GamesStore.API.Dtos;
public record GameDto(int Id, string Name, string Genre, decimal Price, string ImageUrl, DateTime ReleaseDate);

public record class CreateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    [Url][StringLength(100)] string ImageUrl, DateTime ReleaseDate
    );

public record class UpdateGameDto(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    [Url][StringLength(100)] string ImageUrl, DateTime ReleaseDate
    );