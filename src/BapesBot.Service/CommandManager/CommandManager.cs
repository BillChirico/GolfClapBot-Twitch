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
            // Don't check for commands if the message doesn't start with a prefix
            if (!(message.ChatMessage.Message.StartsWith("$") || message.ChatMessage.Message.StartsWith("!"))) return;

            // List of commands that match the message
            var invokedCommands = _commands.Where(c =>
                c.CommandTriggers.Any(ct => string.Equals(ct,
                    message.ChatMessage.Message.Substring(1),
                    StringComparison.InvariantCultureIgnoreCase)));

            foreach (var command in invokedCommands) await command.Invoke(message);
        }
    }
}