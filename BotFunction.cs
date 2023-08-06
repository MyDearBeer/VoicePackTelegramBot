namespace TelegramBot
{
    public abstract class BotFunction
    {
        public abstract string? Name { get; }
        public virtual bool Contains(string message)
        {
            if (message == null) return false;
            return message.Contains(this.Name);
        }
    }
}
