using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.DataBase;
using TelegramBot.Models.BotSettings;

namespace TelegramBot.Controllers.UpdateTypes
{
    public class TypeCallBackQuery
    {
        public async static Task CallbackQueryHandler(CallbackQuery callback, TelegramBotClient botClient, IDbContext db)
        {
           
                var callBackCommands = Bot.CallBackCommands;
                foreach (var command in callBackCommands)
                {
                    if (command.Contains(callback.Data))
                    {
                        await command.Execute(callback, botClient, db);
                        break;
                    }
                }
            
        }
    }
}
