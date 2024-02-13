using GamesStore.API.Controllers;
using GamesStore.API.Data;
using GamesStore.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGamesRepository, GamesRepository>();
builder.Services.AddSqlServer<GameStoreDbContext>
    (builder.Configuration.GetConnectionString("GameStoreContext"));

var app = builder.Build();

app.MapGamesControllers();

app.Run();
