using System.Collections.Generic;

namespace GolfClapBot.Domain.Constants
{
    public static class Constants
    {
        public static readonly List<string> KnownBots = new List<string>
        {
            "StreamElements",
            "StreamLabs",
            "BapesBot",
            "GolfClapBot",
            "Nightbot"
        };

        public static readonly List<string> CommandPrefixes = new List<string>
        {
            "$",
            "!"
        };
    }
}