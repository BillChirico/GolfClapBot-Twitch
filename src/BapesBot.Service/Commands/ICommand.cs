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
        Task<bool> Invoke(OnMessageReceivedArgs message);
    }
}