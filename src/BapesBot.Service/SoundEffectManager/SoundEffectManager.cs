using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BapesBot.Service.CommandManager;
using BapesBot.Service.SoundEffects;
using TwitchLib.Client.Events;

namespace BapesBot.Service.SoundEffectManager
{
    public class SoundEffectManager : ICommandManager
    {
        private readonly IList<SoundEffect> _soundEffects;

        public SoundEffectManager(IList<SoundEffect> soundEffects)
        {
            _soundEffects = soundEffects;
        }

        public async Task MessageReceived(object sender, OnMessageReceivedArgs message)
        {
            // List of commands that match the message
            var invokedSoundEffects =
                _soundEffects.Where(s => s.SoundEffectTriggers.Any(ct => message.ChatMessage.Message.Contains(ct)));

            foreach (var soundEffect in invokedSoundEffects) await soundEffect.Invoke(message);
        }
    }
}