using GamesStore.API.Controllers;
using GamesStore.API.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

await app.Services.InitializeDb();
app.MapGamesControllers();

app.Run();
