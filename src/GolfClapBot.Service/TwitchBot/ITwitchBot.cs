using System.Threading.Tasks;

namespace GolfClapBot.Service.TwitchBot
{
    public interface ITwitchBot
    {
        /// <summary>
        ///     Connect bot to Twitch.
        /// </summary>
        /// <param name="twitchUsername">Twitch Username of the bot to connect.</param>
        /// <param name="accessToken">Access token of the bot to connect.</param>
        /// <param name="channel">Channel to connect the bot to.</param>
        Task Connect(string twitchUsername, string accessToken, string channel);
    }
}