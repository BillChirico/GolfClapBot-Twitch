﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;

namespace BapesBot.Service.Commands
{
    /// <summary>
    ///     Sends a message if the bot is running.
    /// </summary>
    public class StatusCommand : Command
    {
        private readonly ITwitchClient _twitchClient;

        public StatusCommand(ITwitchClient twitchClient) : base(new List<string> {"status", "st"})

        {
            _twitchClient = twitchClient;
        }

        public override Task<bool> Invoke(OnMessageReceivedArgs message, List<string> args)
        {
            _twitchClient.SendMessage(message.ChatMessage.Channel, "Running");

            return Task.FromResult(true);
        }
    }
}