using GolfClapBot.Domain.Settings;
using Microsoft.Extensions.Configuration;

namespace GolfClapBot.Service.Settings
{
    public class SettingsService : ISettingsService
    {
        private readonly IConfigurationRoot _configuration;

        public SettingsService(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public TwitchSettings GeTwitchSettings()
        {
            var twitchSettings = new TwitchSettings();

            _configuration.GetSection("Twitch").Bind(twitchSettings);

            return twitchSettings;
        }
    }
}
