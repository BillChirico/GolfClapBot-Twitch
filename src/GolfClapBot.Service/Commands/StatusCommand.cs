using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace GolfClapBot.Service.Commands
{
    /// <summary>
    ///     Sends a message if the bot is running.
    /// </summary>
    public class StatusCommand : Command
    {
        private readonly ITwitchClient _twitchClient;

        public StatusCommand(ITwitchClient twitchClient) : base(new List<string> { "status", "st" })

        {
            _twitchClient = twitchClient;
        }

        public override Task<bool> Invoke(ChatMessage message)
        {
            _twitchClient.SendMessage(message.Channel, "Running");

            return Task.FromResult(true);
        }
    }
}