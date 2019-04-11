using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using GolfClapBot.Service.Commands;
using TwitchLib.Client.Models;

namespace GolfClapBot.Service.SoundEffects
{
    public class SoundEffect : ICommand
    {
        protected SoundEffect(List<string> soundEffectTriggers, string file)
        {
            CommandTriggers = soundEffectTriggers;
            File = file;
        }

        private string File { get; }

        public List<string> CommandTriggers { get; }

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

        public Task<bool> ProcessArgs(List<string> args)
        {
            return Task.FromResult(true);
        }
    }
}