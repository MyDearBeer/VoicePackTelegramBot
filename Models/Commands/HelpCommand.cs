using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.DataBase;

namespace TelegramBot.Models.Commands
{
    public class HelpCommand : Command
    {
        public override string? Name => "/help";
        public override async Task<IActionResult> Execute(Message message, TelegramBotClient client, IDbContext dbContext, TgUser? user)
        {
            var helpMessage = "*Команди:*\n" +
                "/getvoices - отримати список своїх войсів\n" +
                "/addvoice - додати войс до своєї колекції\n" +
                "При додаванні можна вказати проміжок обрізки, тоді у колекцію буде доданий цей фрагмент. Для цього в описі до файлу напишіть \"число1 число2\"\n" +
                "Число1 - звідки починати обрізку\n" +
                "Число2 - тривалість фрагменту\n" +
                "/deletevoice - видалити войс з колекції\n" +
                "/1 - отримати войс за індексом(цифра - індекс)\n" +
                "Індекс можна дізнатись, отримавши список\n\n" +
                "Бот підтримує інлайн режим, для цього введіть @voiceaudiopackbot + пробіл, після чого ви отримаєте свою колекцію та можливість відправити войс.\n\n" +
                "Максимальний розмір відправки - 10мб. Рекомендується надсилати файли <1.5мб задля коректної конвертації, у противному випадку у войсі будуть відсутні \"хвильки\"(але це не точно).\n\n" +
                "🍺 Є пропозиції, помітили баг? - пишіть @ryckiesosat\n" +
                "P.S: бот поки немає хостингу бо автор бомж, тож працює тільки завдяки компу творця...";
            await client.SendTextMessageAsync(message.Chat.Id, helpMessage, parseMode: ParseMode.Markdown);
            return new NoContentResult();
        }
    }
}
