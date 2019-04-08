using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfClapBot.Domain.Constants;
using GolfClapBot.Service.CommandManager;
using GolfClapBot.Service.SoundEffects;
using TwitchLib.Client.Events;

namespace GolfClapBot.Service.SoundEffectManager
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
            // Don't run a command if it is from a known bot
            if (Constants.KnownBots.Any(bot =>
                bot.Equals(message.ChatMessage.Username, StringComparison.InvariantCultureIgnoreCase)))
                return;

            // List of commands that match the message
            var invokedSoundEffects =
                _soundEffects.Where(s => s.SoundEffectTriggers.Any(ct => message.ChatMessage.Message.Contains(ct)));

            foreach (var soundEffect in invokedSoundEffects) await soundEffect.Invoke(message.ChatMessage);
        }
    }
}