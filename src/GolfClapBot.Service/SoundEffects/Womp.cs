using System.Collections.Generic;

namespace GolfClapBot.Service.SoundEffects
{
    /// <summary>
    ///     Play the womp sound effect.
    /// </summary>
    public class Womp : SoundEffect
    {
        public Womp() : base(new List<string> { "thebapWomp", "!womp", "womp" },
            "./SoundFiles/Womp.wav")
        {
        }
    }
}