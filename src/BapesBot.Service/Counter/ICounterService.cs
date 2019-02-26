using BapesBot.Domain.Counter;

namespace BapesBot.Service.Counter
{
    /// <summary>
    /// Interface for the CounterService
    /// </summary>
    public interface ICounterService
    {
        CounterInfo AddCount();
        CounterInfo RemoveCount();
        CounterInfo GetCount();
    }
}
