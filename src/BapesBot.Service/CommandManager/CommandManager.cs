using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BapesBot.Service.Commands;
using TwitchLib.Client.Events;

namespace BapesBot.Service.CommandManager
{
    public class CommandManager : ICommandManager
    {
        private readonly IList<Command> _commands;

        public CommandManager(IList<Command> commands)
        {
            _commands = commands;
        }

        public async Task MessageReceived(object sender, OnMessageReceivedArgs message)
        {
            // List of commands that match the message
            var invokedCommands = _commands.Where(c =>
                string.Equals($"${c.CommandText}", message.ChatMessage.Message,
                    StringComparison.InvariantCultureIgnoreCase));

            foreach (var command in invokedCommands)
            {
                await command.Invoke(message);
            }
        }
    }
}