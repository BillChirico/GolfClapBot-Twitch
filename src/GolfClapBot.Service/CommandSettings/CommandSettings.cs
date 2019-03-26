using GolfClapBot.Service.Commands;
using Newtonsoft.Json;

namespace GolfClapBot.Service.CommandSettings
{
    public class CommandSettings
    {
        [JsonIgnore]
        public Command Command { get; set; }
    }
}