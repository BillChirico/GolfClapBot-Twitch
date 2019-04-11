using System;
using System.Collections.Generic;
using System.Linq;
using GolfClapBot.Domain.Constants;

namespace GolfClapBot.Service.MessageHelpers
{
    public static class MessageHelper
    {
        public static List<string> GetArguments(string message)
        {
            // No arguments
            if (!message.Contains(' ')) return new List<string>();

            message = message.Substring(message.IndexOf(' ') + 1);

            return message.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        /// <summary>
        ///     Get the command name and remove arguments.
        /// </summary>
        /// <param name="message">Message to get the command from.</param>
        /// <returns>Command name.</returns>
        public static string GetCommand(string message)
        {
            // Remove arguments
            if (message.Contains(' '))
                message = message.Remove(message.IndexOf(' '));

            foreach (var prefix in Constants.CommandPrefixes)
                if (message[0].ToString() == prefix)
                    return message.Substring(1);

            return message;
        }
    }
}