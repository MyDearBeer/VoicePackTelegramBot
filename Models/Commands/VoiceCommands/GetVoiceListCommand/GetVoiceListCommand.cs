using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.CallBacksQuery;
using TelegramBot.Consts;
using TelegramBot.DataBase;
using TelegramBot.Models.Commands.VoiceCommands.GetVoiceListCommand;

namespace TelegramBot.Models.Commands.VoiceCommands.GetVoiceList
{
    public class GetVoiceListCommand : Command
    {
        public override string? Name => "/getvoices";
        public override async Task<IActionResult> Execute(Message message, TelegramBotClient client, IDbContext dbContext, TgUser? user)
        {

          var voiceList = await GetVoicesByUser.GetVoices(dbContext, message.From.Id);
            
            
            var markup = KeyBoardSelector.GetKeyboardMarkup(1, voiceList.Count);
            if (voiceList.Count > Buttons.Limit)
            {
                voiceList = voiceList.Take(Buttons.Limit).ToList();
            }
            var voiceListStr = ListBuilder.ListBuild(voiceList, 0);

            await client.SendTextMessageAsync(message.Chat.Id, $"{voiceListStr}",
                replyMarkup: markup);
            return new NoContentResult();
        }
    }
}
