using Microsoft.EntityFrameworkCore;
using System.Text;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using TelegramBot.Consts;
using TelegramBot.DataBase;

namespace TelegramBot.Models.Commands.VoiceCommands.GetVoiceListCommand
{
    public static class GetVoicesByUser
    {
        public static async Task<List<VoiceMessage>> GetVoices(IDbContext dbContext, long id)
        {
            var voiceList = await dbContext.voiceMessages.Where(x => x.UserId == id).ToListAsync();
            

            return voiceList;
        }
    }
}
