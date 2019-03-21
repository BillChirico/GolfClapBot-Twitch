using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Client.Events;

namespace BapesBot.Service.Commands
{
    public interface ICommand
    {
        /// <summary>
        ///     Invoke the command.
        /// </summary>
        /// <param name="message">Message received.</param>
        /// <param name="args">Arguments from the message.</param>
        Task<bool> Invoke(OnMessageReceivedArgs message, List<string> args);
    }
}