using System.Threading.Tasks;

namespace TwitchTitleUpdater.Service.TwitchBot
{
    public interface ITwitchBot
    {
        /// <summary>
        ///     Connect bot to Twitch.
        /// </summary>
        /// <param name="clientId">Client ID of the bot to connect.</param>
        /// <param name="accessToken">Access token of the bot to connect.</param>
        Task Connect(string clientId, string accessToken);
    }
}