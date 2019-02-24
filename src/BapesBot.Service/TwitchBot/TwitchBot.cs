using System;
using System.Globalization;
using System.Threading.Tasks;
using BapesBot.Service.CommandManager;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace BapesBot.Service.TwitchBot
{
    public class TwitchBot : ITwitchBot
    {
        private readonly ITwitchClient _twitchClient;
        private readonly ICommandManager _commandManager;

        public TwitchBot(ITwitchClient twitchClient, ICommandManager commandManager)
        {
            _twitchClient = twitchClient;
            _commandManager = commandManager;
        }

        public Task Connect(string twitchUsername, string accessToken)
        {
            _twitchClient.Initialize(new ConnectionCredentials(twitchUsername, accessToken));
            _twitchClient.OnLog += OnLog;
            _twitchClient.Connect();

            _twitchClient.OnConnected += (sender, args) => { _twitchClient.JoinChannel("bapes"); };

            _twitchClient.OnMessageReceived += _commandManager.MessageReceived;

            return Task.CompletedTask;
        }

        private void OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime.ToString(CultureInfo.InvariantCulture)}: {e.BotUsername} - {e.Data}");
        }
    }
}