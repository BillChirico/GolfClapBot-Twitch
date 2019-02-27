namespace BapesBot.Service.SoundEffects
{
    public abstract class ISoundEffect
    {
        protected ISoundEffect(string soundEffect)
        {
            SoundEffect = soundEffect;
        }
        public string SoundEffect { get; set; }
    }
}