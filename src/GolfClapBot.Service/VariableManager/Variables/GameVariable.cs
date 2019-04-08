using System.Threading.Tasks;
using GolfClapBot.Domain.Variables;
using GolfClapBot.Service.TwitchApiHelper;

namespace GolfClapBot.Service.VariableManager.Variables
{
    /// <summary>
    ///     Variable for currently streamed game.
    /// </summary>
    public class GameVariable : IVariable
    {
        private readonly ITwitchApiHelper _twitchApiHelper;

        public GameVariable(ITwitchApiHelper twitchApiHelper)
        {
            _twitchApiHelper = twitchApiHelper;
        }

        /// <summary>
        ///     Get the currently streamed game.
        /// </summary>
        /// <param name="variableContext">Context of the variable.</param>
        /// <returns>Game name that is currently being streamed.</returns>
        public async Task<string> GetValue(VariableContext variableContext)
        {
            return (await _twitchApiHelper.GetStreamGame(variableContext.StreamerUserName)).Name;
        }
    }
}