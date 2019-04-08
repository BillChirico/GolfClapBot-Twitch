using System.Threading.Tasks;
using GolfClapBot.Domain.Variables;

namespace GolfClapBot.Service.VariableManager.Variables
{
    public abstract class Variable
    {
        protected Variable(string variableName)
        {
            VariableName = variableName;
        }

        /// <summary>
        ///     Name of the variable used in injection.
        /// </summary>
        public string VariableName { get; }

        /// <summary>
        ///     Get the value of the variable to be injected.
        /// </summary>
        /// <param name="variableContext">Context for the variable.</param>
        /// <returns>Value to be injected.</returns>
        public abstract Task<string> GetValue(VariableContext variableContext);
    }
}