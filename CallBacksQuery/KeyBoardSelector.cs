using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Consts;

namespace TelegramBot.CallBacksQuery
{
    public static class KeyBoardSelector
    {
        public static InlineKeyboardMarkup GetKeyboardMarkup(int page, int voiceCount)
        {
            InlineKeyboardMarkup? replyMark = Buttons.Ikm;
            if ((page) * Buttons.Limit >= voiceCount)
            {
                replyMark = new InlineKeyboardMarkup(Buttons.Ikm.InlineKeyboard.First().Take(1));
            }
            if (page * Buttons.Limit == Buttons.Limit)
            {
                replyMark = new InlineKeyboardMarkup(Buttons.Ikm.InlineKeyboard.First().Skip(1));
            }
            if (voiceCount <= Buttons.Limit)
            {
                replyMark = null;
            }
            return replyMark;
        }
    }
}
