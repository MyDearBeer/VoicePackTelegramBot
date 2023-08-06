using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Consts
{
    public  class Buttons
    {
        public const int Limit = 5;
        public static InlineKeyboardMarkup Ikm
        {
            get => new InlineKeyboardMarkup(new[]
   {
    new[]
    {
        InlineKeyboardButton.WithCallbackData("<<", "*previousvoices"),
        InlineKeyboardButton.WithCallbackData(">>", "*nextvoices"),
    },

});
        }
    }
    
}
