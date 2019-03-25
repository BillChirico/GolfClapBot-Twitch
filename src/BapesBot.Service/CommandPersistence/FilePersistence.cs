using System;
using System.IO;
using System.Linq;
using BapesBot.Service.Commands;
using BapesBot.Service.Commands.Settings;
using Newtonsoft.Json;

namespace BapesBot.Service.CommandPersistence
{
    public class FilePersistence<T> : ICommandPersistence<T> where T : CommandSettings
    {
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
                Console.WriteLine($"Erroring while saving: {exception.Message}");
            }
        }

        public T Get(Command command)
        {
            var fileInfo =
                new FileInfo(
                    $"{Directory.GetCurrentDirectory()}/Settings/{command.CommandTriggers.FirstOrDefault()}.json");

            return !fileInfo.Exists ? null : JsonConvert.DeserializeObject<T>(File.ReadAllText(fileInfo.FullName));
        }
    }
}