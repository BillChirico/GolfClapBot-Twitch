using System.Threading.Tasks;
using TwitchLib.Api.Helix.Models.Games;

namespace GolfClapBot.Service.TwitchApiHelper
{
    /// <summary>
    ///     Helper methods for the Twitch API
    /// </summary>
    public interface ITwitchApiHelper
    {
        /// <summary>
        ///     Get the game that the user is currently streaming.
        /// </summary>
        /// <param name="username">User to get the game from.</param>
        /// <returns>Game that the user is streaming or null if not found.</returns>
        Task<Game> GetStreamGame(string username);
    }
}