using BapesBot.Domain.Counter;

namespace BapesBot.Service.Counter
{
    public interface ICounterService
    {
        CounterInfo AddCount();
        CounterInfo RemoveCount();
        CounterInfo GetCount();
    }
}
