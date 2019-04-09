using System.Threading.Tasks;
using GolfClapBot.Domain.Variables;

namespace GolfClapBot.Service.VariableManager
{
    /// <summary>
    ///     Manager to inject variables into strings.
    /// </summary>
    public interface IVariableManager
    {
        /// <summary>
        ///     Inject variables into the specified message.
        /// </summary>
        /// <param name="variableContext">Context for the variables.</param>
        /// <param name="message">Message to inject variables into.</param>
        /// <returns>Message with variables replaces.</returns>
        Task<string> InjectVariables(VariableContext variableContext, string message);

        /// <summary>
        ///     Inject variables into the specified messages.
        /// </summary>
        /// <param name="variableContext">Context for the variables.</param>
        /// <param name="messages">Messages to inject variables into.</param>
        /// <returns>Messages with variables replaces.</returns>
        Task<string[]> InjectVariables(VariableContext variableContext, string[] messages);
    }
}