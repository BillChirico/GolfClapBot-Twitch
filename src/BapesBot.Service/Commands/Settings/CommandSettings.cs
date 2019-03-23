using Newtonsoft.Json;

namespace BapesBot.Service.Commands.Settings
{
    public class CommandSettings
    {
        [JsonIgnore]
        public Command Command { get; set; }
    }
}