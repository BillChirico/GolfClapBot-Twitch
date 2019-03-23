using System;
using System.IO;
using System.Linq;
using BapesBot.Service.Commands.Settings;
using Newtonsoft.Json;

namespace BapesBot.Service.CommandPersistence
{
    public class FilePersistence<T> : ICommandPersistence<T> where T : CommandSettings
    {
        public void Save(T value)
        {
            using (var file =
                File.CreateText(
                    $"{Directory.GetCurrentDirectory()}/{value.Command.CommandTriggers.FirstOrDefault()}.json"))
            {
                new JsonSerializer().Serialize(file, value);
            }
        }

        public T Get()
        {
            throw new NotImplementedException();
        }
    }
}