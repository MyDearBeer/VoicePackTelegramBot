using Microsoft.EntityFrameworkCore;

namespace TelegramBot.DataBase
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence
            (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<BotDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IDbContext>(provider =>
            provider.GetService<BotDbContext>());

            return services;
        }
    }
}
