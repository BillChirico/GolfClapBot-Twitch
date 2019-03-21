using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Client.Events;

namespace BapesBot.Service.Commands
{
    public abstract class Command : ICommand
    {
        protected Command(List<string> commandTriggers)
        {
            CommandTriggers = commandTriggers;
        }

        public List<string> CommandTriggers { get; }

        public abstract Task<bool> Invoke(OnMessageReceivedArgs message, List<string> args);
    }
}