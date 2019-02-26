using BapesBot.Domain.Counter;

namespace BapesBot.Service.Counter
{
    public class CounterService : ICounterService
    {

        private CounterInfo _counterInfo;

        public CounterService()
        {
            _counterInfo = new CounterInfo();
        }

        public CounterInfo AddCount()
        {
           _counterInfo.Counter += 1;

            return _counterInfo;
        }

        public CounterInfo RemoveCount()
        {
            _counterInfo.Counter -= 1;

            return _counterInfo;
        }


        public CounterInfo GetCount()
        {
            return _counterInfo;
        }
    }
}
