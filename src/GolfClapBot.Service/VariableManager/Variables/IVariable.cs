using System.Threading.Tasks;
using GolfClapBot.Domain.Variables;

namespace GolfClapBot.Service.VariableManager.Variables
{
    public interface IVariable
    {
        /// <summary>
        ///     Get the value of the variable to be injected.
        /// </summary>
        /// <param name="variableContext">Context for the variable.</param>
        /// <returns>Value to be injected.</returns>
        Task<string> GetValue(VariableContext variableContext);
    }
}