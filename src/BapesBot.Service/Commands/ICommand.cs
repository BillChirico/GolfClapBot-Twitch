using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace BapesBot.Service.Commands
{
    public interface ICommand
    {
        /// <summary>
        ///     Invoke the command.
        /// </summary>
        /// <param name="message">Message received.</param>
        Task<bool> Invoke(ChatMessage message);
    }
}