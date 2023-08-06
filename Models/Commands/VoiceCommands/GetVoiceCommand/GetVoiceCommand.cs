using MediaFileProcessor.Processors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Consts;
using TelegramBot.DataBase;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Downloader;
using File = System.IO.File;

namespace TelegramBot.Models.Commands.VoiceCommands.GetVoice
{
    public class GetVoiceCommand : Command
    {
        public override string? Name => null;
        private uint Number { get; set; }
        public override async Task<IActionResult> Execute(Message message, TelegramBotClient client, IDbContext dbContext, TgUser? user)
        {
            var voice = await VoiceById.GetVoiceById(dbContext, client,Number,message);
            if (voice != null)
            {           
                    try
                    {
                            await client.SendVoiceAsync(chatId: message.Chat.Id, voice: InputFile.FromFileId(voice.TgId));       

                    }
                    catch (Exception exeption)
                    {
                    await client.SendTextMessageAsync(message.Chat.Id, "Файл не знайдений...");
                }
                
               
            }
            return new NoContentResult();
        }
        public override bool Contains(string message)
        {
             if(Parser.TryParse(message.Remove(0,1), out uint number))
            {
                Number = number;
                return true;
            }
            return false;

        }
    }
}
