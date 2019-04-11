using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}