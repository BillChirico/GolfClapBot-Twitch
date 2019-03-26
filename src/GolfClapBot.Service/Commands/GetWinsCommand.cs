using System.Collections.Generic;
using System.Threading.Tasks;
using GolfClapBot.Service.Counter;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace GolfClapBot.Service.Commands
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

        public override Task<bool> Invoke(ChatMessage message)
        {
            var counter = _counterService.GetCounter("Wins");

            _twitchClient.SendMessage(message.Channel,
                counter != null ? $"Current Wins: {counter.Count}" : "Current Wins: 0");

            return Task.FromResult(true);
        }
    }
}