using System;
using System.Globalization;
using System.Threading.Tasks;
using GolfClapBot.Service.CommandManager;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace GolfClapBot.Service.TwitchBot
{
    public class TwitchBot : ITwitchBot
    {
        private readonly ICommandManager _commandManager;
        private readonly SoundEffectManager.SoundEffectManager _soundEffectManager;
        private readonly ITwitchClient _twitchClient;

        public TwitchBot(ITwitchClient twitchClient, ICommandManager commandManager,
            SoundEffectManager.SoundEffectManager soundEffectManager)
        {
            _twitchClient = twitchClient;
            _commandManager = commandManager;
            _soundEffectManager = soundEffectManager;
        }

        public Task Connect(string twitchUsername, string accessToken)
        {
            _twitchClient.Initialize(new ConnectionCredentials(twitchUsername, accessToken));
            _twitchClient.OnLog += OnLog;
            _twitchClient.Connect();

            _twitchClient.OnConnected += (sender, args) => { _twitchClient.JoinChannel("bapes"); };

            _twitchClient.OnMessageReceived += async (sender, message) =>
            {
                await _commandManager.MessageReceived(sender, message);
                await _soundEffectManager.MessageReceived(sender, message);
            };

            return Task.CompletedTask;
        }

        private void OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime.ToString(CultureInfo.InvariantCulture)}: {e.Data}");
        }
    }
}