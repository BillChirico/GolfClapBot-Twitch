using System.Collections.Generic;

namespace GolfClapBot.Service.SoundEffects
{
    /// <summary>
    ///     Play the golf clap sound effect.
    /// </summary>
    public class GolfClap : SoundEffect
    {
        public GolfClap() : base(new List<string> {"thebapGolfclap", "!golfclap", "$golfclap"},
            "./SoundFiles/GolfClap.wav")
        {
        }
    }
}