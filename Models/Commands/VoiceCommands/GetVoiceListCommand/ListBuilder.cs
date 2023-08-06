using System.Text;

namespace TelegramBot.Models.Commands.VoiceCommands.GetVoiceListCommand
{
    public static class ListBuilder
    {
        public static StringBuilder ListBuild(List<VoiceMessage> voices, int index)
        {
            StringBuilder voiceListStr = new StringBuilder("Список ваших войсів : \n\n");
            foreach(var voice in voices)
            {
                try
                {
                    voiceListStr.Append($"/{index + 1}. {voice.Name}\n");
                    index++;
                }
                catch(Exception exeption)
                {

                }
            }

            return voiceListStr;
        }
    }
}
