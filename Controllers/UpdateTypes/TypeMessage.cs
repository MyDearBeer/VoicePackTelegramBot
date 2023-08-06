using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.DataBase;
using TelegramBot.Models.BotSettings;
using TelegramBot.Models.Commands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TelegramBot.Controllers.UpdateTypes
{
    public class TypeMessage
    {
        public async static Task<IActionResult> MessageHandler(Message message, TelegramBotClient botClient, IDbContext db)
        {
            var datemes = DateTime.Now - message!.Date.AddHours(3);
            if (datemes.Minutes < 10)
            {
                var tapCommands = Bot.TapCommands;
                var statusCommands = Bot.StatusCommands;

                if (message.Chat.Type != ChatType.Private)
                {
                    //   await botClient.SendTextMessageAsync(message.Chat.Id, $"Ви на {new Random().Next(0,100)}% ставок", replyToMessageId: message.MessageId);
                    return new NoContentResult();
                }
                var user = await db.tgUsers.FirstOrDefaultAsync(x => x.TelegramId == message.From.Id);


                if (message.Text?[0] == '/')
                {
                    if (user == null)
                        user = await new HelloCommand().Execute(message, botClient, db);
                    user.StatusOnCommand = null;
                    foreach (var command in tapCommands)
                    {
                        if (command.Contains(message.Text))
                        {
                            await command.Execute(message, botClient, db, user);
                            break;
                        }


                    }
                }
                //else if (user == null)
                //    return new NoContentResult();
                else if (user.StatusOnCommand != null)
                {
                    foreach (var command in statusCommands)
                    {
                        if (command.Contains(user.StatusOnCommand))
                        {
                            await command.Execute(message, botClient, db, user);
                            break;
                        }
                    }
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Для початку прожміть команду", replyToMessageId: message.MessageId);
                }
                await db.SaveChangesAsync(new CancellationToken());
            }
                return new NoContentResult();
            
        }
    }
}