using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Client.Models;

namespace GolfClapBot.Service.Commands
{
    public interface ICommand
    {
        /// <summary>
        ///     Triggers used to invoke the command.
        /// </summary>
        List<string> CommandTriggers { get; }

        /// <summary>
        ///     Invoke the command.
        /// </summary>
        /// <param name="message">Message received.</param>
        Task<bool> Invoke(ChatMessage message);

        /// <summary>
        ///     Process arguments for the command.
        /// </summary>
        /// <param name="args">Arguments passed.</param>
        Task<bool> ProcessArgs(List<string> args);
    }
}