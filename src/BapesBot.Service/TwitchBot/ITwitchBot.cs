using System.Threading.Tasks;

namespace BapesBot.Service.TwitchBot
{
    public interface ITwitchBot
    {
        /// <summary>
        ///     Connect bot to Twitch.
        /// </summary>
        /// <param name="twitchUsername">Twitch Username of the bot to connect.</param>
        /// <param name="accessToken">Access token of the bot to connect.</param>
        Task Connect(string twitchUsername, string accessToken);
    }
}