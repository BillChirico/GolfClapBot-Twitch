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
using TwitchLib.Client.Interfaces;

namespace GolfClapBot.Service.CommandManager
{
    public class CommandManager : ICommandManager
    {
        private readonly IList<Command> _commands;
        private readonly ITwitchClient _twitchClient;
        private readonly IVariableManager _variableManager;

        public CommandManager(IList<Command> commands, IVariableManager variableManager, ITwitchClient twitchClient)
        {
            _commands = commands;
            _variableManager = variableManager;
            _twitchClient = twitchClient;
        }

        public async Task MessageReceived(object sender, OnMessageReceivedArgs message)
        {
            // Don't run the command if it does not start with a prefix
            if (!Constants.CommandPrefixes.Contains(message.ChatMessage.Message[0].ToString()))
                return;

            // Get arguments and inject variables
            var args = await _variableManager.InjectVariables(new VariableContext
            {
                StreamerUserName = message.ChatMessage.Channel
            }, MessageHelper.GetArguments(message.ChatMessage.Message));

            var command = MessageHelper.GetCommand(message.ChatMessage.Message);

            // List of commands that match the message
            var invokedCommands = _commands.Where(c =>
                c.CommandTriggers.Any(ct => string.Equals(ct, command, StringComparison.InvariantCultureIgnoreCase)));

            foreach (var invokedCommand in invokedCommands)
            {
                var result = await invokedCommand.ProcessArgs(args);

                if (result)
                    await invokedCommand.Invoke(message.ChatMessage);
                else
                    _twitchClient.SendMessage(message.ChatMessage.Channel,
                        "Command Error: Invalid number of parameters!");
            }
        }
    }
}