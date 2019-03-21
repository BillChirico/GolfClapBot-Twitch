using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BapesBot.Service.Arguments;
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

            var args = ArgumentParser.GetArguments(message.ChatMessage.Message);

            var command = message.ChatMessage.Message.Substring(1);

            // Remove arguments
            if (message.ChatMessage.Message.Contains(' '))
                command = command.Remove(command.IndexOf(' '));

            // List of commands that match the message
            var invokedCommands = _commands.Where(c =>
                c.CommandTriggers.Any(ct => string.Equals(ct,
                    command,
                    StringComparison.InvariantCultureIgnoreCase)) && (c.GetType().GetMethod("SetArguments") == null ||
                                                                      c.GetType().GetMethod("SetArguments")
                                                                          .GetParameters()
                                                                          .Length == args.Length));

            foreach (var invokedCommand in invokedCommands)
            {
                var setArgumentsMethod = invokedCommand.GetType().GetMethod("SetArguments");

                // Set arguments
                if (setArgumentsMethod != null)
                    setArgumentsMethod.Invoke(invokedCommand, args);

                await invokedCommand.Invoke(message.ChatMessage);
            }
        }
    }
}