using System.Collections.Generic;
using GolfClapBot.Domain.Counter;

namespace GolfClapBot.Service.Counter
{
    /// <inheritdoc />
    /// <summary>
    ///     Service to keep track of a counter. Add, Remove, and Get.
    /// </summary>
    public class CounterService : ICounterService
    {
        private readonly Dictionary<string, CounterInfo> _counterInfo;

        public CounterService()
        {
            _counterInfo = new Dictionary<string, CounterInfo>();
        }

        /// <inheritdoc />
        public CounterInfo AddCount(CounterInfo counter)
        {
            counter.Count += 1;

            return counter;
        }

        /// <inheritdoc />
        public CounterInfo RemoveCount(CounterInfo counter)
        {
            counter.Count -= 1;

            return counter;
        }

        /// <inheritdoc />
        public CounterInfo GetCounter(string key)
        {
            return _counterInfo.ContainsKey(key) ? _counterInfo[key] : null;
        }

        /// <inheritdoc />
        public CounterInfo AddCounter(string key)
        {
            var counter = new CounterInfo {Name = key};
            _counterInfo.Add(key, counter);

            return counter;
        }
    }
}