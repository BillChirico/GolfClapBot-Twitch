using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfClapBot.Service.Integrations.Fortnite;
using GolfClapBot.Service.TwitchApiHelper;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace GolfClapBot.Service.Commands.Integrations.Fortnite
{
    public class FortniteTotalWinsCommand : Command
    {
        private readonly IFortniteApi _fortniteApi;
        private readonly ITwitchApiHelper _twitchApiHelper;
        private readonly ITwitchClient _twitchClient;

        public FortniteTotalWinsCommand(ITwitchClient twitchClient, IFortniteApi fortniteApi,
            ITwitchApiHelper twitchApiHelper) : base(new List<string>
            {"totalwins"})
        {
            _twitchClient = twitchClient;
            _fortniteApi = fortniteApi;
            _twitchApiHelper = twitchApiHelper;
        }

        public override async Task<bool> Invoke(ChatMessage message)
        {
            var game = await _twitchApiHelper.GetStreamGame(message.Channel);

            if (game == null)
            {
                _twitchClient.SendMessage(message.Channel,
                    "The streamer either is not online or does not have a game set!");

                return await Task.FromResult(false);
            }

            if (game.Name != "Fortnite")
                return await Task.FromResult(false);

            var fortniteStats = await _fortniteApi.Get();

            var totalWins = fortniteStats.LifeTimeStats.FirstOrDefault(s => s.Key == "Wins");

            if (totalWins == null)
                return await Task.FromResult(false);

            _twitchClient.SendMessage(message.Channel, $"Total Fortnite Wins: {totalWins.Value}");

            return await Task.FromResult(true);
        }
    }
}