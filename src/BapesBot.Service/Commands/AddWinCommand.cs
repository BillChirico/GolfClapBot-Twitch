using System.Threading.Tasks;
using BapesBot.Service.Counter;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;


namespace BapesBot.Service.Commands
{
    public class AddWinCommand : ICommand
    {
        private readonly ITwitchClient _twitchClient;
        private readonly ICounterService _counterService;

        public AddWinCommand(ITwitchClient twitchClient, ICounterService counterService) : base("addwin")
        {
            _twitchClient = twitchClient;
            _counterService = counterService;
        }

        public override Task<bool> Invoke(OnMessageReceivedArgs message)
        {
            _counterService.AddCount();
            _twitchClient.SendMessage(message.ChatMessage.Channel, $"Win Added. Current Wins: {_counterService.GetCount().Counter}");
            
            return Task.FromResult(true);
        }
    }
}
