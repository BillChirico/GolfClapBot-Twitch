using GolfClapBot.Domain.Counter;

namespace GolfClapBot.Service.Counter
{
    /// <summary>
    ///     Interface for the CounterService
    /// </summary>
    public interface ICounterService
    {
        /// <summary>
        ///     Add one to a Counter.
        /// </summary>
        /// <param name="counter">Counter to add one to.</param>
        /// <returns>Updater counter.</returns>
        CounterInfo AddCount(CounterInfo counter);

        /// <summary>
        ///     Removes one from a Counter.
        /// </summary>
        /// <param name="counter">Counter to remove one from.</param>
        /// <returns>Updated counter.</returns>
        CounterInfo RemoveCount(CounterInfo counter);

        /// <summary>
        ///     Get counter based on key.
        /// </summary>
        /// <param name="key">Key of counter.</param>
        /// <returns>Counter info.</returns>
        CounterInfo GetCounter(string key);

        /// <summary>
        ///     Get a new counter
        /// </summary>
        /// <param name="key">Key of counter.</param>
        /// <returns>Counter info.</returns>
        CounterInfo AddCounter(string key);
    }
}