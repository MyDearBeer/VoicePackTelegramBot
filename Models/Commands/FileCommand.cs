using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBot.DataBase;

namespace TelegramBot.Models.Commands
{
    public abstract class FileCommand
    {
        public abstract Task Execute(Message message, TelegramBotClient client, IDbContext dbContext);
    }
}
