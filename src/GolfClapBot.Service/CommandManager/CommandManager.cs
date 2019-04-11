using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfClapBot.Domain.Constants;
using GolfClapBot.Domain.Variables;
using GolfClapBot.Service.Commands;
using GolfClapBot.Service.MessageHelpers;
using GolfClapBot.Service.VariableManager;
using TwitchLib.Client.Events;

namespace GolfClapBot.Service.CommandManager
{
    public class CommandManager : ICommandManager
    {
        private readonly IList<Command> _commands;
        private readonly IVariableManager _variableManager;

        public CommandManager(IList<Command> commands, IVariableManager variableManager)
        {
            _commands = commands;
            _variableManager = variableManager;
        }

        public async Task MessageReceived(object sender, OnMessageReceivedArgs message)
        {
            // Don't run a command if it is from a known bot
            if (Constants.KnownBots.Any(bot =>
                bot.Equals(message.ChatMessage.Username, StringComparison.InvariantCultureIgnoreCase)))
                return;

            // Don't check for commands if the message doesn't start with a prefix
            if (!(message.ChatMessage.Message.StartsWith("$") || message.ChatMessage.Message.StartsWith("!"))) return;

            // Get arguments and inject variables
            var args = await _variableManager.InjectVariables(new VariableContext
            {
                StreamerUserName = message.ChatMessage.Channel
            }, MessageHelper.GetArguments(message.ChatMessage.Message));

            var command = message.ChatMessage.Message.Substring(1);

            // Remove arguments
            if (message.ChatMessage.Message.Contains(' '))
                command = command.Remove(command.IndexOf(' '));

            // List of commands that match the message
            var invokedCommands = _commands.Where(c =>
                c.CommandTriggers.Any(ct => string.Equals(ct, command, StringComparison.InvariantCultureIgnoreCase)));

            foreach (var invokedCommand in invokedCommands)
            {
                await invokedCommand.ProcessArgs(args);

                await invokedCommand.Invoke(message.ChatMessage);
            }
        }
    }
}