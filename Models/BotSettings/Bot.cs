using Telegram.Bot;
using TelegramBot.CallBacksQuery;
using TelegramBot.DataBase;
using TelegramBot.Models.Commands;
using TelegramBot.Models.Commands.VoiceCommands;
using TelegramBot.Models.Commands.VoiceCommands.AddVoiceCommand;
using TelegramBot.Models.Commands.VoiceCommands.AddVoiceCommand.StatusCommand;
using TelegramBot.Models.Commands.VoiceCommands.DeleteVoiceCommand;
using TelegramBot.Models.Commands.VoiceCommands.DeleteVoiceCommand.StatusCommand;
using TelegramBot.Models.Commands.VoiceCommands.GetVoice;
using TelegramBot.Models.Commands.VoiceCommands.GetVoiceList;

namespace TelegramBot.Models.BotSettings
{
    public static class Bot
    {
        private static TelegramBotClient client { get; set; }
        private static List<Command> tapCommandsList;
        public static IReadOnlyList<Command> TapCommands { get => tapCommandsList.AsReadOnly(); }

        private static List<Command> statusCommandsList;
        public static IReadOnlyList<Command> StatusCommands { get => statusCommandsList.AsReadOnly(); }

        private static List<CallBack> callBackCommandsList;
        public static IReadOnlyList<CallBack> CallBackCommands { get => callBackCommandsList.AsReadOnly(); }
        public static async Task<TelegramBotClient> GetTelegramBot()
        {
            if (client != null)
            {
                return client;
            }
            tapCommandsList = new List<Command>();
            statusCommandsList = new List<Command>();
            callBackCommandsList = new List<CallBack>();

            tapCommandsList.Add(new AddVoiceCommand());
            tapCommandsList.Add(new DeleteVoiceCommand());
            tapCommandsList.Add(new GetVoiceListCommand());
            tapCommandsList.Add(new GetVoiceCommand());
            tapCommandsList.Add(new HelpCommand());
            ////////////
            statusCommandsList.Add(new AddVoiceNameCommand());
            statusCommandsList.Add(new AddVoiceFileCommand());
            statusCommandsList.Add(new DeleteVoiceByIndexCommand());
            ////////////
            callBackCommandsList.Add(new ButtonsListOfVoices());
            client = new TelegramBotClient(AppSettings.Token);
            //var hook = string.Format(AppSettings.Url, "api/message/update");
            //await client.SetWebhookAsync(hook);

            return client;
        }
    }
}
