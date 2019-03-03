using System.Threading.Tasks;
using TwitchLib.Client.Events;

namespace BapesBot.Service.Commands
{
    public abstract class Command : ICommand
    {
        protected Command(string commandText)
        {
            CommandText = commandText;
        }

        public abstract Task<bool> Invoke(OnMessageReceivedArgs message);

        public string CommandText { get; }
    }
}