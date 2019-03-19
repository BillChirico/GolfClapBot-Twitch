using System.Collections.Generic;
using System.Threading.Tasks;
using BapesBot.Service.Counter;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace BapesBot.Service.Commands
{
    /// <summary>
    ///     Adds one to the wins count. Displays the Wins after addition.
    /// </summary>
    public class AddWinCommand : Command
    {
        private readonly ICounterService _counterService;
        private readonly ITwitchClient _twitchClient;

        public AddWinCommand(ITwitchClient twitchClient, ICounterService counterService) : base(new List<string>
            {"addwin", "aw"})
        {
            _twitchClient = twitchClient;
            _counterService = counterService;
            _counterService.AddCounter("Wins");
        }

        public override Task<bool> Invoke(OnMessageReceivedArgs message)
        {
            var counter = _counterService.GetCounter("Wins");

            _counterService.AddCount(counter);

            _twitchClient.SendMessage(message.ChatMessage.Channel,
                $"Win Added. Current Wins: {counter.Count}");

            return Task.FromResult(true);
        }
    }
}