using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TwitchLib.Client;
using TwitchLib.Client.Interfaces;
using TwitchTitleUpdater.Service.TwitchBot;

namespace TwitchTitleUpdater.Console
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