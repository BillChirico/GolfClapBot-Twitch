using GolfClapBot.Service.Commands;

namespace GolfClapBot.Service.Persistence
{
    public interface ICommandPersistence<T> where T : CommandSettings.CommandSettings
    {
        void Save(T value);

        T Get(Command command);
    }
}