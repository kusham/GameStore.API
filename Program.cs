using GamesStore.API.Entities;

List<Game> games = new()
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

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/games", () => games);


app.Run();
