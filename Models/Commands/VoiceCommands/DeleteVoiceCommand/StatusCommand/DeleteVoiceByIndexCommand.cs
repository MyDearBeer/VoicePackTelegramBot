using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.Consts;
using TelegramBot.DataBase;

namespace TelegramBot.Models.Commands.VoiceCommands.DeleteVoiceCommand.StatusCommand
{
    public class DeleteVoiceByIndexCommand : Command
    {
        public override string? Name => "//deletevoicebyindex";
        public override async Task<IActionResult> Execute(Message message, TelegramBotClient client, IDbContext dbContext, TgUser user)
        {
            bool tryParse = Parser.TryParse(message.Text, out uint index);
            var voice = await VoiceById.GetVoiceById(dbContext, client, index, message);
            if (voice != null)
            {
                dbContext.voiceMessages.Remove(voice);
               
                    await client.SendTextMessageAsync(message.Chat.Id, "Gotovo, файл успішно видалений з вашої колекції.");
                    user.StatusOnCommand = null;
            }
           
            return new NoContentResult(); 
        }
    }
}
