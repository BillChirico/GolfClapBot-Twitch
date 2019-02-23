using System;
using System.Threading.Tasks;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace BapesBot.Service.TwitchBot
{
    public class TwitchBot : ITwitchBot
    {
        private readonly ITwitchClient _twitchClient;

        public TwitchBot(ITwitchClient twitchClient)
        {
            _twitchClient = twitchClient;
        }

        public Task Connect(string twitchUsername, string accessToken)
        {
            _twitchClient.Initialize(new ConnectionCredentials(twitchUsername, accessToken));
            _twitchClient.OnLog += OnLog;
            _twitchClient.Connect();
            return Task.CompletedTask;
        }

        private void OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime.ToString()}: {e.BotUsername} - {e.Data}");
        }
    }
}