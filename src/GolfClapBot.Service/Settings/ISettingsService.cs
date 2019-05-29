using GolfClapBot.Domain.Settings;

namespace GolfClapBot.Service.Settings
{
    /// <summary>
    ///     Interface for the SettingsService
    /// </summary>
    public interface ISettingsService
    {
        TwitchSettings GeTwitchSettings();
    }
}