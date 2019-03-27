using System;
using System.IO;
using System.Linq;
using GolfClapBot.Service.Commands;
using Newtonsoft.Json;

namespace GolfClapBot.Service.Persistence
{
    /// <summary>
    ///     Save command settings to a file.
    /// </summary>
    public class FilePersistence<T> : ICommandPersistence<T> where T : CommandSettings.CommandSettings
    {
        /// <inheritdoc />
        public void Save(T value)
        {
            try
            {
                var fileInfo =
                    new FileInfo(
                        $"{Directory.GetCurrentDirectory()}/Settings/{value.Command.CommandTriggers.FirstOrDefault()}.json");

                fileInfo.Directory?.Create();

                using (var file = fileInfo.CreateText())
                {
                    new JsonSerializer().Serialize(file, value);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Erroring while saving command settings: {exception.Message}");
            }
        }

        /// <inheritdoc />
        public T Get(Command command)
        {
            try
            {
                var fileInfo =
                    new FileInfo(
                        $"{Directory.GetCurrentDirectory()}/Settings/{command.CommandTriggers.FirstOrDefault()}.json");

                return fileInfo.Exists ? JsonConvert.DeserializeObject<T>(File.ReadAllText(fileInfo.FullName)) : null;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Erroring while getting command settings: {exception.Message}");

                return null;
            }
        }
    }
}