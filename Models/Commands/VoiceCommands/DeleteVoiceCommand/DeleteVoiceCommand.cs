using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBot.DataBase;
using TelegramBot.Models.Commands.VoiceCommands.AddVoiceCommand;
using Microsoft.AspNetCore.Mvc;

namespace TelegramBot.Models.Commands.VoiceCommands.DeleteVoiceCommand
{
    public class DeleteVoiceCommand : Command
    {
        public override string? Name => "/deletevoice";



        public override async Task<IActionResult> Execute(Message message, TelegramBotClient client, IDbContext dbContext, TgUser user)
        {
           
                await client.SendTextMessageAsync(message.Chat.Id, "Номер войсу:", replyToMessageId: message.MessageId);
                user.StatusOnCommand = "//deletevoicebyindex";
                await dbContext.SaveChangesAsync(new CancellationToken());
                return new NoContentResult();

            }

        }
    }
