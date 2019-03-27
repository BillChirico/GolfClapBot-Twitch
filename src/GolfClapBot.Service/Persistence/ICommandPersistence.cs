using GolfClapBot.Service.Commands;

namespace GolfClapBot.Service.Persistence
{
    /// <summary>
    ///     Persistence for command settings.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommandPersistence<T> where T : CommandSettings.CommandSettings
    {
        /// <summary>
        ///     Save command settings.
        /// </summary>
        /// <param name="value">Value to save.</param>
        void Save(T value);

        /// <summary>
        ///     Get command settings.
        /// </summary>
        /// <param name="command">Command to get.</param>
        /// <returns>Command settings deserialized to model.</returns>
        T Get(Command command);
    }
}