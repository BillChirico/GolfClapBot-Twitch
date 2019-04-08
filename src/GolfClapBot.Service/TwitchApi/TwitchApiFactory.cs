using GolfClapBot.Service.Settings;
using TwitchLib.Api;
using TwitchLib.Api.Interfaces;

namespace GolfClapBot.Service.TwitchApi
{
    /// <summary>
    ///     Create and initialize an instance of ITwitchAPI
    /// </summary>
    public class TwitchApiFactory
    {
        private readonly ISettingsService _settingsService;

        public TwitchApiFactory(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public ITwitchAPI Create()
        {
            var twitchApi = new TwitchAPI();

            var twitchSettings = _settingsService.GeTwitchSettings();

            twitchApi.Settings.ClientId = twitchSettings.ClientId;
            twitchApi.Settings.AccessToken = twitchSettings.AccessToken;

            return twitchApi;
        }
    }
}