using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBot.DataBase;
using TelegramBot.Models;

namespace TelegramBot.CallBacksQuery
{
    public abstract class CallBack : BotFunction
    {
        public abstract Task<IActionResult> Execute(CallbackQuery callBack, TelegramBotClient client, IDbContext dbContext);
    }
}
