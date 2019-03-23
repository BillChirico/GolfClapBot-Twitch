using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using BapesBot.Service.Commands;
using TwitchLib.Client.Models;

namespace BapesBot.Service.SoundEffects
{
    public class SoundEffect : ICommand
    {
        protected SoundEffect(List<string> soundEffectTriggers, string file)
        {
            SoundEffectTriggers = soundEffectTriggers;
            File = file;
        }

        public List<string> SoundEffectTriggers { get; }

        private string File { get; }

        /// <summary>
        ///     Play sound effect.
        /// </summary>
        /// <param name="message">Message received.</param>
        public Task<bool> Invoke(ChatMessage message)
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