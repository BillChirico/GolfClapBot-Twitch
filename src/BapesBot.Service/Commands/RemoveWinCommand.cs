using System.Collections.Generic;
using System.Threading.Tasks;
using BapesBot.Service.Counter;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace BapesBot.Service.Commands
{
    /// <summary>
    ///     Removes one to the wins counter. Displays the Wins after removal. If counter is zero gives an error.
    /// </summary>
    public class RemoveWinCommand : Command
    {
        private readonly ICounterService _counterService;
        private readonly ITwitchClient _twitchClient;

        public RemoveWinCommand(ITwitchClient twitchClient, ICounterService counterService) : base(new List<string>
            {"removewin", "rw"})
        {
            _twitchClient = twitchClient;
            _counterService = counterService;
        }

        public override Task<bool> Invoke(OnMessageReceivedArgs message)
        {
            var counter = _counterService.GetCounter("Wins");

            if (counter.Count <= 0)
            {
                _twitchClient.SendMessage(message.ChatMessage.Channel, "No wins to remove.");
            }

            else
            {
                _counterService.RemoveCount(counter);
                _twitchClient.SendMessage(message.ChatMessage.Channel,
                    $"Win Removed. Wins now: {counter.Count}");
            }

            return Task.FromResult(true);
        }
    }
}