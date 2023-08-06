using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TelegramBot.Models;

namespace TelegramBot.DataBase.EntityCongigurations
{
    public class TgUserConfiguration : IEntityTypeConfiguration<TgUser>
    {
        public void Configure(EntityTypeBuilder<TgUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasIndex(x => x.TelegramId).IsUnique();
        }
    }
}
