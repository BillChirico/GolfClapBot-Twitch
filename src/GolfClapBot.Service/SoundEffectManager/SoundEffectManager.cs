using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfClapBot.Domain.Settings;
using GolfClapBot.Service.CommandManager;
using GolfClapBot.Service.SoundEffects;
using Microsoft.Extensions.Options;
using TwitchLib.Client.Events;

namespace GolfClapBot.Service.SoundEffectManager
{
    public class SoundEffectManager : ICommandManager
    {
        private readonly GolfClapBotSettings _settings;
        private readonly IList<SoundEffect> _soundEffects;

        public SoundEffectManager(IList<SoundEffect> soundEffects, IOptions<GolfClapBotSettings> settings)
        {
            _soundEffects = soundEffects;
            _settings = settings.Value;
        }

        public async Task MessageReceived(object sender, OnMessageReceivedArgs message)
        {
            if (!_settings.EnableSoundEffects)
                return;

            // List of commands that match the message
            var invokedSoundEffects =
                _soundEffects.Where(s => s.CommandTriggers.Any(ct => message.ChatMessage.Message.Contains(ct)));

            foreach (var soundEffect in invokedSoundEffects) await soundEffect.Invoke(message.ChatMessage);
        }
    }
}