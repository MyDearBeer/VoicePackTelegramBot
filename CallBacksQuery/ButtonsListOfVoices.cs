using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Consts;
using TelegramBot.DataBase;
using TelegramBot.Models;
using TelegramBot.Models.Commands.VoiceCommands.GetVoiceList;
using TelegramBot.Models.Commands.VoiceCommands.GetVoiceListCommand;

namespace TelegramBot.CallBacksQuery
{
    public class ButtonsListOfVoices : CallBack
    {
        public override string? Name => "*";
        public override async Task<IActionResult> Execute(CallbackQuery callBack, TelegramBotClient client, IDbContext dbContext)
        {
            string indexStr = "";
            var voiceQuare = dbContext.voiceMessages.Where(x => x.UserId == callBack.From.Id);
            var voiceCount = voiceQuare.Count();
            var startIndex = 0;
            int page = 0;
            InlineKeyboardMarkup? replyMark = Buttons.Ikm;
            List<VoiceMessage> voiceList = new List<VoiceMessage>();
            string text = callBack.Message.Text.Remove(0, 21);

                foreach (var ch in text)
                {
                    if (ch == '.')
                        break;
                    indexStr += ch;
                }
                int index = Int32.Parse(indexStr.Remove(0, 4));
                page = index / Buttons.Limit + 1;
                if (callBack.Data == "*nextvoices")
                {

                    voiceList = voiceQuare.Skip(Buttons.Limit * page).Take(Buttons.Limit).ToList();

                    startIndex = index + Buttons.Limit - 1;
                    page++;
                  

                }
                if (callBack.Data == "*previousvoices")
                {


                    voiceList = voiceQuare.Skip(Buttons.Limit * (page - 2)).Take(Buttons.Limit).ToList();

                    startIndex = index - Buttons.Limit - 1;
                    page--;
                 
                }

            if (voiceList.Count == 0)
            {
                page = 1;
                startIndex = 0;
                voiceList = voiceQuare.Take(Buttons.Limit).ToList();

            }
           
            replyMark = KeyBoardSelector.GetKeyboardMarkup(page, voiceCount);
            var nextVoiceListStr = ListBuilder.ListBuild(voiceList, startIndex);
                await client.EditMessageTextAsync(callBack.Message.Chat.Id, callBack.Message.MessageId, $"{nextVoiceListStr}",
                    replyMarkup: replyMark);
            
           
            return new NoContentResult();
        }
    }
}
