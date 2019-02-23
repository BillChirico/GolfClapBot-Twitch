using System.Threading;
using System.Threading.Tasks;
using BapesBot.Service.TwitchBot;
using Microsoft.Extensions.DependencyInjection;
using TwitchLib.Client;
using TwitchLib.Client.Interfaces;

namespace BapesBot.Console
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var serviceCollection = ConfigureServiceCollection(new ServiceCollection());
            var twitchBot = serviceCollection.GetRequiredService<ITwitchBot>();

            await twitchBot.Connect("twitchUsername", "accessToken");

            await Task.Delay(Timeout.Infinite);
        }

        private static ServiceProvider ConfigureServiceCollection(IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<ITwitchClient, TwitchClient>()
                .AddSingleton<ITwitchBot, TwitchBot>()
                .BuildServiceProvider();
        }
    }
}