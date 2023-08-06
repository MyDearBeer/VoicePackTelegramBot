using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;
using TelegramBot.DataBase;
using TelegramBot.Models.BotSettings;
using TelegramBot.Models.Commands.VoiceCommands.GetVoiceListCommand;

namespace TelegramBot.Controllers.UpdateTypes
{
    public class TypeInlineQuery
    {
        public static async Task<IActionResult> InlineHandler(IDbContext dbContext, InlineQuery inline, TelegramBotClient client)
        {
            var results = new List<InlineQueryResult>();
            var voices = await GetVoicesByUser.GetVoices(dbContext, inline.From.Id) ;
            var counter = 0;
            
            foreach (var voice in voices)
            {
               
                    var inlineQuery = new InlineQueryResultCachedVoice(
                        $"{counter}", // we use the counter as an id for inline query results
                                      //$"{Directory.GetCurrentDirectory()}\\Voices\\{voice.Name}({voice.UserId}).ogg",
                        $"{voice.TgId}",
                        voice.Name // inline query result title
                                   // content that is submitted when the inline query result title is clicked
                    );

                    results.Add(inlineQuery);
                
                counter++;
            }
            try
            {
                await client.AnswerInlineQueryAsync(inline.Id, results,cacheTime:0);
            }
            catch(Exception ex)
            {

            }
            return new NoContentResult();
        }
    }
}
