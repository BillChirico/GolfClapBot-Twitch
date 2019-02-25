using System.Threading.Tasks;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace BapesBot.Service.Commands
{
    public class RemoveWinCommand : ICommand
    {
        private readonly ITwitchClient _twitchClient;

        public RemoveWinCommand(ITwitchClient twitchClient) : base("removewin")
        {
            _twitchClient = twitchClient;
        }

        public override Task<bool> Invoke(OnMessageReceivedArgs message)
        {

            if (AddWinCommand.Wins <= 0)
            {
                _twitchClient.SendMessage(message.ChatMessage.Channel, $"No wins to remove");
            }

            else
            {
                AddWinCommand.Wins -= 1;
                _twitchClient.SendMessage(message.ChatMessage.Channel, $"Win Removed. Wins now: {AddWinCommand.Wins}");
            }

            return Task.FromResult(true);
        }
    }
}
