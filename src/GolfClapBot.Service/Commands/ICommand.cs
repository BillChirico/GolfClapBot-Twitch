using System.Collections.Generic;
using System.Threading.Tasks;
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

        /// <summary>
        ///     Process arguments for the command.
        /// </summary>
        /// <param name="args">Arguments passed.</param>
        Task ProcessArgs(List<string> args);
    }
}