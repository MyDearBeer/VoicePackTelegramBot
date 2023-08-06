using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Controllers.UpdateTypes;
using TelegramBot.DataBase;

namespace TelegramBot.Models.Commands.VoiceCommands.AddVoiceCommand.StatusCommand
{
    public class AddVoiceFileCommand : Command
    {
        public override string? Name => "//addvoicefile";

        public override async Task<IActionResult> Execute(Message message, TelegramBotClient client, IDbContext dbContext, TgUser user)
        { 
            if (message.Audio != null || message.Voice != null || message.Video!=null)
            {
                var voiceMessage = new VoiceMessage()
                {
                    UserId = message.From.Id,
                    TgId = message.Audio != null ? message.Audio.FileId : (message.Video != null ? message.Video.FileId : message.Voice.FileId),
                    Name = user.LastFileName,
                    Size = message.Audio!=null ? message.Audio.FileSize : (message.Video != null ? message.Video.FileSize : message.Voice.FileSize),
                    Duration = message.Audio!=null ? message.Audio.Duration : (message.Video != null ? message.Video.Duration : message.Voice.Duration),
                };
                if(voiceMessage.Size > 10000000)
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Занадто жирний файл.");
                    return new NoContentResult();
                }
                var tgId = await FileUpload.FileAdd(client, voiceMessage,message);
                if (tgId != "")
                {
                    voiceMessage.TgId = tgId;
                }
                else
                {
                    await client.SendTextMessageAsync(message.Chat.Id, "Цей файл неможливо додати, або був невірно вказаний проміжок вирізу...");
                    return new NoContentResult();
                }
                    

                await dbContext.voiceMessages.AddAsync(voiceMessage);
                await client.SendTextMessageAsync(message.Chat.Id, "Gotovo, ваше аудіо було додано до вашої колекції.");
                user.StatusOnCommand = null;

                //await dbContext.SaveChangesAsync(new CancellationToken());
            }
            else
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Це не войс чи аудіо, повторіть.");
            }
            return new NoContentResult();
        }
    }
}
