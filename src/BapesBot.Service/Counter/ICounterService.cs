using BapesBot.Domain.Counter;

namespace BapesBot.Service.Counter
{
    /// <summary>
    /// Interface for the CounterService
    /// </summary>
    public interface ICounterService
    {
        /// <summary>
        /// Add 1 to a Counter.
        /// </summary>
        /// <returns></returns>
        CounterInfo AddCount();

        /// <summary>
        /// Removes 1 from a Counter.
        /// </summary>
        /// <returns></returns>
        CounterInfo RemoveCount();

        /// <summary>
        /// Returns the CounterService object.
        /// </summary>
        /// <returns></returns>
        CounterInfo GetCount();
    }
}
