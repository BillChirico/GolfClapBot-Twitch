using System;
using System.Collections.Generic;
using System.Linq;

namespace BapesBot.Service.Arguments
{
    public static class ArgumentParser
    {
        public static List<string> GetArguments(string message)
        {
            message = message.Substring(message.IndexOf(' ') + 1);

            return message.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}