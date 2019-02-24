using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BapesBot.Service.Commands;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace BapesBot.Service.CommandManager
{
    public class CommandManager : ICommandManager
    {
        private readonly ITwitchClient _twitchClient;
        private readonly IList<ICommand> _commands;

        public CommandManager(ITwitchClient twitchClient, IList<ICommand> commands)
        {
            _twitchClient = twitchClient;
            _commands = commands;
        }

        public async void MessageReceived(object sender, OnMessageReceivedArgs message)
        {
            // List of commands that match the message
            var invokedCommands = _commands.Where(c =>
                string.Equals($"${c.CommandText}", message.ChatMessage.Message, StringComparison.InvariantCultureIgnoreCase));

            foreach (var command in invokedCommands)
            {
                await command.Invoke(message);
            }
        }
    }
}