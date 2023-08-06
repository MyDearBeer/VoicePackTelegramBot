using Telegram.Bot.Types;
using Telegram.Bot;
using Microsoft.AspNetCore.Mvc;
using Azure.Core;
using TelegramBot.DataBase;
using System.Threading;
using TelegramBot.Models.BotSettings;

namespace TelegramBot.Models.Commands.VoiceCommands.AddVoiceCommand
{
    public class AddVoiceCommand : Command
    {
        public override string? Name => "/addvoice";



        public override async Task<IActionResult> Execute(Message message, TelegramBotClient client, IDbContext dbContext, TgUser user)
        {
            await client.SendTextMessageAsync(message.Chat.Id, "Напишіть назву войсу");
            user.StatusOnCommand = "//addvoicename";
            await dbContext.SaveChangesAsync(new CancellationToken());
            return new NoContentResult();
        }
    }
}
