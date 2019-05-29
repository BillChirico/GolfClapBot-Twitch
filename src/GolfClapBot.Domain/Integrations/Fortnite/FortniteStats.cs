using Newtonsoft.Json;

namespace GolfClapBot.Domain.Integrations.Fortnite
{
    public class FortniteStats
    {
        [JsonProperty("lifeTimeStats")] public LifeTimeStat[] LifeTimeStats { get; set; }
    }
}