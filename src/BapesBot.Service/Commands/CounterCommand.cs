using System.Collections.Generic;
using System.Threading.Tasks;
using BapesBot.Service.Counter;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace BapesBot.Service.Commands
{
    /// <summary>
    ///     Manage a counter.
    /// </summary>
    public class CounterCommand : Command
    {
        private readonly ICounterService _counterService;
        private readonly ITwitchClient _twitchClient;
        private Arithmetic _arithmetic;
        private string _counterKey;

        public CounterCommand(ITwitchClient twitchClient, ICounterService counterService) : base(new List<string>
            {"counter", "count"})
        {
            _twitchClient = twitchClient;
            _counterService = counterService;
        }

        public override Task<bool> Invoke(ChatMessage message)
        {
            var counter = _counterService.GetCounter(_counterKey) ?? _counterService.AddCounter(_counterKey);

            switch (_arithmetic)
            {
                case Arithmetic.Addition:
                    _counterService.AddCount(counter);
                    break;
                case Arithmetic.Subtraction:
                    _counterService.RemoveCount(counter);
                    break;
                default:
                    _twitchClient.SendMessage(message.Channel, "You must specify addition (+) or subtraction (-).");
                    break;
            }

            _twitchClient.SendMessage(message.Channel,
                $"{counter.Name} adjusted. Current {counter.Name}: {counter.Count}");

            return Task.FromResult(true);
        }

        public void SetArguments(string arithmetic, string key)
        {
            _arithmetic = arithmetic == "-" ? Arithmetic.Subtraction : Arithmetic.Addition;

            _counterKey = key;
        }

        private enum Arithmetic
        {
            Addition,
            Subtraction
        }
    }
}