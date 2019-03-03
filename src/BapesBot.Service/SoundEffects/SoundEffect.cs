using System.Diagnostics;
using System.Threading.Tasks;
using BapesBot.Service.Commands;
using TwitchLib.Client.Events;

namespace BapesBot.Service.SoundEffects
{
    public class SoundEffect : ICommand
    {
        protected SoundEffect(string command, string file)
        {
            Command = command;
            File = file;
        }

        public string Command { get; }
        private string File { get; }

        /// <summary>
        ///     Play sound effect.
        /// </summary>
        /// <param name="message">Message received.</param>
        public Task<bool> Invoke(OnMessageReceivedArgs message)
        {
            try
            {
                Process.Start(@"powershell", $@"-c (New-Object Media.SoundPlayer '{File}').PlaySync();");

                return Task.FromResult(true);
            }
            catch
            {
                return Task.FromResult(false);
            }
        }
    }
}