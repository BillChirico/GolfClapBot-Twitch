using System.Collections.Generic;
using System.Threading.Tasks;
using GolfClapBot.Domain.Variables;
using GolfClapBot.Service.VariableManager.Variables;

namespace GolfClapBot.Service.VariableManager
{
    /// <inheritdoc />
    public class VariableManager : IVariableManager
    {
        private readonly IList<Variable> _variables;

        public VariableManager(IList<Variable> variables)
        {
            _variables = variables;
        }

        /// <inheritdoc />
        public async Task<string> InjectVariables(VariableContext variableContext, string message)
        {
            foreach (var variable in _variables)
                message = message.Replace($"{{{variable.VariableName}}}", await variable.GetValue(variableContext));

            return message;
        }

        /// <inheritdoc />
        public async Task<string[]> InjectVariables(VariableContext variableContext, string[] messages)
        {
            foreach (var variable in _variables)
                for (var i = 0; i < messages.Length; i++)
                    messages[i] = messages[i].Replace($"{{{variable.VariableName}}}",
                        await variable.GetValue(variableContext));

            return messages;
        }
    }
}