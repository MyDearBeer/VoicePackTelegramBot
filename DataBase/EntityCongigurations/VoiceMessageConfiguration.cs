using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TelegramBot.Models.EntityCongigurations
{
    public class VoiceMessageConfiguration : IEntityTypeConfiguration<VoiceMessage>
    {
        public void Configure(EntityTypeBuilder<VoiceMessage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x=>x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(20);
            builder.HasOne(x=>x.tgUser)
                .WithMany(x => x.Voices)
                .HasForeignKey(x=>x.UserId)
                .HasPrincipalKey(x=>x.TelegramId);
        }
    }
}
