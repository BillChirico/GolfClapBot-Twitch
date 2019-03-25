using BapesBot.Service.Commands;
using BapesBot.Service.Commands.Settings;

namespace BapesBot.Service.CommandPersistence
{
    public interface ICommandPersistence<T> where T : CommandSettings
    {
        void Save(T value);

        T Get(Command command);
    }
}