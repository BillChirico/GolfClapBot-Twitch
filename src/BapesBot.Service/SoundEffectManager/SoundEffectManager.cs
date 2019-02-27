using System.Collections.Generic;
using BapesBot.Service.CommandManager;
using BapesBot.Service.SoundEffects;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace BapesBot.Service.SoundEffectManager
{
    public class SoundEffectManager : ICommandManager
    {
        private readonly ITwitchClient _twitchClient;
        private readonly IList<ISoundEffect> _soundEffects;

        public SoundEffectManager(ITwitchClient twitchClient, IList<ISoundEffect> soundEffects)
        {
            _twitchClient = twitchClient;
            _soundEffects = soundEffects;
        }

        public void MessageReceived(object sender, OnMessageReceivedArgs message)
        {
            
        }
    }
}