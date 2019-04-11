using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Client.Models;

namespace GolfClapBot.Service.Commands
{
    public abstract class Command : ICommand
    {
        protected Command(List<string> commandTriggers)
        {
            CommandTriggers = commandTriggers;
        }

        public List<string> CommandTriggers { get; }

        /// <inheritdoc />
        public abstract Task<bool> Invoke(ChatMessage message);

        /// <inheritdoc />
        public virtual Task<bool> ProcessArgs(List<string> args)
        {
            return Task.FromResult(true);
        }
    }
}