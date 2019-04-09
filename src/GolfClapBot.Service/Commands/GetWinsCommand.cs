using System.Collections.Generic;
using System.Threading.Tasks;
using GolfClapBot.Service.Counter;
using GolfClapBot.Service.TwitchApiHelper;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace GolfClapBot.Service.Commands
{
    /// <summary>
    ///     Displays current wins for the current game.
    /// </summary>
    public class GetWinsCommand : Command
    {
        private readonly ICounterService _counterService;
        private readonly ITwitchApiHelper _twitchApiHelper;
        private readonly ITwitchClient _twitchClient;

        public GetWinsCommand(ITwitchClient twitchClient, ICounterService counterService,
            ITwitchApiHelper twitchApiHelper) : base(new List<string>
            {"wins"})
        {
            _twitchClient = twitchClient;
            _counterService = counterService;
            _twitchApiHelper = twitchApiHelper;
        }

        public override async Task<bool> Invoke(ChatMessage message)
        {
            var game = (await _twitchApiHelper.GetStreamGame(message.Channel)).Name;

            var counter = _counterService.GetCounter($"{game}Wins");

            _twitchClient.SendMessage(message.Channel,
                counter == null ? $"There are no wins recorded for {game}!" : $"Current {game} Wins: {counter.Count}");

            return await Task.FromResult(true);
        }
    }
}