using System;
using System.Threading.Tasks;
using TwitchLib.Client.Interfaces;

namespace TwitchTitleUpdater.Service.TwitchBot
{
    public class TwitchBot : ITwitchBot
    {
        private readonly ITwitchClient _twitchClient;

        public TwitchBot(ITwitchClient twitchClient)
        {
            _twitchClient = twitchClient;
        }

        public Task Connect(string clientId, string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}