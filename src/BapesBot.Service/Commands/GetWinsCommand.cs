using System.Collections.Generic;
using System.Threading.Tasks;
using BapesBot.Service.Counter;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace BapesBot.Service.Commands
{
    /// <summary>
    ///     Displays current wins.
    /// </summary>
    public class GetWinsCommand : Command
    {
        private readonly ICounterService _counterService;
        private readonly ITwitchClient _twitchClient;

        public GetWinsCommand(ITwitchClient twitchClient, ICounterService counterService) : base(new List<string>
            {"wins"})
        {
            _twitchClient = twitchClient;
            _counterService = counterService;
        }

        public override Task<bool> Invoke(OnMessageReceivedArgs message, List<string> args)
        {
            var counter = _counterService.GetCounter("Wins");

            _twitchClient.SendMessage(message.ChatMessage.Channel,
                $"Current Wins: {counter.Count}");

            return Task.FromResult(true);
        }
    }
}