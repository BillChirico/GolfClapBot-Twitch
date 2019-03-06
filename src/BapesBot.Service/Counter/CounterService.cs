using BapesBot.Domain.Counter;

namespace BapesBot.Service.Counter
{
    /// <inheritdoc />
    /// <summary>
    ///     Service to keep track of a counter. Add, Remove, and Get.
    /// </summary>
    public class CounterService : ICounterService
    {
        private readonly CounterInfo _counterInfo;

        public CounterService()
        {
            _counterInfo = new CounterInfo();
        }

        /// <summary>
        ///     Adds 1 to the Counter
        /// </summary>
        /// <returns>CounterInfo</returns>
        public CounterInfo AddCount()
        {
            _counterInfo.Counter += 1;

            return _counterInfo;
        }

        /// <summary>
        ///     Removes 1 from the Counter
        /// </summary>
        /// <returns>CounterInfo</returns>
        public CounterInfo RemoveCount()
        {
            _counterInfo.Counter -= 1;

            return _counterInfo;
        }

        /// <summary>
        ///     Returns the CounterInfo object
        /// </summary>
        /// <returns>CounterInfo</returns>
        public CounterInfo GetCount()
        {
            return _counterInfo;
        }
    }
}