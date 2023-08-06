using Microsoft.EntityFrameworkCore;
using TelegramBot.Models;

namespace TelegramBot.DataBase
{
    public interface IDbContext
    {
       public DbSet<VoiceMessage> voiceMessages { get; set; }
       public DbSet<TgUser> tgUsers { get; set; }
       Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
