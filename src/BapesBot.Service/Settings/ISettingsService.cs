using BapesBot.Domain.Settings;

namespace BapesBot.Service.Settings
{
    /// <summary>
    /// Interface for the SettingsService
    /// </summary>
    public interface ISettingsService
    {
        TwitchSettings GeTwitchSettings();
    }
}