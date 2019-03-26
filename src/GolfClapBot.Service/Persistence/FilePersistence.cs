using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace GolfClapBot.Service.Persistence
{
    public class FilePersistence<T> : ICommandPersistence<T> where T : CommandSettings.CommandSettings
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

        public T Get()
        {
            throw new NotImplementedException();
        }
    }
}