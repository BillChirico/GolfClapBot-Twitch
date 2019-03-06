using System.Collections.Generic;
using System.Threading.Tasks;
using BapesBot.Service.Counter;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace BapesBot.Service.Commands
{
    /// <summary>
    ///     Removes 1 from a Counter. Displays the Wins after removal. If counter is 0 gives an error.
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
            if (_counterService.GetCount().Counter <= 0)
            {
                _twitchClient.SendMessage(message.ChatMessage.Channel, "No wins to remove");
            }

            else
            {
                _counterService.RemoveCount();
                _twitchClient.SendMessage(message.ChatMessage.Channel,
                    $"Win Removed. Wins now: {_counterService.GetCount().Counter}");
            }

            return Task.FromResult(true);
        }
    }
}