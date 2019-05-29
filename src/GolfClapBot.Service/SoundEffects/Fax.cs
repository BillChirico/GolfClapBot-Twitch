using System.Collections.Generic;

namespace GolfClapBot.Service.SoundEffects
{
    /// <summary>
    ///     Play the fax sound effect.
    /// </summary>
    public class Fax : SoundEffect
    {
        public Fax() : base(new List<string> {"thebapFax", "!fax", "$fax", "!facts", "$facts"},
            "./SoundFiles/Fax.wav")
        {
        }
    }
}