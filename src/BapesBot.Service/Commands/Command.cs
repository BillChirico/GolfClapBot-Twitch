using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Client.Models;

namespace BapesBot.Service.Commands
{
    public abstract class Command : ICommand
    {
        protected Command(List<string> commandTriggers)
        {
            CommandTriggers = commandTriggers;
        }

        public List<string> CommandTriggers { get; }

        public abstract Task<bool> Invoke(ChatMessage message);
    }
}