using System.Collections.Generic;
using System.Threading.Tasks;
using BapesBot.Service.Counter;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

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

        public override Task<bool> Invoke(ChatMessage message)
        {
            var counter = _counterService.GetCounter("Wins");

            _counterService.AddCount(counter);

            _twitchClient.SendMessage(message.Channel,
                $"Win Added. Current Wins: {counter.Count}");

            return Task.FromResult(true);
        }
    }
}