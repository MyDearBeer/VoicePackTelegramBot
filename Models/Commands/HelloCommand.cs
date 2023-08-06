using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.DataBase;
using TelegramBot.Models.BotSettings;

namespace TelegramBot.Models.Commands
{
    public class HelloCommand 
    {
        public async Task<TgUser> Execute(Message message, TelegramBotClient client, IDbContext dbContext)
        {

                var TgUser = new TgUser()
                {
                    TelegramId = message.From.Id,
                    UserName = message.From.Username,
                    StatusOnCommand = null
                   
                };
                await dbContext.tgUsers.AddAsync(TgUser);
                await dbContext.SaveChangesAsync(new CancellationToken());
                await client.SendTextMessageAsync(message.Chat.Id, "Вітаю, цей бот дасть змогу тобі створити свій аудіопак. Для допомоги та списку команд звертайся через /help");
            return TgUser;
            }
        }
    }

