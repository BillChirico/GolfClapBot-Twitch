using System.Collections.Generic;
using System.Threading.Tasks;
using GolfClapBot.Service.Counter;
using TwitchLib.Client.Interfaces;
using TwitchLib.Client.Models;

namespace GolfClapBot.Service.Commands
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
            // Temporary fix to restrict command
            // TODO: Create proper permissions system
            if (!(message.IsModerator || message.IsBroadcaster))
                return Task.FromResult(false);

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

        public override Task ProcessArgs(List<string> args)
        {
            if (args.Count != 2) return Task.CompletedTask;

            _arithmetic = args[0] == "-" ? Arithmetic.Subtraction : Arithmetic.Addition;

            _counterKey = args[1];

            return Task.CompletedTask;
        }

        private enum Arithmetic
        {
            Addition,
            Subtraction
        }
    }
}