using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Controllers.UpdateTypes;
using TelegramBot.DataBase;
using TelegramBot.Models.BotSettings;
using TelegramBot.Models.Commands;
using TelegramBot.Models.Commands.VoiceCommands;

namespace TelegramBot.Controllers
{
    [ApiController]
    [Route("/")]
    public class BotController : Controller
    {
        private BotDbContext _db;
        public BotController(BotDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            var date = this.Response.Headers.Date;
            var botClient = await Bot.GetTelegramBot();
            switch (update.Type)
            {
                case UpdateType.Message:
                    await TypeMessage.MessageHandler(update.Message, botClient, _db);
                    break;
                case UpdateType.CallbackQuery:
                    await TypeCallBackQuery.CallbackQueryHandler(update.CallbackQuery, botClient, _db);
                    break;
                case UpdateType.InlineQuery:
                    await TypeInlineQuery.InlineHandler(_db, update.InlineQuery, botClient);
                    break;
                default:
                    return NoContent();

            }


            return Ok();
        }
    }
}
    

