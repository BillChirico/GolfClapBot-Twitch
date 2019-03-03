using System.Threading.Tasks;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace BapesBot.Service.Commands
{
    public class HelpCommand : Command
    {
        private readonly ITwitchClient _twitchClient;

        public HelpCommand(ITwitchClient twitchClient) : base("help")
        {
            _twitchClient = twitchClient;
        }

        public override Task<bool> Invoke(OnMessageReceivedArgs message)
        {
            _twitchClient.SendMessage(message.ChatMessage.Channel, "You don't need any help yet lol");

            return Task.FromResult(true);
        }
    }
}