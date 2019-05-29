using Newtonsoft.Json;

namespace GolfClapBot.Domain.CommandSettings
{
    /// <summary>
    ///     Base class for command settings.
    /// </summary>
    public class CommandSettings
    {
        [JsonIgnore] public string CommandName { get; set; }
    }
}