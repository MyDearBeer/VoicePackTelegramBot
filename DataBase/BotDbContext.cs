using Microsoft.EntityFrameworkCore;
using TelegramBot.DataBase.EntityCongigurations;
using TelegramBot.Models;
using TelegramBot.Models.EntityCongigurations;

namespace TelegramBot.DataBase
{
    public class BotDbContext : DbContext,IDbContext
    {
        public DbSet<VoiceMessage> voiceMessages { get; set; }
        public DbSet<TgUser> tgUsers { get; set; }
        public BotDbContext(DbContextOptions<BotDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TgUserConfiguration());
            builder.ApplyConfiguration(new VoiceMessageConfiguration());
            base.OnModelCreating(builder);
        }
        }
}
