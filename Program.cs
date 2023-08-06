using TelegramBot.DataBase;
using TelegramBot.Models.BotSettings;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistence(builder.Configuration);

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

        var context = serviceProvider.GetRequiredService<BotDbContext>();
        DbInitialize.Initialize(context);

}

Bot.GetTelegramBot().Wait();

builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
