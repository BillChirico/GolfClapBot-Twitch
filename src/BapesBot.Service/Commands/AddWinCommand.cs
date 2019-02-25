using System;
using System.Threading.Tasks;
using TwitchLib.Client.Events;
using TwitchLib.Client.Interfaces;


namespace BapesBot.Service.Commands
{
    public class AddWinCommand : ICommand
    {
        private readonly ITwitchClient _twitchClient;

        public AddWinCommand(ITwitchClient twitchClient) : base("addwin")
        {
            _twitchClient = twitchClient;
        }

        public static int Wins { get; set; }


        public override Task<bool> Invoke(OnMessageReceivedArgs message)
        {
            Wins += 1;
            _twitchClient.SendMessage(message.ChatMessage.Channel, $"Win Added. Current Wins:{Wins}");

            return Task.FromResult(true);
        }

        public static implicit operator int(AddWinCommand v)
        {
            throw new NotImplementedException();
        }
    }
}
