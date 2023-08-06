namespace TelegramBot.Models
{
    public class VoiceMessage
    {
        public Guid Id { get; set; }
        public long UserId { get; set; }
        public string TgId { get; set; }
        public string Name { get; set; }
        public long? Size { get; set; }
        public int Duration { get; set; }
        public TgUser? tgUser { get; set; } 
    }
}
