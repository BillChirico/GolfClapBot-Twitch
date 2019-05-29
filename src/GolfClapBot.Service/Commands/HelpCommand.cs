using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace GolfClapBot.Service.Commands
{
    public class HelpCommand : Command
    {
        private readonly ITwitchClient _twitchClient;

        public HelpCommand(ITwitchClient twitchClient) : base(new List<string> {"help", "hp"})

        {
            _twitchClient = twitchClient;
        }

        public override Task<bool> Invoke(ChatMessage message)
        {
            _twitchClient.SendMessage(message.Channel, "You don't need any help yet lol");

            return Task.FromResult(true);
        }
    }
}