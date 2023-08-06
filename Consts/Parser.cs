namespace TelegramBot.Consts
{
    public static class Parser 
    {
        public static bool TryParse(string text, out uint x)
        {
           bool tryParse = UInt32.TryParse(text, out uint y);
            x = y;
            if (y == 0)
                tryParse = false;
            return tryParse;
        }
    }
}
