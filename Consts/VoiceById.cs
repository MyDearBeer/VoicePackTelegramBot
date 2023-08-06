using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot.DataBase;
using TelegramBot.Models;

namespace TelegramBot.Consts
{
    public static class VoiceById
    {
        public static async Task<VoiceMessage> GetVoiceById(IDbContext dbContext, TelegramBotClient client, uint index, Message message)
        {
            var voice =  index!=0 ?
            await dbContext.voiceMessages.Where(x => x.UserId == message.From.Id).Skip((int)(Math.Abs(index) - 1)).FirstOrDefaultAsync()
              : null;
            if(voice == null)
            {
                await client.SendTextMessageAsync(message.Chat.Id, "Невірний індекс, спробуйте ще раз.", replyToMessageId: message.MessageId);
   
            }
            return voice;
        }
    }
}
