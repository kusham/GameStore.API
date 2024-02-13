using GamesStore.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.API.Data
{
    public static class DataExtensions
    {
        public static async Task InitializeDb(this IServiceProvider serviceProvider)
        {
            var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider
                .GetRequiredService<GameStoreDbContext>();
            await dbContext.Database.MigrateAsync();
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddSqlServer<GameStoreDbContext>
                (configuration.GetConnectionString("GameStoreContext"))
                .AddScoped<IGamesRepository, EntityFrameworkGameRepository>();
            return services;
        }
    }
}
