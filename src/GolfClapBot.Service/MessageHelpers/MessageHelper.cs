using System;

namespace GolfClapBot.Service.MessageHelpers
{
    public static class MessageHelper
    {
        public static object[] GetArguments(string message)
        {
            // No arguments
            if (!message.Contains(' ')) return new object[] { };

            message = message.Substring(message.IndexOf(' ') + 1);

            return message.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}