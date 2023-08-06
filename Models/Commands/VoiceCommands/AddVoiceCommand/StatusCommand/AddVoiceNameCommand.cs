using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.DataBase;

namespace TelegramBot.Models.Commands.VoiceCommands.AddVoiceCommand.StatusCommand
{
    public class AddVoiceNameCommand : Command
    {
        public override string Name => "//addvoicename";

        public override async Task<IActionResult> Execute(Message message, TelegramBotClient client, IDbContext dbContext, TgUser user)
        {
            if(message.Text?.Length <= 20 &
                await dbContext.voiceMessages.Where(x => x.UserId == user.TelegramId)
                .FirstOrDefaultAsync(x => x.Name == message.Text) == null)
            {
                user.StatusOnCommand = "//addvoicefile";
                user.LastFileName = message.Text;
                await client.SendTextMessageAsync(message.Chat.Id, "Надішліть файл(можна надіслати войс, аудіо чи відео, максимальний розмір 10Мб) та напишіть проміжок для вирізки(за бажанням).");
                await dbContext.SaveChangesAsync(new CancellationToken());
            }
            else
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Ви не надіслали текст, або він перевищує ліміт 20 символів, aбо ви так вже називали.\nСпробуйте ще раз.");
            }
           
            
            return new NoContentResult();
        }
    }
}
