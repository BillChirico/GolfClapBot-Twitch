using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Client.Events;

namespace BapesBot.Service.Commands
{
    public abstract class Command : ICommand
    {
        protected Command(List<string> commandText)
        {
            CommandText = commandText;
        }

        public List<string> CommandText { get; }

        public abstract Task<bool> Invoke(OnMessageReceivedArgs message);
    }
}