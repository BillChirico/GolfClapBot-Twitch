using BapesBot.Domain.Settings;

namespace BapesBot.Service.Settings
{
    public interface ISettingsService
    {
        TwitchSettings GeTwitchSettings();
    }
}