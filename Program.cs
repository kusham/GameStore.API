using GamesStore.API.Controllers;
using GamesStore.API.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepository, GamesRepository>();
var app = builder.Build();

app.MapGamesControllers();

app.Run();
