namespace TelegramBot.Models
{
    public class TgUser
    {
        public Guid Id { get; set; }

        public long TelegramId{ get; set; }
        public string? UserName { get; set; }
        public string? StatusOnCommand { get; set; }
        public string? LastFileName { get; set; }
        public IEnumerable<VoiceMessage> Voices { get; set; }
    }
}
