using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

namespace GolfClapBot.Service.Commands
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