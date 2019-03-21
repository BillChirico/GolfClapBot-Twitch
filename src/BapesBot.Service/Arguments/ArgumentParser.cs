using System;
using System.Collections.Generic;
using System.Linq;

namespace BapesBot.Service.Arguments
{
    public static class ArgumentParser
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