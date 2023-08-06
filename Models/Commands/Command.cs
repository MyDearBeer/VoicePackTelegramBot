using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBot.Models.BotSettings;
using TelegramBot.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBot.Models.Commands
{
    public abstract class Command : BotFunction
    {
        public abstract Task<IActionResult> Execute(Message message, TelegramBotClient client,IDbContext dbContext,TgUser? user);

        
    }
}
