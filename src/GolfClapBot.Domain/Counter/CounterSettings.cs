namespace GolfClapBot.Domain.Counter
{
    /// <summary>
    ///     Counter command settings.
    /// </summary>
    public class CounterSettings : CommandSettings.CommandSettings
    {
        /// <summary>
        ///     Counter key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Counter value.
        /// </summary>
        public int Value { get; set; }
    }
}