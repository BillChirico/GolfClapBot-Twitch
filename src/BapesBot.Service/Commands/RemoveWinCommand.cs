using System.Threading.Tasks;
using BapesBot.Service.Counter;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace BapesBot.Service.Commands
{
    public class RemoveWinCommand : ICommand
    {
        private readonly ITwitchClient _twitchClient;
        private readonly ICounterService _counterService;

        public RemoveWinCommand(ITwitchClient twitchClient, ICounterService counterService) : base("removewin")
        {
            _twitchClient = twitchClient;
            _counterService = counterService;
        }

        public override Task<bool> Invoke(OnMessageReceivedArgs message)
        {

            if (_counterService.GetCount().Counter <= 0)
            {
                _twitchClient.SendMessage(message.ChatMessage.Channel, $"No wins to remove");
            }

            else
            {
                _counterService.RemoveCount();
                _twitchClient.SendMessage(message.ChatMessage.Channel, $"Win Removed. Wins now: {_counterService.GetCount().Counter}");
            }

            return Task.FromResult(true);
        }
    }
}
