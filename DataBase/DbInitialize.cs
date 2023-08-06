namespace TelegramBot.DataBase
{
    public static class DbInitialize
    {
        public static void Initialize(BotDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
        }
    }
}
