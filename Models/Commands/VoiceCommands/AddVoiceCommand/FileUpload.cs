using System.Resources;
using Telegram.Bot;
using Telegram.Bot.Types;
using Xabe.FFmpeg;

namespace TelegramBot.Models.Commands.VoiceCommands.AddVoiceCommand
{
    public static class FileUpload
    {
        public async static Task<string> FileAdd(TelegramBotClient client, VoiceMessage voicemessage, Message message)
        {
            var physicalPath = $"{Directory.GetCurrentDirectory()}\\Voices\\{voicemessage.Name}({voicemessage.UserId}).mp3";
            //var physicalPathVideo = $"{Directory.GetCurrentDirectory()}\\Voices\\{voicemessage.Name}({voicemessage.UserId}).mp4";
            var convertedPath = $"{Directory.GetCurrentDirectory()}\\Voices\\{voicemessage.Name}({voicemessage.UserId}).ogg";
            string voiceFileId = "";
            var file = await client.GetFileAsync(voicemessage.TgId);


            await using (var stream = new FileStream( physicalPath , FileMode.Create))
            {

                await client.DownloadFileAsync(file.FilePath, stream);
               
             
            }
                    try
                    {
                FFmpeg.SetExecutablesPath("C:\\ProgramData\\chocolatey\\lib\\ffmpeg\\tools\\ffmpeg\\bin");
                //if (message.Video != null)
                //{
                //  var conversion = await FFmpeg.Conversions.FromSnippet.ExtractAudio(physicalPathVideo, physicalPath) ;
                //    await conversion.Start();
                //    System.IO.File.Delete(physicalPathVideo);
                //}
                IMediaInfo info = await FFmpeg.GetMediaInfo(physicalPath);
                    IStream audioStream ;
                 
                    if (message.Caption != null)
                    {
                        uint[] cutArray = new uint[2];
                        string[] cutNumbers = message.Caption.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (UInt32.TryParse(cutNumbers[0], out cutArray[0]) && UInt32.TryParse(cutNumbers[1], out cutArray[1]))
                        {
                            if (cutArray[0]>=voicemessage.Duration)
                                return voiceFileId;
                             audioStream = info.AudioStreams.FirstOrDefault()?.SetCodec("opus -strict -2").Split(TimeSpan.FromSeconds(cutArray[0]), TimeSpan.FromSeconds(cutArray[1]));
                            
                        }
                        else
                        {
                            return voiceFileId;
                        }
                       
                    }

                    else
                    {
                        audioStream = info.AudioStreams.FirstOrDefault()?.SetCodec("opus -strict -2");
                    }
               

                    await FFmpeg.Conversions.New().AddStream(audioStream).SetOutput(convertedPath).Start();
                }
                    catch(Exception ex) {
                System.IO.File.Delete(physicalPath);
                return voiceFileId;
                    }

                
                System.IO.File.Delete(physicalPath);
                await using (var stream = new FileStream(convertedPath, FileMode.Open))
                {
                   var voice = await client.SendVoiceAsync(chatId: -1001967057216, voice: InputFile.FromStream(stream));
                    voiceFileId = voice.Voice.FileId;
                }
                System.IO.File.Delete(convertedPath);
            
           

            return voiceFileId;
        }
    }
}
